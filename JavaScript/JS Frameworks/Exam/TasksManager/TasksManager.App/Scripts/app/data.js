/// <reference path="../_references.js" />
window.persisters = (function () {
    var username = localStorage.getItem("username") || "";
    var accessToken = localStorage.getItem("accessToken") || "";
    var headers = {
        "X-accessToken": accessToken
    };

    function saveToLocalStorage(userData) {
        localStorage.setItem("username", userData.username);
        localStorage.setItem("accessToken", userData.accessToken);
    }

    function clearLocalStorage() {
        localStorage.removeItem("accessToken");
        localStorage.removeItem("username");
    }

    var UsersPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        login: function (inputUsername, password) {
            var user = {
                username: inputUsername,
                authCode: CryptoJS.SHA1(password).toString()
            };

            return httpRequester.postJson(this.apiUrl + "auth/token", user)
				.then(function (data) {
				    saveToLocalStorage(data);
				    username = data.username;
				    accessToken = data.accessToken;

				    return data;
				});

        },

        register: function (inputUsername, password, email) {
            var user = {
                username: inputUsername,
                authCode: CryptoJS.SHA1(password).toString(),
                email: email
            };

            return httpRequester.postJson(this.apiUrl + "users/register", user)
				.then(function (data) {
				    return data;
				}, function (errData) {
				    console.log(errData);
				});
        },

        logout: function () {
            clearLocalStorage();
            return httpRequester.putJson(this.apiUrl + "users/", {}, headers);
        },

        username: function () {
            return username;
        },

        isUserLoggedIn: function () {
            return accessToken !== "";
        }
    });

    var AppointmentsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl
        },

        create: function (appointment) {
            var data = {
                subject: appointment.subject,
                description: appointment.description,
                appointmentDate: appointment.appointmentDate,
                duration: appointment.duration
            };

            return httpRequester.postJson(this.apiUrl, data, headers);
        },

        all: function () {
            return httpRequester.getJson(this.apiUrl + "all", headers);
        },

        comming: function () {
            return httpRequester.getJson(this.apiUrl + "comming", headers);
        },

        today: function () {
            return httpRequester.getJson(this.apiUrl + "today", headers);
        },

        current: function () {
            return httpRequester.getJson(this.apiUrl + "current", headers);
        },

        allByDate: function (date) {
        },
    });

    var ListsPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
        },

        create: function (title, todos) {
            var todoList = {
                title: title,
                todos: todos
            }

            return httpRequester.postJson(this.apiUrl + "new", todoList, headers);
        },

        all: function () {
            return httpRequester.getJson(this.apiUrl, headers);
        },

        single: function (id) {
            return httpRequester.getJson(this.apiUrl + id + "/todos", headers);
        }
    });

    var TodosPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl
        },

        changeStatus: function (id) {
            return httpRequester.putJson(this.apiUrl + "/" + id, {}, headers);
        }
    });

    var DataPersister = Class.create({
        init: function (apiUrl) {
            this.apiUrl = apiUrl;
            this.users = new UsersPersister(this.apiUrl);
            this.appointments = new AppointmentsPersister(this.apiUrl + "appointments/");
            this.lists = new ListsPersister(this.apiUrl + "lists/");
            this.todos = new TodosPersister(this.apiUrl + "todos/");
        }
    });

    return {
        get: function (apiUrl) {
            return new DataPersister(apiUrl);
        }
    }
}());