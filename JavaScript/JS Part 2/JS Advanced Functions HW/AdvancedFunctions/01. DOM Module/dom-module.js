var domModule = (function () {
    // Appends childElem to the parent/s with a given selector
    function appendChild(childElem, parentSelector) {
        var parents = document.querySelectorAll(parentSelector);
        for (var i = 0; i < parent.length; i++) {
            parent[i].appendChild(childElem.cloneNode(true));
        }
    }

    // Removes all childs with a selector == childSelector
    // from all parents with a selector == parentSelector
    function removeChild(parentSelector, childSelector) {
        var parents = document.querySelectorAll(parentSelector);

        for (var i = 0; i < parents.length; i++) {
            var childs = parents[i].querySelectorAll(childSelector);

            for (var j = 0; j < childs.length; j++) {
                parents[i].removeChild(childs[j]);
            }
        }
    }

    // Adds events to all elements with a given selector
    function addHandler(selector, onEvent, func) {
        var elems = document.querySelectorAll(selector);
        for (var i = 0; i < elems.length; i++) {
            elems[i].addEventListener(onEvent, func, false);
        }
    }

    // Appends elements with given parent selector to a buffer.
    // If the elements with that parent selector reach count == 100,
    // then these elements are added to the parent element with that selector
    var buffer = new Array();
    function appendToBuffer(selector, elemToAppend) {
        if (buffer[selector]) {
            buffer[selector].push(elemToAppend);
        }
        else {
            buffer[selector] = new Array();
            buffer[selector].push(elemToAppend);
        }

        for (var i in buffer) {
            if (buffer[i].length !== 100) {
                continue;
            }

            var docFragment = document.createDocumentFragment();
            var length = buffer[i].length;
            for (var j = 0; j < length; j++) {
                docFragment.appendChild(buffer[i].pop());
            }

            var parent = document.querySelector(i);
            parent.appendChild(docFragment);
        }
    }

    // Gets all elements with a given CSS selector
    function getElementsByCssSelector(cssSelector) {
        return document.querySelectorAll(cssSelector);
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        appendToBuffer: appendToBuffer,
        getElementsByCssSelector: getElementsByCssSelector
    }
})();

// Second part of the exercise
var div = document.createElement("div");
div.style.width = "100px";
div.style.height = "100px";
div.style.border = "1px solid black";
div.style.backgroundColor = "red";

domModule.appendChild(div, "#wrapper");
domModule.removeChild("ul", "li:first-child"); //remove the first li from each ul

domModule.addHandler("a.button", 'click',
                     function () { alert("Clicked") });

// try with i < 100
// it won't append then navItems because the count will be 99, not 100
for (var i = 1; i <= 100; i++) {
    var navItem = document.createElement("li");
    navItem.innerHTML = "Nav Item " + i;

    domModule.appendToBuffer("#main-nav ul", navItem);
}

var nav = domModule.getElementsByCssSelector("ul.fruits")[0];
document.writeln(nav.innerHTML);
