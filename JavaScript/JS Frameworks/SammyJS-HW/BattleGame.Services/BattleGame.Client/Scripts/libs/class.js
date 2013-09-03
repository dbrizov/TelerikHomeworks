/// <reference path="require.js" />
define(function () {
    function createClass(properties) {
        var F = function () {
            properties.init.apply(this, arguments);
        }

        for (var prop in properties) {
            F.prototype[prop] = properties[prop];
        }

        return F;
    }

    Function.prototype.inherit = function (parent) {
        var oldPrototype = this.prototype;
        var parentPrototype = new parent();
        this.prototype = parentPrototype;
        for (var prop in oldPrototype) {
            this.prototype[prop] = oldPrototype[prop];
        }
    }

    return {
        create: createClass
    }
});