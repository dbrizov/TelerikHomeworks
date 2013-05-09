(function init() {
    setInterval(drawFrame, 20);
})();

var speedVector = {
    x: 3,
    y: 3
}

var ballPosition = {
    x: 50,
    y: -50
}

function drawFrame() {
    var canvas = document.getElementsByTagName("canvas")[0];
    var ctx = canvas.getContext("2d");
    ctx.save();

    var width = canvas.width;
    var height = canvas.height;
    ctx.translate(width / 2, height / 2);
    ctx.clearRect(-width / 2, -height / 2, width, height);

    // draw the field
    ctx.fillStyle = "rgb(0, 0, 150)";
    ctx.fillRect(-width / 2, -height / 2, width, height);
    ctx.fillStyle = "rgb(230, 230, 230)";
    ctx.fillRect(-width / 2 + 20, -height / 2 + 20, width - 40, height - 40);

    // draw the ball
    ballPosition.x += speedVector.x;
    ballPosition.y += speedVector.y;
    var ballRadius = 10;
    
    ctx.fillStyle = "rgb(200, 0, 0)";
    ctx.beginPath();
    ctx.arc(ballPosition.x, ballPosition.y, ballRadius, 0, 2 * Math.PI, true);
    ctx.fill();

    // check for wall impact and direction change
    var xLimit = width / 2 - 20 - ballRadius;
    var yLimit = height / 2 - 20 - ballRadius;

    if (Math.abs(ballPosition.x) >= xLimit) {
        speedVector.x *= -1;
    }

    if (Math.abs(ballPosition.y) >= yLimit) {
        speedVector.y *= -1;
    }

    ctx.restore();
}