/// <reference path="q.min.js" />
/// <reference path="jquery-1.9.1.js" />

var HttpRequester = (function () {
    var makeGetRequestPromise = function (url) {
        var deferred = Q.defer();

        $.ajax({
            url: url,
            type: "GET",
            contentType: "application/json",
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
        putJson: makePutRequestPromise
    }
})();