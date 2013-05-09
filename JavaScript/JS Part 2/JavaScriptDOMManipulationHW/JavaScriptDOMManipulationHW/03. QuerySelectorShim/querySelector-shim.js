if (!document.querySelector) {
    var result;

    document.querySelector = function (selector) {
        if (selector.match(/[\w]+/)) {
            result = document.getElementsByTagName(selector)[0];
        }
        else if (selector.match(/#[\w]+/)) {
            result = document.getElementById(selector);
        }
        else if (selector.match(/.[\w]+/)) {
            result = document.getElementsByClassName(selector)[0];
        }

        return result;
    }
}

if (!document.querySelectorAll) {
    var result;

    document.querySelectorAll = function (selector) {
        if (selector.match(/[\w]+/)) {
            result = document.getElementsByTagName(selector);
        }
        else if (selector.match(/#[\w]+/)) {
            result = document.getElementById(selector);
        }
        else if (selector.match(/.[\w]+/)) {
            result = document.getElementsByClassName(selector);
        }

        return result;
    }
}