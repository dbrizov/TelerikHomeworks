/// <reference path="../_references.js" />

window.viewsFactory = (function () {
    var rootUrl = "partials/";

    var templates = {};

    function getTemplate(name) {
        var deferred = Q.defer();

        if (templates[name]) {
            deferred.resolve(templates[name]);
        }
        else {
            $.ajax({
                url: rootUrl + name + ".html",
                type: "GET",
                dataType: "html",
                success: function (templateHtml) {
                    templates[name] = templateHtml;
                    deferred.resolve(templateHtml);
                },
                error: function (err) {
                    deferred.reject(err);
                }
            });
        }

        return deferred.promise;
    }

    function getHomeView() {
        return getTemplate("home-view");
    }

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getRegisterView() {
        return getTemplate("register-form");
    }

    function getLogoutView() {
        return getTemplate("logout-form");
    }

    function getAllPostsView() {
        return getTemplate("all-posts");
    }

    function getSinglePostView() {
        return getTemplate("single-post");
    }

    function getTagCloudView() {
        return getTemplate("tag-cloud");
    }

    return {
        getHomeView: getHomeView,
        getLoginView: getLoginView,
        getRegisterView: getRegisterView,
        getLogoutView: getLogoutView,
        getAllPostsView: getAllPostsView,
        getSinglePostView: getSinglePostView,
        getTagCloudView: getTagCloudView
    };
}());