function Food(width, height) {
    var minWidth = 10;
    var maxWidth = width - 10;
    var minHeight = 10;
    var maxHeight = height - 10;

    var x = parseInt((Math.random() * (maxWidth - minWidth) + minWidth) / 10);
    var y = parseInt((Math.random() * (maxHeight - minHeight) + minHeight) / 10);

    this.coords = new Coords(x, y);
}