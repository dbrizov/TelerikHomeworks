function addItem() {
    var inputElement = document.getElementById("main-input");
    var value = inputElement.value;

    var checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    var span = document.createElement("span");
    span.innerHTML = value;
    var div = document.createElement("div");
    div.appendChild(checkbox);
    div.appendChild(span);

    var form = document.getElementById("todo-list");
    form.appendChild(div);
}

function deleteCheckedItems() {
    var form = document.getElementById("todo-list");
    var allCheckboxes = form.getElementsByTagName("input");

    var checkedBoxes = [];
    for (var i = 0; i < allCheckboxes.length; i++) {
        if (allCheckboxes[i].checked === true) {
            checkedBoxes.push(allCheckboxes[i]);
        }
    }

    for (var i = 0; i < checkedBoxes.length; i++) {
        form.removeChild(checkedBoxes[i].parentNode);
    }
}

function hideCheckedItems() {
    var form = document.getElementById("todo-list");
    var allCheckboxes = form.getElementsByTagName("input");

    var checkedBoxes = [];
    for (var i = 0; i < allCheckboxes.length; i++) {
        if (allCheckboxes[i].checked === true) {
            checkedBoxes.push(allCheckboxes[i]);
        }
    }

    for (var i = 0; i < checkedBoxes.length; i++) {
        checkedBoxes[i].parentNode.style.display = "none";
    }
}

function showAllItems() {
    var form = document.getElementById("todo-list");
    var allCheckboxes = form.getElementsByTagName("input");

    for (var i = 0; i < allCheckboxes.length; i++) {
        var parent = allCheckboxes[i].parentNode;
        if (parent.style.display === "none") {
            parent.style.display = "block";
        }
    }
}

var addButton = document.getElementById("add-button");
addButton.addEventListener("click", addItem, false);

var deleteButton = document.getElementById("delete-button");
deleteButton.addEventListener("click", deleteCheckedItems, false);

var hideButton = document.getElementById("hide-button");
hideButton.addEventListener("click", hideCheckedItems, false);

var showButton = document.getElementById("show-button");
showButton.addEventListener("click", showAllItems, false);

window.onkeydown = function (ev) {
    if (ev.keyCode === 13) {
        ev.preventDefault();
        addItem();
    }
}