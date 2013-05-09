function expandOrCollapseUL(event) {
    var unorderedListChild = this.getElementsByTagName('ul')[0];

    // Checks if the UL child of the event.target(the list item) is undefined.
    // If so, the function returns (void), 
    // then the bubbling will collapse the parent of the event.target(the list item)
    // which is the upper UL in the DOM
    if (typeof unorderedListChild === 'undefined') {
        return;
    }

    if (unorderedListChild.style.display === 'block') {
        unorderedListChild.style.display = 'none';
    }
    else {
        unorderedListChild.style.display = 'block';
    }

    // Stops the bubbling effect in order only one UL to
    // expand or collapse
    event.cancelBubble = true;
    event.stopPropagation();
}

var liElements = document.getElementsByTagName('li');

for (var i = 0; i < liElements.length; i++) {
    liElements[i].addEventListener('click', expandOrCollapseUL, false);
}