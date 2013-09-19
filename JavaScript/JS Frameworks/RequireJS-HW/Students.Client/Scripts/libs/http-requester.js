﻿/// <reference path="jquery-1.10.1.js" />
/// <reference path="require.js" />
/// <reference path="q.js" />

define(["jquery", "q"], function ($, q) {
    var makeGetRequestPromise = function (url) {
        var deferred = q.defer();

        $.ajax({
            url: url,
            type: "get",
            contentType: "application/json",
            timeout: 5000,
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
        var deferred = q.defer();

        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: "post",
            contentType: "application/json",
            timeout: 5000,
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
        postJson: makePostRequestPromise
    }
});