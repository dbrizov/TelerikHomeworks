function onGenerateRandomDivsClick() {
    var divsCount = (document.getElementById("divs-count").value | 0) || 5;

    var docFragment = document.createDocumentFragment();

    for (var i = 0; i < divsCount; i++) {
        docFragment.appendChild(createRandomDiv());
    }

    var contentDiv = document.getElementById("content");
    while (contentDiv.firstChild) {
        contentDiv.removeChild(contentDiv.firstChild);
    }

    contentDiv.appendChild(docFragment);
}

function createRandomDiv() {
    var strong = document.createElement("strong");
    strong.innerHTML = "div";

    var div = document.createElement("div");
    div.appendChild(strong);
    div.style.width = (Math.random() * 80 + 21) + "px";
    div.style.height = (Math.random() * 80 + 21) + "px";
    div.style.backgroundColor = generateRandomColor();
    div.style.color = generateRandomColor();
    div.style.position = "absolute";
    div.style.top = (Math.random() * 500 + 50) + "px";
    div.style.left = (Math.random() * 800) + "px";
    div.style.borderRadius = (Math.random() * 50) + "px";
    div.style.borderColor = generateRandomColor();
    div.style.borderWidth = (Math.random() * 20 + 1) + "px";
    div.style.borderStyle = "solid";

    return div;
}

function generateRandomColor() {
    var red = (Math.random() * 256) | 0;
    var green = (Math.random() * 256) | 0;
    var blue = (Math.random() * 256) | 0;

    return "rgb(" + red + "," + green + "," + blue + ")";
}