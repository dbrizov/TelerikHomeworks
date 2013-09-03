/// <reference path="../libs/mustache.js" />

var partials = (function () {
    var loginHtml =
        '<form>' +
            '<label for="tb-username">Username: </label>' +
            '<input type="text" id="tb-username" />' +

            '<label for="tb-password">Password: </label>' +
            '<input type="password" id="tb-password" />' +

            '<a href="#/user" id="btn-login">Login</a>' +
        '</form>';

    var registerHtml =
        '<form>' +
            '<label for="tb-username">Username: </label>' +
            '<input type="text" id="tb-username" />' +

            '<label for="tb-display-name">Display Name: </label>' +
            '<input type="text" id="tb-display-name" />' +

            '<label for="tb-password">Password: </label>' +
            '<input type="password" id="tb-password" />' +

            '<a href="#/user" id="btn-register">Register</a>' +
        '</form>';

    var userInfoHtml =
        '<span id="display-name">{{displayName}}</span>';

    var userInfoTemplate = Mustache.compile(userInfoHtml);

    var postsHtml =
        '{{#.}}' +
            '<div>' +
                '<h2>{{title}}</h2>' +
                '<p>{{text}}</p>' +
                '{{#tags}}' +
                '<span>{{.}}</span>' +
                '{{/tags}}' +
                '<div><strong>Posted by: {{postedBy}}</strong></div>' +
            '</div>' +
        '{{/.}}';

    var postsTemplate = Mustache.compile(postsHtml);

    return {
        loginHtml: loginHtml,
        registerHtml: registerHtml,
        userInfoTemplate: userInfoTemplate,
        postsTemplate: postsTemplate
    }
})();