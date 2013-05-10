function Snake(x, y, bodyLength) {
    var that = this;
    that.snakeBody = new Queue();
    for (var i = 0; i < bodyLength; i++) {
    	that.snakeBody.enqueue(new Coords(x + i, y));
    }
    
    that.currentDirection = new Coords(1, 0);
    that.head = that.snakeBody.getLastElem();
}

Snake.prototype = {
    constructor: Snake,

    getHead: function () {
        return this.head;
    },

    getNextHead: function () {
        var nextHead =
            new Coords(
                parseInt(this.head.x + this.currentDirection.x) / 10,
                parseInt(this.head.y + this.currentDirection.y) / 10
            );

        return nextHead;
    },

    move: function () {
        var nextHead = this.getNextHead();
        this.snakeBody.enqueue(nextHead);
        this.snakeBody.dequeue();

        this.head = nextHead;
    },

    turnLeft: function () {
        if (this.currentDirection.x !== 1 && this.currentDirection.y !== 0) {
            var leftDirection = new Coords(-1, 0);
            this.currentDirection = leftDirection;
        }
    },

    turnRight: function () {
        if (this.currentDirection.x !== -1 && this.currentDirection.y !== 0) {
            var rightDirection = new Coords(1, 0);
            this.currentDirection = rightDirection;
        }
    },

    turnUp: function () {
        if (this.currentDirection.x !== 0 && this.currentDirection !== 1) {
            var upDirection = new Coords(0, -1);
            this.currentDirection = upDirection;
        }
    },

    turnDown: function () {
        if (this.currentDirection.x !== 0 && this.curentDirection !== -1) {
            var downDirection = new Coords(0, 1);
            this.currentDirection = downDirection;
        }
    }
}