/// <reference path="../_references.js" />

window.viewModelsFactory = (function () {
    var data = null;

    function getLoginRegisterViewModel(successCallback) {
        var deferred = Q.defer();

        var viewModel = {
            username: "denis.rizov",
            password: "123456",
            email: "d.b.rizov@gmail.com",
            login: function () {
                data.users.login(this.get("username"), this.get("password"))
					.then(function () {
					    if (successCallback) {
					        successCallback();
					    }
					}, function (errData) {
					    //TODO
					});
            },
            register: function () {
                data.users.register(this.get("username"), this.get("password"), this.get("email"))
                    .then(function () {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function (errData) {
                        //TODO
                    });
            }
        };

        deferred.resolve(kendo.observable(viewModel));

        return deferred.promise;
    }

    function getLogoutViewModel(successCallback) {
        var deferred = Q.defer();

        var viewModel = {
            username: "",
            logout: function () {
                data.users.logout()
                    .then(function (data) {
                        if (successCallback) {
                            successCallback();
                        }
                    }, function (errData) {
                        //TODO
                    });
            }
        }

        deferred.resolve(kendo.observable(viewModel));

        return deferred.promise;
    }

    function getCreateAppointmentViewModel(success) {
        var deferred = Q.defer();

        var viewModel = {
            subject: "Subject",
            description: "Description",
            appointmentDate: "",
            duration: 3600,
            create: function () {
                var appment = {
                    subject: this.get("subject"),
                    description: this.get("description"),
                    appointmentDate: this.get("appointmentDate"),
                    duration: this.get("duration")
                };

                data.appointments.create(appment)
                    .then(function () {
                        if (success) {
                            success();
                        }
                    }, function (err) {
                        deferred.reject(err);
                    });
            }
        };

        deferred.resolve(kendo.observable(viewModel));
        return deferred.promise;
    }

    function getAppointmentsViewModel(type) {
        var deferred = Q.defer();

        if (type === "all") {
            data.appointments.all()
                .then(function (appments) {
                    var viewModel = {
                        appments: appments
                    }

                    deferred.resolve(kendo.observable(viewModel));
                });
        }
        else if (type === "today") {
            data.appointments.today()
                .then(function (appments) {
                    var viewModel = {
                        appments: appments
                    }

                    deferred.resolve(kendo.observable(viewModel));
                });
        }
        else if (type === "current") {
            data.appointments.current()
                .then(function (appments) {
                    var viewModel = {
                        appments: appments
                    }

                    deferred.resolve(kendo.observable(viewModel));
                });
        }
        else if (type === "comming") {
            data.appointments.comming()
                .then(function (appments) {
                    var viewModel = {
                        appments: appments
                    }

                    deferred.resolve(kendo.observable(viewModel));
                });
        }

        return deferred.promise;
    }

    function getTodoListsViewModel() {
        var deferred = Q.defer();

        data.lists.all()
            .then(function (lists) {
                var viewModel = {
                    lists: lists
                }

                deferred.resolve(kendo.observable(viewModel));
            }, function (err) {
                deferred.reject(err);
            });

        return deferred.promise;
    }

    function getCreateTodoListViewModel(success) {
        var deferred = Q.defer();

        var viewModel = {
            title: "title",
            todos: [],
            todoText: "",
            todoIsDone: false,
            addTodo: function () {
                var newTodo = {
                    text: this.get("todoText"),
                    todoIsDone: this.get("todoIsDone") === false ? 0 : 1
                }

                this.get("todos").push(newTodo);
                this.set("todoText", "");
            },
            create: function () {
                data.lists.create(this.get("title"), this.get("todos"))
                    .then(function () {
                        if (success) {
                            success();
                        }
                    }, function (err) {
                        deferred.reject(err);
                    });
            }
        }

        deferred.resolve(kendo.observable(viewModel))
        return deferred.promise;
    }

    function getSingleTodoListViewModel(id) {
        var deferred = Q.defer();
        var that = this;

        var viewModel = {
            title: "",
            todos: []
        }

        data.lists.single(id)
            .then(function (todoList) {
                viewModel.title = todoList.title;
                for (var i = 0; i < viewModel.todos.length; i += 1) {
                    console.log(todoList[i]);
                    viewModel.todos.push(todoList[i]);
                }

                deferred.resolve(kendo.observable(viewModel));
            }, function (err) {
                deferred.reject(err);
            });

        return deferred.promise;
    }

    return {
        getLoginRegisterViewModel: getLoginRegisterViewModel,
        getLogoutViewModel: getLogoutViewModel,
        getCreateAppointmentViewModel: getCreateAppointmentViewModel,
        getAppointmentsViewModel: getAppointmentsViewModel,
        getTodoListsViewModel: getTodoListsViewModel,
        getCreateTodoListViewModel: getCreateTodoListViewModel,
        getSingleTodoListViewModel: getSingleTodoListViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
})();