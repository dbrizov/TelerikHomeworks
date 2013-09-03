/// <reference path="../libs/class.js" />
/// <reference path="../libs/crypto-sha1.js" />
/// <reference path="../libs/jquery-1.9.1.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="users-persister.js" />
/// <reference path="data-persister.js" />

var Controller = Class.create({
    init: function (dataPersister, uiController) {
        this.dataPersister = dataPersister;
        this.uiController = uiController;
    },

    homePage: function () {
        this.uiController.clearLoginRegisterForm();
        this.uiController.hideLogoutButton();

        if (!this.dataPersister.users.userIsLoggedIn()) {
            this.uiController.hideUserInfo();
            this.uiController.hideLogoutButton();
        }
    },

    userPage: function () {
        this.uiController.renderUserInfo("#user-info", this.dataPersister.users.user);
        this.uiController.clearLoginRegisterForm();
        this.uiController.showLogoutButton();
    },

    postsPage: function (posts) {
        this.uiController.renderPosts("#main-content #posts", posts);
    },

    goToLoginPage: function () {
        uiController.renderLoginForm("#login-register-form");
    },

    goToRegisterPage: function () {
        uiController.renderRegisterForm("#login-register-form");
    },

    loginUser: function () {
        var that = this;
        var username = $("#login-register-form #tb-username").val();
        var password = $("#login-register-form #tb-password").val();

        var user = {
            username: username,
            password: password
        };

        this.dataPersister.users.login(user).then(
            function (data) {
                that.userPage();
            },
            function (errData) {
                console.log(errData);
                alert(errData);
            });
    },

    registerUser: function () {
        var that = this;
        var username = $("#login-register-form #tb-username").val();
        var displayName = $("#login-register-form #tb-display-name").val();
        var password = $("#login-register-form #tb-password").val();

        var user = {
            username: username,
            displayName: displayName,
            password: password
        };

        this.dataPersister.users.register(user).then(
            function (data) {
                that.userPage();
            },
            function (errData) {
                console.log(errData);
                alert(errData);
            });
    },

    logoutUser: function () {
        var that = this;

        this.dataPersister.users.logout().then(
            function () {
                that.homePage();
            },
            function (errData) {
                console.log(errData);
                alert(errData);
            });
    },

    viewPosts: function () {
        var that = this;
        this.dataPersister.posts.getPosts(that.dataPersister.users.user.sessionKey).then(
            function (posts) {
                that.postsPage(posts);
            },
            function (errData) {
                console.log(errData);
                alert(errData);
            });
    },

    attachEventHandlers: function () {
        var that = this;

        var mainContent = $("#main-content");

        mainContent.on('click', '#btn-login', function () {
            that.loginUser();
        });

        mainContent.on('click', '#btn-register', function () {
            that.registerUser();
        });

        $("#main-nav").on('click', '#btn-logout', function () {
            that.logoutUser();
        });
    }
});