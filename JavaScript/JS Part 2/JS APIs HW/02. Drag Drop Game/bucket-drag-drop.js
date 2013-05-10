var trashCount = 0;
function generateTrash() {
    var img = document.createElement("img");
    img.id = "trash" + trashCount;
    img.className = "trash";
    img.style.width = "50px";
    img.style.height = "50px";
    img.style.position = "absolute";
    img.style.top = generateRandomNumber(150, 500) + "px";
    img.style.left = generateRandomNumber(200, 750) + "px";
    img.src = "images/trash.png";

    img.draggable = "true";
    img.addEventListener("dragstart", drag);

    trashCount++;
    return img;
}

function generateRandomNumber(min, max) {
    return Math.random() * (max - min) + min;
}

function drag(ev) {
    ev.dataTransfer.setData("trash-id", ev.target.id);
}

function drop(ev) {
    ev.preventDefault();

    var data = ev.dataTransfer.getData("trash-id");
    document.body.removeChild(document.getElementById(data));

    var img = document.getElementById("bucket");
    img.src = "images/closed-bucket.png";
}

function openBucket(ev) {
    ev.preventDefault();
    var img = document.getElementById("bucket");
    img.src = "images/opened-bucket.png";
}

function closeBucket(ev) {
    ev.preventDefault();
    var img = document.getElementById("bucket");
    img.src = "images/closed-bucket.png";
}

for (var i = 0; i < 10; i++) {
    document.body.appendChild(generateTrash());
}

var bucket = document.getElementById("bucket");
bucket.addEventListener("dragover", openBucket, false);
bucket.addEventListener("dragleave", closeBucket, false);
bucket.addEventListener("drop", drop);