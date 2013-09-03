/// <reference path="libs/jquery-1.9.1.js" />
/// <reference path="libs/q.min.js" />
/// <reference path="libs/sammy-0.7.4.js" />
/// <reference path="app/users-persister.js" />
/// <reference path="app/data-persister.js" />
/// <reference path="app/ui-controller.js" />
/// <reference path="app/controller.js" />

$(document).ready(function () {
    dataPersister = new DataPersister("http://localhost:62826/api/");
    uiController = new UserInterfaceContoller();
    controller = new Controller(dataPersister, uiController);

    var app = $.sammy("#main-content", function () {

        this.get("#/", function () {
            controller.homePage();
        });

        this.get("#/login", function () {
            controller.goToLoginPage();
        });

        this.get("#/register", function () {
            controller.goToRegisterPage();
        });

        this.get("#/user", function () {
            controller.userPage();
        });

        this.get("#/posts", function () {
            controller.viewPosts();
        });
    });

    app.run("#/");
    controller.attachEventHandlers();
});