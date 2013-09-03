/// <reference path="../_references.js" />

window.viewsFactory = (function () {
    var rootUrl = "Scripts/partials/";

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

    function getLoginView() {
        return getTemplate("login-form");
    }

    function getRegisterView() {
        return getTemplate("register-form");
    }

    function getLogoutView() {
        return getTemplate("logout-form");
    }

    function getCreateAppointmentView() {
        return getTemplate("create-appointment");
    }

    function getAppointmentsView() {
        return getTemplate("appointments");
    }

    function getTodoListsView() {
        return getTemplate("all-todo-lists");
    }

    function getCreateTodoListView() {
        return getTemplate("create-todo-list");
    }

    function getSingleTodoListView() {
        return getTemplate("single-todo-list");
    }

    return {
        getLoginView: getLoginView,
        getRegisterView: getRegisterView,
        getLogoutView: getLogoutView,
        getCreateAppointmentView: getCreateAppointmentView,
        getAppointmentsView: getAppointmentsView,
        getTodoListsView: getTodoListsView,
        getCreateTodoListView: getCreateTodoListView,
        getSingleTodoListView: getSingleTodoListView
    };
}());