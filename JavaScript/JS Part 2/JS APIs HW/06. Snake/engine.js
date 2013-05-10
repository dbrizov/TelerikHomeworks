var storageCleanerButton = document.getElementById("storage-clear");
storageCleanerButton/addEventListener("click", clearScore, false);

function clearScore() {
    localStorage.clear();
    var rankList = document.getElementById("rank-list");
    rankList.innerHTML = "Top Five";
}

(function loadTopFiveScores() {
    function Pair(key, value) {
        this.key = key;
        this.value = value;
    }

    var allScores = [];
    for (var prop in localStorage) {
        allScores.push(new Pair(prop, localStorage[prop]));
    }

    // sort the scores
    for (var i = 0; i < allScores.length - 1; i++) {
        var maxScoreIndex = i;
        for (var j = i + 1; j < allScores.length; j++) {
            if (parseInt(allScores[j].value) > parseInt(allScores[maxScoreIndex].value)) {
                maxScoreIndex = j;
            }
        }

        var temp = allScores[i];
        allScores[i] = allScores[maxScoreIndex];
        allScores[maxScoreIndex] = temp;
    }

    // load the top five scores
    var rankList = document.getElementById("rank-list");
    var length;
    if (allScores.length < 5) {
        length = allScores.length;
    }
    else {
        length = 5;
    }

    for (var i = 0; i < length; i++) {
        var div = document.createElement("div");
        div.innerHTML = allScores[i].key + ": " + allScores[i].value;
        rankList.appendChild(div);
    }
})();

function saveScore(score) {
    var name = prompt("GAME OVER!\nEnter nickname:");
    if (localStorage[name]) {
        if (localStorage[name] < score) {
            localStorage[name] = score;
        }
    }
    else {
        localStorage[name] = score;
    }
}

function restartGame() {
    document.location.reload(false);
}

// Initialization
var canvas = document.getElementsByTagName("canvas")[0];
var width = canvas.width;
var height = canvas.height;
var ctx = canvas.getContext("2d");

var snake = new Snake(5, 5, 5);
var food = new Food(width, height);
var score = 0;

var scoreDiv = document.getElementById("score");
scoreDiv.style.fontWeight = "bold";
scoreDiv.innerHTML = "Score: " + score;

window.onkeydown = function (ev) {
    switch (ev.keyCode) {
        case 37:
            snake.turnLeft();
            break;
        case 38:
            snake.turnUp();
            break;
        case 39:
            snake.turnRight();
            break;
        case 40:
            snake.turnDown();
            break;
    }
}

function run(ctx, snake, width, height) {
    var nextHead = snake.getNextHead();
    var snakeBody = snake.snakeBody;

    // check for collision with itself
    for (var i = 0; i < snakeBody.length(); i++) {
        var elem = snakeBody.elementAt(i);
        if (elem.x === nextHead.x && elem.y === nextHead.y) {
            saveScore(score);
            restartGame();
        }
    }

    // check for collision with side walls
    if (nextHead.x <= 0 ||
            nextHead.x >= width - 10 ||
            nextHead.y <= 0 ||
            nextHead.y >= height - 10) {
        saveScore(score);
        restartGame();
    }

    // check for collision with food
    for (var i = 0; i < snakeBody.length() ; i++) {
        var elem = snakeBody.elementAt(i);
        if (elem.x === food.coords.x && elem.y === food.coords.y) {
            var snakeNextHead = snake.getNextHead();
            snake.snakeBody.enqueue(snakeNextHead);
            snake.head = snakeNextHead;
            food = new Food(width, height);
            score += 100;
            scoreDiv.innerHTML = "Score: " + score;
            break;
        }
    }

    snake.move();
    drawField(ctx, width, height);
    drawFood(ctx, food);
    drawSnake(ctx, snake);
}

function gameLoop() {
    run(ctx, snake, width, height);
}

setInterval(gameLoop, 100);