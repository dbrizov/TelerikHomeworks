/// <reference path="../_references.js" />

var httpRequester = (function () {
    var makeGetRequestPromise = function (url) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "GET",
            dataType: "json",
            success: function (responseData) {
                deferred.resolve(responseData);
            },
            error: function (errorData) {
                deferred.reject(errorData);
            }
        });

        return deferred.promise;
    }

    var makePostRequestPromise = function (url, data) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (responseData) {
                deferred.resolve(responseData);
            },
            error: function (errorData) {
                deferred.reject(errorData);
            }
        });

        return deferred.promise;
    }

    var makePutRequestPromise = function (url, data) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: "PUT",
            contentType: "application/json",
            dataType: "json",
            success: function (responseData) {
                deferred.resolve(responseData);
            },
            error: function (errorData) {
                deferred.reject(errorData);
            }
        });

        return deferred.promise;
    }

    var makeDeleteRequestPromise = function (url) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "DELETE",
            contentType: "application/json",
            dataType: "json",
            success: function (responseData) {
                deferred.resolve(responseData);
            },
            error: function (errorData) {
                deferred.reject(errorData);
            }
        });

        return deferred.promise;
    }

    return {
        getJson: makeGetRequestPromise,
        postJson: makePostRequestPromise,
        putJson: makePutRequestPromise,
        deleteJson: makeDeleteRequestPromise
    }
})();