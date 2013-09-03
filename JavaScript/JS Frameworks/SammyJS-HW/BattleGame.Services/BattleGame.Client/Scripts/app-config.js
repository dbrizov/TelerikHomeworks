/// <reference path="libs/require.js" />
/// <reference path="libs/jquery-1.10.2.js" />
/// <reference path="libs/http-requester.js" />
/// <reference path="libs/class.js" />
/// <reference path="libs/q.js" />

(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-1.10.2",
            "q": "libs/q",
            "class": "libs/class",
            "http-requester": "libs/http-requester",
            "mustache": "libs/mustache",
            "sammy": "libs/sammy",
            "crypto": "libs/crypto-sha1",
            "ui-controller": "app/ui-controller",
            "data-persister": "app/data-persister"
        }
    });

    require(["jquery", "sammy", "data-persister", "ui-controller"],
        function ($, sammy, DataPersister, UserInterfaceController) {
            var persister = new DataPersister("http://localhost:22954/api/");
            var ui = new UserInterfaceController();

            var app = sammy("#wrapper", function () {
                this.get("#/", function () {
                    if (persister.isUserLoggedIn()) {
                        window.location = "#/user/" + persister.nickname();
                    }
                    else {
                        window.location = "#/login"
                    }
                });

                this.get("#/login", function () {
                    ui.loadLoginForm("#user-form");
                    $("#opened-games").html("");
                    $("#active-games").html("");
                    $("#game-field").html("");
                });

                this.get("#/register", function () {
                    ui.loadRegisterForm("#user-form");
                });

                this.get("#/user/:nickname", function () {
                    ui.loadLogoutForm("#user-form", this.params["nickname"]);
                    $("#game-field").html("");

                    refreshActiveGame();
                    refreshOpenedGames();
                });

                this.get("#/game/:id", function () {
                    ui.loadLogoutForm("#user-form", persister.nickname());

                    $("#opened-games").html("");
                    $("#active-games").html("");
                });
            });

            app.run("#/");

            var wrapper = $("#wrapper");

            wrapper.on("click", "#btn-go-to-register", function (ev) {
                ev.preventDefault();
                window.location = "#/register";
            });

            wrapper.on("click", "#btn-login", function (ev) {
                ev.preventDefault();

                var user = {
                    username: $("#tb-username").val(),
                    password: $("#tb-password").val()
                };

                persister.users.login(user).then(
                    function (data) {
                        window.location = "#/user/" + data.nickname;
                    },
                    function (errData) {
                        $("#user-form").append("<span style='color: red'>Invalid username or password</span>");
                    });
            });

            wrapper.on("click", "#btn-logout", function (ev) {
                ev.preventDefault();

                persister.users.logout();

                window.location = "#/login";
            });

            wrapper.on("click", "#btn-register", function (ev) {
                ev.preventDefault();

                var password = $("#tb-password").val();
                var confirmedPassword = $("#tb-confirm-password").val();

                if (password !== confirmedPassword) {
                    console.log("The password doesn't match");
                }
                else {
                    var user = {
                        username: $("#tb-username").val(),
                        nickname: $("#tb-nickname").val(),
                        password: password
                    };

                    persister.users.register(user).then(
                        function (data) {
                            window.location = "#/user/" + data.nickname;
                        },
                        function (errData) {
                            console.log(errData);
                        });
                }
            });

            wrapper.on("click", "#btn-refresh-opened-games", function (ev) {
                ev.preventDefault();
                refreshOpenedGames();
            });

            wrapper.on("click", "#btn-refresh-active-games", function (ev) {
                ev.preventDefault();
                refreshActiveGame();
            });

            wrapper.on("click", "#opened-games td", function (ev) {
                var joinGameButton = $("<button id='btn-join-game'>Join</button>");
                $("#btn-join-game").remove();
                $(this).parent().append(joinGameButton);
            });

            wrapper.on("click", "#opened-games #btn-join-game", function (ev) {
                ev.preventDefault();
                console.log(this);

                var game = {
                    id: $(this).parent().attr("id")
                };

                persister.games.joinGame(game).then(
                    function () {
                        refreshActiveGame();
                        refreshOpenedGames();
                    });

                $(this).remove();
            });

            wrapper.on("click", "#opened-games #btn-create-game", function (ev) {
                ev.preventDefault();

                var game = {
                    title: $(this).prev().val()
                };

                persister.games.createGame(game).then(
                    function () {
                        refreshActiveGame();
                        $(ev.target).prev().val("");
                    },
                    function (errData) {
                        alert("The title of the games must be at least 6 chars long");
                    });
            });

            wrapper.on("click", "#active-games td", function (ev) {
                if ($($(this).parent().children()[1]).text() === persister.nickname() &&
                        $($(this).parent().children()[2]).text() === "full") {

                    var startGameButton = $("<button id='btn-start-game'>Start</button>");
                    $("#btn-start-game").remove();
                    $(this).parent().append(startGameButton);
                }
                else if ($($(this).parent().children()[2]).text() === "in-progress") {

                    var showFieldButton = $("<button id='btn-show-field'>Field</button>");
                    $("#btn-show-field").remove();
                    $(this).parent().append(showFieldButton);
                }
            });

            wrapper.on("click", "#active-games #btn-start-game", function (ev) {
                ev.preventDefault();

                var gameId = $(this).parent().attr("id");

                persister.games.startGame(gameId).then(
                    function () {
                        refreshActiveGame();
                    },
                    function (errData) {
                        alert(errData);
                    });

                $(this).remove();
            });

            wrapper.on("click", "#active-games #btn-show-field", function (ev) {
                ev.preventDefault();

                var gameId = $(this).parent().attr("id");
                persister.games.getField(gameId).then(
                    function (field) {
                        ui.loadGameField("#game-field", field);
                        location = "#/game/" + gameId;
                    });
            });

            function refreshActiveGame() {
                persister.games.activeGames().then(
                        function (games) {
                            ui.loadActiveGames("#active-games", games);
                        },
                        function (errData) {
                            console.log(errData);
                        });
            }

            function refreshOpenedGames() {
                persister.games.openedGames().then(
                    function (games) {
                        ui.loadOpenedGames("#opened-games", games);
                    },
                    function (errData) {
                        console.log(errData);
                    });s
            }
        });
}());