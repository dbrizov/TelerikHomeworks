/// <reference path="class.js" />
/// <reference path="crypto-sha1.js" />
/// <reference path="jquery-1.10.1.js" />
/// <reference path="http-requester.js" />

var dataPersister = (function () {
    var nickname = localStorage["nickname"];
    var sessionKey = localStorage["sessionKey"];

    function saveUserData(userData) {
        localStorage.setItem("nickname", userData.nickname);
        localStorage.setItem("sessionKey", userData.sessionKey);
        nickname = userData.nickname;
        sessionKey = userData.sessionKey
    }

    function clearUserData() {
        localStorage.removeItem("nickname");
        localStorage.removeItem("sessionKey");
        nickname = undefined;
        sessionKey = undefined;
    }

    var MainPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.user = new UserPersister(this.rootUrl);
            this.game = new GamePersister(this.rootUrl);
            this.guess = new GuessPersister(this.rootUrl);
            this.messages = new MessagePersister(this.rootUrl);
        },

        isUserLoggedIn: function () {
            var isLoggedIn = nickname != null && sessionKey != null;
            return isLoggedIn;
        },

        nickname: function () {
            return nickname;
        }
    });

    var UserPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "user/";
        },

        register: function (user, success, error) {
            var url = this.rootUrl + "register";
            var userData = {
                username: user.username,
                nickname: user.nickname,
                authCode: CryptoJS.SHA1(user.password).toString()
            }

            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },

        login: function (user, success, error) {
            var url = this.rootUrl + "login";
            var userData = {
                username: user.username,
                authCode: CryptoJS.SHA1(user.password).toString()
            }

            httpRequester.postJSON(url, userData,
                function (data) {
                    saveUserData(data);
                    success(data);
                }, error);
        },

        logout: function (success, error) {
            var url = this.rootUrl + "logout/" + sessionKey;
            httpRequester.getJSON(url,
                function (data) {
                    clearUserData();
                    success(data);
                }, error);
        },

        scores: function () {
            // TODO
        }
    });

    var GamePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "game/";
        },

        create: function (game, success, error) {
            var url = this.rootUrl + "create/" + sessionKey;
            var gameData = {
                title: game.title,
                number: game.number
            };

            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.password).toString();
            }

            httpRequester.postJSON(url, gameData, success, error);
        },

        join: function (game, success, error) {
            var url = this.rootUrl + "join/" + sessionKey;
            var gameData = {
                gameId: game.gameId,
                number: game.number
            }

            if (game.password) {
                gameData.password = CryptoJS.SHA1(game.password).toString();
            }

            httpRequester.postJSON(url, gameData, success, error);
        },

        start: function (gameId, success, error) {
            var url = this.rootUrl + gameId + "/start/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },

        open: function (success, error) {
            var url = this.rootUrl + "open/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },

        myActive: function (success, error) {
            var url = this.rootUrl + "my-active/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        },

        state: function (gameId, success, error) {
            var url = this.rootUrl + gameId + "/state/" + sessionKey;
            httpRequester.getJSON(url, success, error);
        }
    });

    var GuessPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl + "guess/";
        },

        make: function (guessData, success, error) {
            var url = this.rootUrl + "make/" + sessionKey;
            httpRequester.postJSON(url, guessData, success, error);
        }
    });

    var MessagePersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },

        unread: function () {
        },

        all: function () {
        }
    });

    return {
        getPersister: function (rootUrl) {
            return new MainPersister(rootUrl);
        }
    }
})();