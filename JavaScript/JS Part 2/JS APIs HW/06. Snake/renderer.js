function drawField(ctx, width, height) {
    ctx.save();

    ctx.fillStyle = "#000";
    ctx.fillRect(0, 0, width, height);

    ctx.fillStyle = "#00f";
    ctx.strokeStyle = "#000";
    for (var i = 0; i < width; i += 10) {
        ctx.fillRect(i, 0, 10, 10);
        ctx.strokeRect(i, 0, 10, 10);

        ctx.fillRect(i, height - 10, 10, 10);
        ctx.strokeRect(i, height - 10, 10, 10);
    }

    for (var i = 0; i < height; i += 10) {
        ctx.fillRect(0, i, 10, 10);
        ctx.strokeRect(0, i, 10, 10);

        ctx.fillRect(width - 10, i, 10, 10);
        ctx.strokeRect(width - 10, i, 10, 10);
    }

    ctx.restore();
}

function drawFood(ctx, food) {
    ctx.save();

    ctx.fillStyle = "#0f0";
    ctx.strokeStyle = "#000";
    ctx.fillRect(food.coords.x, food.coords.y, 10, 10);
    ctx.strokeRect(food.coords.x, food.coords.y, 10, 10);

    ctx.restore();
}

function drawSnake(ctx, snake) {
    ctx.save();

    ctx.fillStyle = "#f00";
    ctx.strokeStyle = "#000";

    var snakeBody = snake.snakeBody;
    for (var i = 0; i < snakeBody.length(); i++) {
        var snakeElem = snakeBody.elementAt(i);
        ctx.fillRect(snakeElem.x, snakeElem.y, 10, 10);
        ctx.strokeRect(snakeElem.x, snakeElem.y, 10, 10);
    }

    ctx.restore();
}