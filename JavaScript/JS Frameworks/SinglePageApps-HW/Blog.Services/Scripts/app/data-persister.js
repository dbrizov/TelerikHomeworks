/// <reference path="../libs/class.js" />
/// <reference path="users-persister.js" />
/// <reference path="posts-persister.js" />

var DataPersister = Class.create({
    init: function (rootUrl) {
        this.rootUrl = rootUrl;
        this.users = new UsersPersister(this.rootUrl);
        this.posts = new PostsPersister(this.rootUrl);
    }
});