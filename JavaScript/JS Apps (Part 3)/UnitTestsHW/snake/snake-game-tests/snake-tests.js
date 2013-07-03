/// <reference path="../QUnit/qunit-1.11.0.js" />
/// <reference path="../snake-game/scripts/class.js" />
/// <reference path="../snake-game/scripts/snake.js" />
module("Snake.init");
test("When snake is initialized, should set the correct values", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    equal(position, snake.position, "Position is set");
    equal(speed, snake.speed, "Speed is set");
    equal(direction, snake.direction, "Direction is set");
});

test("When snake is initialized, should contain 5 SnakePieces", function () {
    var position = {
        x: 150,
        y: 150
    };
    var speed = 15;
    var direction = 0;
    var snake = new snakeGame.Snake(position, speed, direction);

    ok(snake.pieces, "SnakePieces are created");
    equal(snake.pieces.length, 5, "Five SnakePieces are created");
    ok(snake.head, "HeadSnakePiece is created");
});


module("Snake.Consume");
test("When object is Food, should grow", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);
    var size = snake.size;
    snake.consume(new snakeGame.Food());
    var actual = snake.size;
    var expected = size + 1;
    equal(actual, expected);
});

test("When object is SnakePiece, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.SnakePiece());
    ok(isDead, "The snake is dead");
});

test("When object is Obstacle, should die", function () {
    var snake = new snakeGame.Snake({
        x: 150,
        y: 150
    }, 15, 0);

    var isDead = false;

    snake.addDieHandler(function () {
        isDead = true;
    });

    snake.consume(new snakeGame.Obstacle());
    ok(isDead, "The snake is dead");
});

module("Snake.changeDirection");
test("When new direction is 0, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, speed = 5, dir = 1;
    var snake = new snakeGame.Snake(position, speed, dir);
    snake.changeDirection(0);

    equal(snake.head.direction, 0);
});

test("When new direction is 1, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, speed = 5, dir = 0;
    var snake = new snakeGame.Snake(position, speed, dir);
    snake.changeDirection(1);

    equal(snake.head.direction, 1);
});

test("When new direction is 2, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, speed = 5, dir = 1;
    var snake = new snakeGame.Snake(position, speed, dir);
    snake.changeDirection(2);

    equal(snake.head.direction, 2);
});

test("When new direction is 3, should be changed correctly", function () {
    var position = { x: 150, y: 150 }, speed = 5, dir = 0;
    var snake = new snakeGame.Snake(position, speed, dir);
    snake.changeDirection(3);

    equal(snake.head.direction, 3);
});

module("Snake.grow");
test("The snake size should increase with 10", function () {
    var position = { x: 150, y: 150 }, speed = 5, dir = 0;
    var snake = new snakeGame.Snake(position, speed, dir);
    
    equal(snake.size, 5, "The initial size is 5");
    for (var i = 0; i < 10; i++) {
        snake.grow();
    }

    equal(snake.size, 15, "The size increase with 10 (the size is now 15)");
});