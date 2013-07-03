/// <reference path="../QUnit/qunit-1.11.0.js" />
/// <reference path="../snake-game/scripts/class.js" />
/// <reference path="../snake-game/scripts/snake.js" />
module("Food.init");
test("When initialized, should set correct values", function () {
    var position = { x: 150, y: 150 };
    var size = 15;
    var food = new snakeGame.Food(position, size);

    deepEqual(food.position, position, "The position is correct");
    equal(food.size, size, "The size is correct");
});

module("Food.changePosition");
test("The position should go from (1, 1) to (50, 50)", function () {
    var position = { x: 1, y: 1 };
    var size = 15;
    var food = new snakeGame.Food(position, size);

    deepEqual(food.position, position, 'The initial position is (1, 1)');

    var newPosition = { x: 50, y: 50 };
    food.changePosition(newPosition);
    deepEqual(food.position, newPosition, "The new position is (50, 50)");
});