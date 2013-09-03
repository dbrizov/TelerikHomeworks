/// <reference path="../libs/class.js" />
/// <reference path="../libs/crypto-sha1.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="../libs/q.js" />

var UsersPersister = Class.create({
    init: function (rootUrl) {
        this.rootUrl = rootUrl + "users/";
        this.user = {
            displayName: localStorage.getItem('displayName'),
            sessionKey: localStorage.getItem('sessionKey')
        }
    },

    register: function (user) {
        var that = this;
        var url = this.rootUrl + "register";
        var userData = {
            username: user.username,
            displayName: user.displayName,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        }

        return HttpRequester.postJson(url, userData).then(
            function (data) {
                localStorage.setItem('displayName', data.displayName);
                localStorage.setItem('sessionKey', data.sessionKey);

                that.user.displayName = data.displayName;
                that.user.sessionKey = data.sessionKey;

                return data;
            },
            function (errData) {
                return errData;
            });
    },

    login: function (user, success, error) {
        var that = this;
        var url = this.rootUrl + "login";
        var userData = {
            username: user.username,
            authCode: CryptoJS.SHA1(user.username + user.password).toString()
        }

        return HttpRequester.postJson(url, userData).then(
            function (data) {
                localStorage.setItem('displayName', data.displayName);
                localStorage.setItem('sessionKey', data.sessionKey);

                that.user.displayName = data.displayName;
                that.user.sessionKey = data.sessionKey;

                return data;
            },
            function (errData) {
                return errData;
            });
    },

    logout: function () {
        var that = this;
        var url = this.rootUrl + "logout?sessionKey=" + that.user.sessionKey;

        return HttpRequester.putJson(url, {}).then(
            function () {
                that.user.displayName = null;
                that.user.sessionKey = null;

                localStorage.clear();
            },
            function (errData) {
                return errData
            });
    },

    userIsLoggedIn: function () {
        return this.user.displayName !== null;
    }
});