/// <reference path="../snake-game/scripts/class.js" />
/// <reference path="../snake-game/scripts/snake.js" />
/// <reference path="../QUnit/qunit-1.11.0.js" />
module("SnakeHeadPiece.init");
test("When snake piece is initialized, should set correct values", function () {
    var position = { x: 150, y: 150 }
    var size = 15;
    var speed = 5;
    var dir = 0;

    var snakeHeadPiece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    equal(snakeHeadPiece.position.x, 150, "The x coordinate is correct");
    equal(snakeHeadPiece.position.y, 150, "The y coordinate is correct");
    equal(snakeHeadPiece.size, 15, "The size is correct");
    equal(snakeHeadPiece.speed, 5, "The speed is correct");
    equal(snakeHeadPiece.direction, 0, "The direction is correct");
});

module("SnakeHeadPiece.move");
test("When direction is 0, decrease x", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.move();
    position.x = position.x - speed;
    deepEqual(piece.position, position);
});

test("When  direction is 1, decrease y", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.move();
    position.y = position.y - speed;
    deepEqual(piece.position, position);
});

test("When  direction is 2, increase x", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 2;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.move();
    position.x = position.x + speed;
    deepEqual(piece.position, position);
});

test("When  direction is 3, increase y", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 3;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.move();
    position.y = position.y + speed;
    deepEqual(piece.position, position);
});

module("SnakeHeadPiece.changeDirection");
test("When new direction is 0, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.changeDirection(0);

    equal(piece.direction, 0);
});

test("When new direction is 1, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.changeDirection(1);

    equal(piece.direction, 1);
});

test("When new direction is 2, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 1;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.changeDirection(2);

    equal(piece.direction, 2);
});

test("When new direction is 3, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, size = 15, speed = 5, dir = 0;
    var piece = new snakeGame.SnakeHeadPiece(position, size, speed, dir);
    piece.changeDirection(3);

    equal(piece.direction, 3);
});