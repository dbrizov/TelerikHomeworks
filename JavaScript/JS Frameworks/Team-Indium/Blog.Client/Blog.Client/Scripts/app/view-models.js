/// <reference path="../_references.js" />

window.viewModelsFactory = (function () {
    var data = null;

    function getLoginRegisterViewModel(successCallback) {
        var deferred = Q.defer();

        var viewModel = {
            username: "administrator",
            password: "admin",
            displayName: "Bash Admin",
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
                data.users.register(this.get("username"), this.get("displayName"), this.get("password"))
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
            displayName: "",
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

    function getTagsViewModel() {
        var deferred = Q.defer();

        data.tags.all()
            .then(function (tags) {
                viewModel = {
                    tags: tags
                };

                deferred.resolve(kendo.observable(viewModel));
            }, function (errData) {
                deferred.reject(errData);
            });

        return deferred.promise;
    }

    return {
        getLoginRegisterViewModel: getLoginRegisterViewModel,
        getLogoutViewModel: getLogoutViewModel,
        getTagsViewModel: getTagsViewModel,
        setPersister: function (persister) {
            data = persister
        }
    };
})();