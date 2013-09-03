/// <reference path="../libs/jquery-1.9.1.js" />
/// <reference path="../libs/class.js" />
/// <reference path="partials.js" />

var UserInterfaceContoller = Class.create({
    init: function () { },

    renderLoginForm: function (selector) {
        $(selector).html(partials.loginHtml);
    },

    renderRegisterForm: function (selector) {
        $(selector).html(partials.registerHtml);
    },

    renderUserInfo: function (selector, user) {
        $(selector).html(partials.userInfoTemplate(user));
    },

    renderPosts: function (selector, posts) {
        $(selector).html(partials.postsTemplate(posts));
    },

    clearUserInfo: function () {
        $("#user-info").html("");
    },

    clearLoginRegisterForm: function () {
        $("#login-register-form").html("");
    },

    showLogoutButton: function () {
        $("#btn-logout").css('display', 'inline');
    },

    hideLogoutButton: function () {
        $("#btn-logout").css('display', 'none');
    },
    
    hideUserInfo: function () {
        $("#user-info").css('display', 'none');
    }
});