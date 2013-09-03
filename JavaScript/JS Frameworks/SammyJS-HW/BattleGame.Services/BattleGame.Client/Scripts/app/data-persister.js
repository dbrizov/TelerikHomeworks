/// <reference path="../libs/require.js" />
/// <reference path="../libs/crypto-sha1.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="../libs/q.js" />

define(["http-requester", "class", "crypto", "q"], function (requester, Class, crypto, Q) {
    var nickname = localStorage["nickname"];
    var sessionKey = localStorage["sessionKey"];

    function saveUserAuthetication(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey
    }

    function clearUserAuthetication() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = null;
        sessionKey = null;
    }

    var DataPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.users = new UsersPersister(this.rootUrl + "user/");
            this.games = new GamesPersister(this.rootUrl + "game/");
        },

        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null && sessionKey != null;
            return isLoggedIn;
        },

        nickname: function () {
            return nickname;
        }
    });

    var UsersPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },

        register: function (user) {
            var user = {
                username: user.username,
                nickname: user.nickname,
                authCode: crypto.SHA1(user.username + user.password).toString()
            };

            return requester.postJson(this.rootUrl + "register", user)
                .then(
                    function (data) {
                        saveUserAuthetication(data)
                        return data;
                    },
                    function (errData) {
                        return errData;
                    });
        },

        login: function (user) {
            var user = {
                username: user.username,
                authCode: crypto.SHA1(user.username + user.password).toString()
            };

            return requester.postJson(this.rootUrl + "login", user)
                .then(
                    function (data) {
                        saveUserAuthetication(data)
                        return data;
                    },
                    function (errData) {
                        return errData;
                    });
        },

        logout: function () {
            return requester.putJson(this.rootUrl + 'logout/' + sessionKey, {})
                .then(
                    function () {
                        clearUserAuthetication()
                    },
                    function (errData) {
                        return errData;
                    });
        }
    });

    var GamesPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },

        openedGames: function () {
            return requester.getJson(this.rootUrl + "open/" + sessionKey).then(
                function (games) {
                    return games
                },
                function (errData) {
                    return errData;
                });
        },

        activeGames: function () {
            return requester.getJson(this.rootUrl + "my-active/" + sessionKey).then(
                function (games) {
                    return games;
                },
                function (errData) {
                    return errData;
                });
        },

        joinGame: function (game) {
            return requester.postJson(this.rootUrl + "join/" + sessionKey, game);
        },

        createGame: function (game) {
            return requester.postJson(this.rootUrl + "create/" + sessionKey, game);
        },

        startGame: function (id) {
            return requester.putJson(this.rootUrl + id + "/start/" + sessionKey, {});
        },

        getField: function (id) {
            return requester.getJson(this.rootUrl + id + "/field/" + sessionKey);
        }
    });

    return DataPersister;
});