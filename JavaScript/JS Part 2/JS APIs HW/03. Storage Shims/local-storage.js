var cookies = (function() {
    if (!String.prototype.startsWith) {
        String.prototype.startsWith = function(str) {
            if (this.length < str.length) {
                return false;
            }
            for (var i = 0; i < str.length; i++) {
                if (this[i] !== str[i]) {
                    return false;
                }
            }
            return true;
        }
    }

    function readCookie(name) {
        var allCookies = document.cookie.split(";");
        for (var i = 0; i < allCookies.length; i++) {
            var cookie = allCookies[i];
            var trailingZeros = 0;
            for (var j = 0; j < cookie.length; j++) {
                if (cookie[j] !== " ") {
                    break;
                }
            }
            cookie = cookie.substring(j);
            if (cookie.startsWith(name + "=")) {
                return cookie;
            }
        }
    }

    function createCookie(name, value, days) {
        if (days) {
            var date = new Date();
            date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
            var expires = "; expires=" + date.toGMTString();
        } else var expires = "";
        document.cookie = name + "=" + value + expires + "; path=/";
    }

    function removeCookie(name) {
        createCookie(name, "", -1);
    }

    function getCookies() {
        var pairs = document.cookie.split(";");
        var cookies = new Array();
        for (var i = 0; i < pairs.length; i++) {
            var pair = pairs[i].split("=");
            cookies.push({ name: pair[0], value: pair[1] });
        }

        return cookies;
    }

    return {
    	read:readCookie,
    	create:createCookie,
    	remove: removeCookie,
        getCookies: getCookies
    };
}());

var myLocalStorage = (function () {
    function setItem(key, value) {
        cookies.create(key, value, 3650);
    }

    function getItem(key) {
        var cookie = cookies.read(key);
        var value;
        if (cookie) {
            var indexOfEqualSign = cookie.indexOf("=");
            value = cookie.substring(indexOfEqualSign + 1, cookie.length);
        }

        return value;
    }

    function removeItem(key) {
        cookies.remove(key);
    }

    function clear() {
        var allCookies = cookies.getCookies();
        for (var i = 0; i < allCookies.length; i++) {
            cookies.remove(allCookies[i].name);
        }
    }

    function length() {
        return cookies.getCookies().length;
    }

    return {
        setItem: setItem,
        getItem: getItem,
        removeItem: removeItem,
        clear: clear,
        length: length
    }
})();

if (!window.localStorage) {
    window.localStorage = myLocalStorage;
}
