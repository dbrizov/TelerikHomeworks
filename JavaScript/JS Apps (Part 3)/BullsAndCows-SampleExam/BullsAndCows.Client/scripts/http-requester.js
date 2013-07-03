/// <reference path="jquery-1.10.1.js" />
var httpRequester = (function () {
    var makeGetRequest = function (url, success, error) {
        $.ajax({
            url: url,
            type: "get",
            contentType: "application/json",
            timeout: 10000,
            success: success,
            error: error
        });
    }

    var makePostRequest = function (url, data, success, error) {
        $.ajax({
            url: url,
            data: JSON.stringify(data),
            type: "post",
            contentType: "application/json",
            timeout: 10000,
            success: success,
            error: error
        });
    }

    return {
        getJSON: makeGetRequest,
        postJSON: makePostRequest
    }
})();