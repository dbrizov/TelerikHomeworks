(function () {
    function Item(title) {
        var that = this;
        var li = document.createElement("li");
        var anchor = document.createElement("a");
        anchor.href = "#";
        anchor.innerHTML = title;
        anchor.addEventListener("click", expandOrCollapse, false);
        li.appendChild(anchor);

        that.getLI = function () {
            return li;
        }

        that.addItem = function (title) {
            var ul;
            // if li does not have a ul inside it -> create it, else just take it
            if (li.childNodes[1]) {
                ul = li.childNodes[1];
            }
            else {
                ul = document.createElement("ul");
                li.appendChild(ul);
            }

            var newItem = new Item(title);
            ul.appendChild(newItem.getLI());

            return newItem;
        }
    }

    function Accordion(selector) {
        var that = this;
        var container = document.querySelector(selector);
        var mainUL = document.createElement("ul");
        container.appendChild(mainUL);

        that.addItem = function (title) {
            var newItem = new Item(title);
            mainUL.appendChild(newItem.getLI());

            return newItem;
        }
    }

    function expandOrCollapse(ev) {
        if (!ev) {
            ev = window.event;
        }

        ev.stopPropagation();
        ev.preventDefault();

        // anchor
        var clickedItem = ev.target;
        var liParent = clickedItem.parentNode;
        var ulChild = liParent.getElementsByTagName("ul")[0];

        // if the liParent does not have ul inside -> nothing is done
        if (!ulChild) {
            return;
        }

        // hides all ul elements except the one that is inside the liParent
        var ulGrandParent = liParent.parentNode;
        var ulGrantParentLIChilds = ulGrandParent.getElementsByTagName("li");
        for (var i = 0, len = ulGrantParentLIChilds.length; i < len; i += 1) {
            hideULs(ulGrantParentLIChilds[i], ulChild);
        }

        var displayed = ulChild.style.display === "block";

        if (displayed) {
            ulChild.style.display = "none";
            liParent.style.backgroundColor = "#4cd142";
        }
        else {
            ulChild.style.display = "block";
            liParent.style.backgroundColor = "#fff";
        }
    }

    // hides all ul elements inside a li item, except one exceptional ul element
    function hideULs(liElement, exceptionUL) {
        var uls = liElement.getElementsByTagName("ul");
        for (var i = 0, len = uls.length; i < len; i += 1) {
            if (uls[i] !== exceptionUL) {
                uls[i].style.display = "none";
                liElement.style.backgroundColor = "#4cd142";
            }
        }
    }

    var accordion = new Accordion("#accordion");
    var webItem = accordion.addItem("Web");
    webItem.addItem("HTML");
    webItem.addItem("CSS");

    var jsItem = webItem.addItem("JavaScript");
    jsItem.addItem("DOM Manipulation");
    jsItem.addItem("OOP");
    jsItem.addItem("Advanced finctions");
    jsItem.addItem("APIs");
    jsItem.addItem("Event Model");

     webItem.addItem("jQuery");

    var aspItem = webItem.addItem("ASP.NET MVC");
    aspItem.addItem("Binaries");
    aspItem.addItem("Libraries");
    aspItem.addItem("Source");

    var desktopItem = accordion.addItem("Desktop");
    desktopItem.addItem("WPF");
    desktopItem.addItem("Windows Forms");

    var mobileItem = accordion.addItem("Mobile");
    mobileItem.addItem("Windows Phone");
    mobileItem.addItem("Android");
    mobileItem.addItem("IOS");

    var embeddedItem = accordion.addItem("Embedded");
    embeddedItem.addItem("Haha");
    embeddedItem.addItem("Hihi");
    embeddedItem.addItem("Hoho");
})();