/// <reference path="../libs/require.js" />
/// <reference path="../libs/class.js" />
/// <reference path="../libs/jquery-1.10.2.js" />
/// <reference path="templates.js" />
/// <reference path="../libs/mustache.js" />

define(["jquery", "class", "mustache"], function ($, Class, mustache) {
    var UserInterfaceController = Class.create({
        init: function () {
        },

        loadLoginForm: function (selector) {
            $.ajax({
                url: "Scripts/app/templates/login-form.html",
                type: "GET",
                accept: "text/html",
                success: function (html) {
                    template = mustache.compile(html);
                    $(selector).html(template());
                }
            });
        },

        loadLogoutForm: function (selector, nickname) {
            $.ajax({
                url: "Scripts/app/templates/logout-form.html",
                type: "GET",
                accept: "text/html",
                success: function (html) {
                    template = mustache.compile(html);
                    $(selector).html(template(nickname));
                }
            });
        },

        loadRegisterForm: function (selector) {
            $.ajax({
                url: "Scripts/app/templates/register-form.html",
                type: "GET",
                accept: "text/html",
                success: function (html) {
                    template = mustache.compile(html);
                    $(selector).html(template());
                }
            });
        },

        loadOpenedGames: function (selector, openedGames) {
            $.ajax({
                url: "Scripts/app/templates/opened-games.html",
                type: "GET",
                accept: "text/html",
                success: function (html) {
                    template = mustache.compile(html);
                    $(selector).html(template(openedGames))
                }
            });
        },

        loadActiveGames: function (selector, activeGames) {
            $.ajax({
                url: "Scripts/app/templates/active-games.html",
                type: "GET",
                accept: "text/html",
                success: function (html) {
                    template = mustache.compile(html);
                    $(selector).html(template(activeGames));
                }
            });
        },

        loadGameField: function (selector, field) {
            var arr = new Array();
            for (var i = 0; i < 9; i += 1) {
                arr.push(new Array());
                for (var j = 0; j < 9; j += 1) {
                    arr[i].push("c");
                }
            }

            var red = field.red;
            for (var i = 0, len = red.units.length; i < len; i += 1) {
                var x = red.units[i].position.x;
                var y = red.units[i].position.y;
                var type = red.units[i].type;

                arr[x][y] = "red-" + type;
            }

            var blue = field.blue;
            for (var i = 0, len = blue.units.length; i < len; i += 1) {
                var x = blue.units[i].position.x;
                var y = blue.units[i].position.y;
                var type = blue.units[i].type;

                arr[x][y] = "blue-" + type;
            }

            var table = '<table>';
            for (var i = 0; i < 9; i += 1) {

                table += '<tr>';
                for (var j = 0; j < 9; j += 1) {
                    if (arr[i][j] === 'c') {
                        table += '<td class="white">C</td>';
                    }
                    else if (arr[i][j] === 'red-warrior') {
                        table += '<td class="red">W</td>';
                    }
                    else if (arr[i][j] === 'red-ranger') {
                        table += '<td class="red">R</td>';
                    }
                    else if (arr[i][j] === 'blue-warrior') {
                        table += '<td class="blue">W</td>';
                    }
                    else if (arr[i][j] === 'blue-ranger') {
                        table += '<td class="blue">R</td>';
                    }
                }

                table += '</tr>';
            }

            table += '</table>';
            console.log(table);

            var redNickname = '<span class="red">' + red.nickname + '</span>';
            var blueNickname = '<span class="blue">' + blue.nickname + '<span>';
            var inTurn;

            if (field.inTurn === "red") {
                inTurn = '<div class="red">In Turn: ' + red.nickname + '</div>';
            }
            else {
                inTurn = '<div class="blue">In Turn: ' + blue.nickname + '</div>';
            }

            table = redNickname + " : " + blueNickname + inTurn + table;

            $(selector).html(table);
        }
    });

    return UserInterfaceController;
});