/// <reference path="../_references.js" />
window.persisters = (function () {
    var userDisplayName = localStorage.getItem("displayName") || "";
    var sessionKey = localStorage.getItem("sessionKey") || "";
    var sessionKeyUrlParam = "sessionKey=" + sessionKey;

    function saveToLocalStorage(userData) {
        localStorage.setItem("displayName", userData.displayName);
        localStorage.setItem("sessionKey", userData.sessionKey);
    }

    function clearLocalStorage() {
        localStorage.removeItem("displayName");
        localStorage.removeItem("sessionKey");
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        login: function (username, password) {
            var user = {
                username: username,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJson(this.apiUrl + "login", user)
				.then(function (data) {
				    saveToLocalStorage(data);
				    userDisplayName = data.displayName;
				    sessionKey = data.sessionKey;
				    sessionKeyUrlParam = "sessionKey=" + sessionKey;

				    return userDisplayName;
				});
        },

        register: function (username, inputDisplayName, password) {
            var user = {
                username: username,
                displayName: inputDisplayName,
                authCode: CryptoJS.SHA1(password).toString()
            };

            console.log(user);

            return httpRequester.postJson(this.apiUrl + "register", user)
				.then(function (data) {
				    saveToLocalStorage(data);
				    userDisplayName = data.displayName;
				    sessionKey = data.sessionKey;
				    sessionKeyUrlParam = "sessionKey=" + sessionKey;

				    return userDisplayName;
				}, function (errData) {
				    console.log(errData);
				});
        },

        logout: function () {
            clearLocalStorage();
            return httpRequester.putJson(this.apiUrl + "logout?" + sessionKeyUrlParam);
        },

        displayName: function () {
            return userDisplayName;
        },

        isUserLoggedIn: function () {
            return sessionKey !== "";
        }
    });

    var PostsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            return httpRequester.getJson(this.apiUrl);
        },
        single: function (postId) {
            return httpRequester.getJson(this.apiUrl + "/" + postId);
        },
        add: function (post) {
            return httpRequester.postJson(this.apiUrl + "?" + sessionKeyUrlParam, post);
        },
        update: function (post) {
            return httpRequester.putJson(this.apiUrl + "?" + sessionKeyUrlParam, post);
        },
        deletePost: function (postId) {
            return httpRequester.deleteJson(this.apiUrl + "/" + postId + "?" + sessionKeyUrlParam);
        },
        comment: function (text, postId) {
            var data = {
                text: text
            };

            return httpRequester.putJson(this.apiUrl + "/" + postId + "/comment?" + sessionKeyUrlParam, data);
        }
    });

    var TagsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },
        all: function () {
            return httpRequester.getJson(this.apiUrl);
        },
        postsByTag: function (tagId) {
            return httpRequester.getJson(this.apiUrl + tagId + "/posts");
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(apiUrl + "users/");
            this.posts = new PostsPersister(apiUrl + "posts");
            this.tags = new TagsPersister(apiUrl + "tags/");
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());