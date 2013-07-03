/// <reference path="jquery-1.10.1.js" />
/// <reference path="data-persister.js" />
/// <reference path="user-interface.js" />
/// <reference path="class.js" />

var Controller = Class.create({
    init: function (dataPersister) {
        this.persister = dataPersister;
    },

    loadUI: function (selector) {
        var that = this;
        if (that.persister.isUserLoggedIn()) {
            that.loadGameUI(selector);
        }
        else {
            that.loadLoginFormUI(selector);
        }
    },

    loadGameUI: function (selector) {
        $(selector).html(userInterface.getGameUI(this.persister.nickname()));

        // load opened games
        this.persister.game.open(function (gamesData) {
            var openedGamesTable = userInterface.getOpenedGamesUI(gamesData);
            $(selector + " #opened-games").html(openedGamesTable);
        }, function (errData) {
            $(selector + " #opened-games").html("Can't open the opened games");
        });

        // load active games
        this.loadActiveGamesUI(selector);
    },

    loadLoginFormUI: function (selector) {
        $(selector).html(userInterface.getLoginFormUI());
    },

    loadActiveGamesUI: function (selector) {
        this.persister.game.myActive(function (gamesData) {
            var myActiveGamesTable = userInterface.getActiveGamesUI(gamesData);
            $(selector + " #my-active-games")
                .html('<h2>My active games</h2>')
                .append(myActiveGamesTable);
        },
        function (errData) {
            $(selector + " #my-active-games").html("Can't open the the active games");
        });
    },

    attachUIEventHandlers: function (selector) {
        var wrapper = $(selector);
        var that = this;

        wrapper.on("click", "#btn-login", function (ev) {
            var user = {
                username: $("#tb-login-username").val(),
                password: $("#tb-login-password").val()
            };

            that.persister.user.login(user, function () {
                that.loadGameUI(selector);
            }, function () {
                $(selector).html("Invalid username or password");
            });

            return false;
        });

        wrapper.on("click", "#btn-logout", function (ev) {
            that.persister.user.logout(function () {
                that.loadLoginFormUI(selector);
            }, function () {
                $(selector).html("Internal server error, refresh the page");
            });
        });

        wrapper.on("click", "#btn-signup", function (ev) {
            $(selector).html(userInterface.getRegisterFormUI());
        });

        wrapper.on("click", "#btn-register", function (ev) {
            var user = {
                username: $("#tb-register-username").val(),
                nickname: $("#tb-register-nickname").val(),
                password: $("#tb-register-password").val()
            };

            that.persister.user.register(user, function () {
                that.loadGameUI(selector);
            }, function () {
                $(selector).html("Username or nickname already exists");
            });
        });

        wrapper.on("click", "#btn-create-game", function (ev) {
            var game = {
                title: $("#tb-game-title").val(),
                number: parseInt($("#tb-game-number").val()),
                password: $("#tb-game-password").val(),
            };

            that.persister.game.create(game, function () {
                that.loadGameUI(selector);
            }, function () {
                $(selector).html("This game already exists");
            });
        });

        wrapper.on("click", "#opened-games td", function (ev) {
            $("td.selected").removeClass("selected");
            $("#btn-join-game").remove();
            $("#tb-number-input").remove();
            $(this).siblings().andSelf().addClass("selected");
            $(this).parent().append(userInterface.getJoinGameButton());
        });

        wrapper.on("click", "#my-active-games td", function (ev) {
            $("td.selected").removeClass("selected");
            $("#btn-start-game").remove();
            $("#btn-make-guess").remove();
            $("#tb-guess-input").remove();
            $(this).siblings().andSelf().addClass("selected");
            $(this).parent()
                .append(userInterface.getStartGameButton())
                .append(userInterface.getMakeGuessButton());
        });

        wrapper.on("click", "#btn-join-game", function (ev) {
            var game = {
                gameId: parseInt($(this).parent().children().first().text()),
                number: parseInt($("#tb-number-input").val())
            }

            that.persister.game.join(game, function () {
                that.loadActiveGamesUI(selector);
            }, function () {
                $(selector).html("You cannot join that game");
            });

            $(selector + " #btn-join-game").remove();
            $(selector + " #tb-number-input").remove();
        });

        wrapper.on("click", "#btn-start-game", function (ev) {
            var gameId = parseInt($(this).parent().children().first().text());
            that.persister.game.start(gameId, function () {
                that.loadGameUI(selector);
            }, function () {
                $(selector).html("You can't start that game");
            });
        });

        wrapper.on("click", "#btn-make-guess", function (ev) {
            var guessData = {
                gameId: parseInt($(this).parent().children().first().text()),
                number: parseInt($(selector + " #tb-guess-input").val())
            }

            that.persister.guess.make(guessData, function () {
                that.persister.game.state(guessData.gameId, function (responseData) {
                    var gameStateHTML = userInterface.getGameStateUI(responseData);
                    $("#game-state").html(gameStateHTML);

                    var guessesHTML = userInterface.getGameGuessesUI(responseData);
                    $("#game-state").append('<div id="game-state-guesses"></div>');
                    $("#game-state-guesses").html(guessesHTML);
                }, function () {
                });
            }, function () {
                $(selector).html("Not your turn");
            });
        });

        wrapper.on("click", "#btn-refresh", function (ev) {
            that.loadGameUI(selector);
        });
    }
});