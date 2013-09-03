/// <reference path="_references.js" />

(function () {
    /* Layouts */
    var userLayout = new kendo.Layout('<div id="user-form"></div>');
    var mainLayout = new kendo.Layout('<div id="main-layout"></div>');

    /* Routing */
    var data = persisters.get("http://localhost:16183/api/");
    viewModelsFactory.setPersister(data);

    var router = new kendo.Router();

    // Home router
    router.route("/home", function () {
        if (data.users.isUserLoggedIn()) {
            viewsFactory.getLogoutView()
                .then(function (logoutViewHtml) {
                    viewModelsFactory.getLogoutViewModel(function () {
                        $("#user-form").html("");
                    })
                    .then(function (logoutViewModel) {
                        logoutViewModel.set("username", data.users.username());
                        var view = new kendo.View(logoutViewHtml, { model: logoutViewModel });

                        userLayout.showIn("#user-form", view);
                    })
                    .done();
                });
        }
    });

    // Login router
    router.route("/login", function () {
        viewsFactory.getLoginView()
            .then(function (loginViewHtml) {
                viewModelsFactory.getLoginRegisterViewModel(function () {
                    router.navigate("/home");
                })
                .then(function (loginViewModel) {
                    var view = new kendo.View(loginViewHtml, { model: loginViewModel });

                    userLayout.showIn("#user-form", view);
                })
                .done();
            });
    });

    // Register router
    router.route("/register", function () {
        viewsFactory.getRegisterView()
            .then(function (registerViewHtml) {
                viewModelsFactory.getLoginRegisterViewModel(function () {
                    router.navigate("/home");
                })
                .then(function (registerViewModel) {
                    var view = new kendo.View(registerViewHtml, { model: registerViewModel });

                    userLayout.showIn("#user-form", view);
                })
                .done();
            });
    });

    router.route("/appointments/new", function () {
        $("#main-layout").html("");
        viewsFactory.getCreateAppointmentView()
            .then(function (html) {
                viewModelsFactory.getCreateAppointmentViewModel(function () {
                    alert("Created");
                })
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/appointments/all", function () {
        $("#main-layout").html("");
        viewsFactory.getAppointmentsView()
            .then(function (html) {
                viewModelsFactory.getAppointmentsViewModel("all")
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/appointments/today", function () {
        $("#main-layout").html("");
        viewsFactory.getAppointmentsView()
            .then(function (html) {
                viewModelsFactory.getAppointmentsViewModel("today")
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/appointments/current", function () {
        $("#main-layout").html("");
        viewsFactory.getAppointmentsView()
            .then(function (html) {
                viewModelsFactory.getAppointmentsViewModel("current")
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/appointments/comming", function () {
        $("#main-layout").html("");
        viewsFactory.getAppointmentsView()
            .then(function (html) {
                viewModelsFactory.getAppointmentsViewModel("comming")
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/lists/new", function () {
        $("#main-layout").html("");
        viewsFactory.getCreateTodoListView()
            .then(function (html) {
                viewModelsFactory.getCreateTodoListViewModel(function () {
                    alert("Created");
                })
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/lists/all", function () {
        $("#main-layout").html("");
        viewsFactory.getTodoListsView()
            .then(function (html) {
                viewModelsFactory.getTodoListsViewModel()
                    .then(function (viewModel) {
                        var view = new kendo.View(html, { model: viewModel });
                        mainLayout.showIn("#main-layout", view);
                    });
            });
    });

    router.route("/lists/:id/todos", function (id) {
        $("#main-layout").html("");
        viewsFactory.getSingleTodoListView()
            .then(function (html) {
                //viewModelsFactory.getSingleTodoListViewModel(id)
                //    .then(function (viewModel) {
                //        var view = new kendo.View(html, { model: viewModel });
                //        mainLayout.showIn("#main-layout", view);
                //    });
                data.lists.single(id)
                    .then(function (todoList) {
                        var template = kendo.template(html);
                        $("#main-layout").html(template(todoList));
                    });
            });
    });

    router.route("/todos/:id", function (id) {
        data.todos.changeStatus(id)
            .then(function () {
                var anchor = $("#todo-" + id);
                var text = anchor.text();

                if (text === "done") {
                    anchor.text("not-done");
                }
                else {
                    anchor.text("done");
                }

                //var todoListId = $("#" + id).id;
                //console.log(todoListId);
                //router.navigate("/lists/" + todoListId + "/todos");
            });

        //router.navigate("/lists/" + id + "/todos");
    });

    $(document).ready(function () {
        router.start();
        userLayout.render("#user-content");
        mainLayout.render("#main");
    });
})();