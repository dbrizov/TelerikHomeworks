/// <reference path="../libs/class.js" />
/// <reference path="../libs/http-requester.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/q.js" />

define(["http-requester", "class", "q"], function (HttpRequester, Class, Q) {
    var DataPersister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
            this.studentPersister = new StudentPresister(this.rootUrl + "students");
        }
    });

    var StudentPresister = Class.create({
        init: function (rootUrl) {
            this.rootUrl = rootUrl;
        },

        getStudents: function () {
            var deferred = Q.defer();

            HttpRequester.getJson(this.rootUrl)
                .then(function (responseData) {
                    deferred.resolve(responseData);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                }).done();

            return deferred.promise;
        },

        getMarksOfStudent: function (studentId) {
            var deferred = Q.defer();

            var servicesUrl = "/" + studentId + "/marks";
            HttpRequester.getJson(this.rootUrl + servicesUrl)
                .then(function (responseData) {
                    deferred.resolve(responseData);
                }, function (errorResponse) {
                    deferred.reject(errorResponse);
                }).done();

            return deferred.promise;
        }
    });

    return DataPersister;
});