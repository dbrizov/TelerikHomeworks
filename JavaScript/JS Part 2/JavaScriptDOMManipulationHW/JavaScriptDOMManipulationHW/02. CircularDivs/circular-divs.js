function generateRandomColor() {
    var red = (Math.random() * 256) | 0;
    var green = (Math.random() * 256) | 0;
    var blue = (Math.random() * 256) | 0;

    return "rgb(" + red + "," + green + "," + blue + ")";
}

function Circle(xCoord, yCoord, radius) {
    this.xCoord = xCoord;
    this.yCoord = yCoord;
    this.radius = radius;
}

function generateDiv(circle) {
    var result = document.createElement("div");

    result.style.backgroundColor = generateRandomColor();
    result.style.border = "1px solid black";
    result.style.borderRadius = "50%";
    result.style.width = (circle.radius * 2) + "px";
    result.style.height = (circle.radius * 2) + "px";
    result.style.position = "absolute";
    result.style.top = (circle.xCoord - circle.radius) + "px";
    result.style.left = (circle.yCoord - circle.radius) + "px";

    return result;
}

function generateCircularDivs(divsCount, mainCircle) {
    var circularDivs = [];
    var alpha = (360 / divsCount) * (Math.PI / 180);

    for (var i = 0; i < divsCount; i++) {
        var xCoord = mainCircle.xCoord + mainCircle.radius * Math.cos(i * alpha);
        var yCoord = mainCircle.yCoord + mainCircle.radius * Math.sin(i * alpha);
        var radius = 100 / divsCount;

        circularDivs.push(generateDiv(new Circle(xCoord, yCoord, radius)));
    }

    return circularDivs;
}

function appendCircularDivsToDocumentsBody(circularDivs) {
    for (var i = 0; i < circularDivs.length; i++) {
        document.body.appendChild(circularDivs[i]);
    }
}

var mainCircle = new Circle(200, 200, 100);
var mainDiv = generateDiv(mainCircle);
document.body.appendChild(mainDiv);

var circularDivs = generateCircularDivs(5, mainCircle);

var count = 5;
var alpha = (360 / circularDivs.length) * (Math.PI / 180);

function precalculateCircularDivsCoords(circularDivs, mainCircle) {
    var deltaAlpha = count * Math.PI / 180;

    for (var i = 0; i < circularDivs.length; i++) {
        var xCoord = mainCircle.xCoord + mainCircle.radius * Math.cos(i * alpha + deltaAlpha);
        var yCoord = mainCircle.yCoord + mainCircle.radius * Math.sin(i * alpha + deltaAlpha);
        var radius = 100 / circularDivs.length;

        circularDivs[i].style.top = (xCoord - radius) + "px";
        circularDivs[i].style.left = (yCoord - radius) + "px";
    }

    if (count === 360) {
        count = 0;
    }

    count += 5;
}

function drawCircularDivs() {
    appendCircularDivsToDocumentsBody(circularDivs);
    precalculateCircularDivsCoords(circularDivs, mainCircle);
}

setInterval(drawCircularDivs, 100);