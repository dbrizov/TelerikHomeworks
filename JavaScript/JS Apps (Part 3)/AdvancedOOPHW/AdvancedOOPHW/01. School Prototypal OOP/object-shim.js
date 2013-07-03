if (!Object.create) {
    Object.create = function (obj) {
        function F() { };
        F.prototype = obj;
        return new F();
    }
}

if (!Object.prototype.extend) {
    Object.prototype.extend = function (properties) {
        function F() { };
        F.prototype = Object.create(this);
        for (var prop in properties) {
            F.prototype[prop] = properties[prop];
        }

        return new F();
    }
}