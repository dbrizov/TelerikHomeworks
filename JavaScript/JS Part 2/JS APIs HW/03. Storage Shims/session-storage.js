var mySessionStorage = (function () {
    var storage = [];

    function setItem(key, value) {
        storage[key] = value;
    }

    function getItem(key) {
        return storage[key];
    }

    function removeItem(key) {
        if (storage[key]) {
            delete storage[key];
        }
    }

    function length() {
        var count = 0;
        for (var prop in storage) {
            count++;
        }

        return count;
    }

    function clear() {
        storage = [];
        length = 0;
    }

    function key(index) {
        var count = 0;
        for (var k in storage) {
            if (count == index) {
                return k;
            }
        }
    }

    return {
        setItem: setItem,
        getItem: getItem,
        removeItem: removeItem,
        clear: clear,
        key: key,
        length: length
    }
})();

if (!window.sessionStorage) {
    window.sessionStorage = mySessionStorage;
}