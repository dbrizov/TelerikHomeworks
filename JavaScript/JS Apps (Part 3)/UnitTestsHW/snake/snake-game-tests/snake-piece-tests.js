/// <reference path="../QUnit/qunit-1.11.0.js" />
/// <reference path="../snake-game/scripts/snake.js" />
/// <reference path="../snake-game/scripts/class.js" />
module("SnakePiece.init");
test("should set correct values",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      equal(piece.position, position, 'Psotion correct')
      equal(piece.size, 15, 'Size correct');
      equal(piece.speed, speed, 'Speed correct');
      equal(piece.direction, dir, 'Direction correct');
  });

module("SnakePiece.move");
test("When direction is 0, decrease x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.x -= speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 1, decrease update y",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.y -= speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 2, increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.x += speed;
      deepEqual(piece.position, position);
  });

test("When  direction is 3, should increase x",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.move();
      position.y += speed;
      deepEqual(piece.position, position);
  });

module("SnakePiece.changeDirection");
test("When new direction is 0, should be changed correctly",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(0);
      
      equal(piece.direction, 0);
  });

test("When new direction is 1, should be changed correctly",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(1);

      equal(piece.direction, 1);
  });

test("When new direction is 2, should be changed correctly",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(2);

      equal(piece.direction, 2);
  });

test("When new direction is 3, should be changed correctly",
  function () {
      var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
      var piece = new snakeGame.SnakePiece(position, size, speed, dir);
      piece.changeDirection(3);

      equal(piece.direction, 3);
  });