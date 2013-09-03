/// <reference path="../libs/class.js" />
/// <reference path="../libs/http-requester.js" />

var PostsPersister = Class.create({
    init: function (rootUrl) {
        this.rootUrl = rootUrl + "posts";
    },

    getPosts: function (sessionKey) {
        return HttpRequester.getJson(this.rootUrl + '?sessionKey=' + sessionKey);
    }
});