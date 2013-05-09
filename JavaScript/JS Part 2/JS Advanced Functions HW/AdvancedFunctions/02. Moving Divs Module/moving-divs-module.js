var movingDivsModule = (function () {
    var divs = new Array(); // an array of divs

    // represents a CircleDiv constructor
    // this.div = HTMLDivElement
    // the div rotates around the (xCoord, yCoord) point
    // this.alpha = the angle that helps for the calculation of the polar coordinates of the div
    function CircleDiv(div, xCoord, yCoord, radius) {
        this.div = div;
        this.xCoord = xCoord;
        this.yCoord = yCoord;
        this.radius = radius;
        this.alpha = 0;
    }
	
    // represents a RectangleDiv constructor
    // this.div = HTMLDivElement
    // this.width = the width of the rectangle
    // this.height = the height of the rectangle
    // the (startXCoord, startYCoord) point = the left-top point ot the div
    function RectangleDiv(div, width, height) {
        this.div = div;
        this.width = width;
        this.height = height;
        this.startXCoord = parseInt(this.div.style.left);
        this.startYCoord = parseInt(this.div.style.top);
    }

    function generateRandomDiv(innerHTML) {
        var div = document.createElement("div");
        div.style.border = "3px solid";
        div.style.borderColor = generateRandomColor();
        div.style.backgroundColor = generateRandomColor();
        div.style.color = generateRandomColor();
        div.style.fontWeight = "bold";
        div.style.textAlign = "center";
        div.style.position = "absolute";
        div.style.top = getRandomNumber(0, 400) + "px";
        div.style.left = getRandomNumber(0, 600) + "px";
        div.innerHTML = innerHTML;

        div.style.width = "50px";
        if (innerHTML === "circle") {
            div.style.borderRadius = "50%";
            div.style.height = "50px";
        }
        else {
            div.style.height = "25px";
        }

        return div;
    }

    function generateRandomColor() {
        var red = (Math.random() * 256) | 0;
        var green = (Math.random() * 256) | 0;
        var blue = (Math.random() * 256) | 0;

        return "rgb(" + red + "," + green + "," + blue + ")";
    }

    // min - inclusive, max - exclusive
    function getRandomNumber(min, max) {
        return Math.random() * (max - min) + min;
    }

    function degreesToRadians(degrees) {
        return degrees * Math.PI / 180;
    }

    function changeCircleDivPolarCoords(circleDiv) {
        var xCoord = circleDiv.xCoord;
        var yCoord = circleDiv.yCoord;
        var radius = circleDiv.radius;
        circleDiv.div.style.left = (xCoord + radius * Math.cos(degreesToRadians(circleDiv.alpha))) + "px";
        circleDiv.div.style.top = (yCoord + radius * Math.sin(degreesToRadians(circleDiv.alpha))) + "px";

        circleDiv.alpha = circleDiv.alpha % 360;
        circleDiv.alpha += 5;
    }

    function changeRectangleDivCoords(rectDiv) {
        var top = parseInt(rectDiv.div.style.top);
        var left = parseInt(rectDiv.div.style.left);
        var width = rectDiv.width;
        var height = rectDiv.height;

        if (left <= rectDiv.startXCoord &&
                top < height + rectDiv.startYCoord) {
            rectDiv.div.style.top = (top + 5) + "px";
        }
        else if (top >= height + rectDiv.startYCoord &&
                left < width + rectDiv.startXCoord) {
            rectDiv.div.style.left = (left + 5) + "px";
        }
        else if (left >= width + rectDiv.startXCoord &&
                top > rectDiv.startYCoord) {
            rectDiv.div.style.top = (top - 5) + "px";
        }
        else if (top <= rectDiv.startYCoord &&
                left > rectDiv.startXCoord) {
            rectDiv.div.style.left = (left - 5) + "px";
        }
    }

    function moveDivs() {
        for (var i = 0; i < divs.length; i++) {
            if (divs[i].div.innerHTML === "circle") {
                changeCircleDivPolarCoords(divs[i]);
            }
            else if (divs[i].div.innerHTML === "rect") {
                changeRectangleDivCoords(divs[i]);
            }
        }
    }

    function add(wayOfMoving) {
        if (wayOfMoving === "circle") {
            var div = generateRandomDiv(wayOfMoving);
            var xCoord = parseInt(div.style.left) + parseInt(div.style.left) / 2;
            var yCoord = parseInt(div.style.top) + parseInt(div.style.top) / 2;
            var radius = 75;

			var circleDiv = new CircleDiv(div, xCoord, yCoord, radius);
            divs.push(circleDiv);
			document.body.appendChild(circleDiv.div);
        }
        else if (wayOfMoving === "rect") {
            var div = generateRandomDiv(wayOfMoving);
            var width = 200;
            var height = 200;

			var rectDiv = new RectangleDiv(div, width, height);
            divs.push(rectDiv);
			document.body.appendChild(rectDiv.div);
        }
    }

    return {
        add: add,
        moveDivs: moveDivs
    }
})();

function addCirclularDiv() {
    movingDivsModule.add("circle");
}

function addRectangularDiv() {
    movingDivsModule.add("rect");
}

setInterval(movingDivsModule.moveDivs, 50);