/// <reference path="jquery-1.10.1.js" />

var userInterface = (function () {
    function getLoginFormUI() {
        var html =
            '<div id="login-form">' +
                '<label for="tb-login-username">Username: </label>' +
                '<input type="text" id="tb-login-username" />' +
                '<br />' +
                '<label for="tb-login-password">Password: </label>' +
                '<input type="password" id="tb-login-password" />' +
                '<br />' +
                '<button id="btn-login">Login</button>' +
                '<br />' +
                '<button id="btn-signup">Sign Up</button>' +
            '</div>';

        return html;
    }

    function getRegisterFormUI() {
        var html =
            '<div id="register-form">' +
                '<label for="tb-register-username">Username: </label>' +
                '<input type="text" id="tb-register-username" />' +
                '<br />' +
                '<label for="tb-register-nickname">Nickname: </label>' +
                '<input type="text" id="tb-register-nickname" />' +
                '<br />' +
                '<label for="tb-register-password">Password: </label>' +
                '<input type="password" id="tb-register-password" />' +
                '<br />' +
                '<button id="btn-register">Register</button>' +
            '</div>';

        return html;
    }

    function getGameUI(nickname) {
        var html =
            '<div id="game-ui">' +
                '<div id="logout-form">' +
                    '<div>Welcome, ' + nickname + '</div>' +
                    '<button id="btn-logout">Logout</button>' +
                '</div>' +

                '<div id="create-game-form">' +
                    '<label for="tb-game-title">*Title: </label>' +
                    '<input type="text" id="tb-game-title" />' +
                    '<label for="tb-game-number">*Number: </label>' +
                    '<input type="text" id="tb-game-number" />' +
                    '<label for="tb-game-password">Password: </label>' +
                    '<input type="text" id="tb-game-password" />' +
                    '<button id="btn-create-game">Create</button>' +
                '</div>' +

                '<div id="join-game-form">' +
                    '<h2>Opened games</h2>' +
                    '<div id="opened-games"></div>' +
                '</div>' +

                '<div id="my-active-games">' +
                    '<h2>My active games</h2>' +
                '</div>' +

                '<div id="game-state">' +
                    '<div id="game-state-guesses"></div>' +
                '</div>' +
            '</div>';

        return html;
    }

    function getOpenedGamesUI(games) {
        var table =
            '<table>' +
                '<tr>' +
            	    '<th>ID</th>' +
            	    '<th>Title</th>' +
            	    '<th>Creator</th>' +
                '</tr>';

        for (var i = 0; i < games.length; i += 1) {
            var id = games[i].id;
            var title = games[i].title;
            var creatorNickname = games[i].creatorNickname;

            table +=
                '<tr>' +
            	    '<td>' + id + '</td>' +
            	    '<td>' + title + '</td>' +
            	    '<td>' + creatorNickname + '</td>' +
                '</tr>';
        }

        table += '</table><button id="btn-refresh">Refresh</button>'
        return table;
    }

    function getActiveGamesUI(games) {
        var table =
            '<table>' +
                '<tr>' +
            	    '<th>ID</th>' +
            	    '<th>Title</th>' +
            	    '<th>Creator</th>' +
                    '<th>Status</th>' +
                '</tr>';

        for (var i = 0; i < games.length; i += 1) {
            var id = games[i].id;
            var title = games[i].title;
            var creatorNickname = games[i].creatorNickname;
            var status = games[i].status;

            table +=
                '<tr>' +
            	    '<td>' + id + '</td>' +
            	    '<td>' + title + '</td>' +
            	    '<td>' + creatorNickname + '</td>' +
                    '<td>' + status + '</td>' +
                '</tr>';
        }

        table += '</table>';
        return table;
    }

    function getJoinGameButton() {
        var html =
            '<button id="btn-join-game">Join</button>' +
            '<input style="width: 75px" type="text" placeholder="number" id="tb-number-input" />';

        return html;
    }

    function getStartGameButton() {
        var html = '<button id="btn-start-game">Start</button>';
        return html;
    }

    function getMakeGuessButton() {
        var html =
            '<button id="btn-make-guess">Guess</button>' +
            '<input style="width: 75px" type="text" placeholder="number" id="tb-guess-input" />';

        return html;
    }

    function getGameStateUI(data) {
        var html =
            '<div>id: ' + data.id + '</div>' +
            '<div>title: ' + data.title + '</div>' +
            '<div>blue: ' + data.blue + '</div>' +
            '<div>red: ' + data.red + '</div>' +
            '<div>inTurn: ' + data.inTurn + '</div>';

        return html;
    }

    function getGameGuessesUI(data) {
        var html = '<div style="display: inline-block">Blue guesses: ';
        for (var i = 0; i < data.blueGuesses.length; i += 1) {
            html +=
                '<div>' +
                    ' number: ' + data.blueGuesses[i].number +
                    ' bulls: ' + data.blueGuesses[i].bulls +
                    ' cows: ' + data.blueGuesses[i].cows +
                '</div>';
        }

        html += '</div><br /><div style="display: inline-block">Red guesses: ';

        for (var i = 0; i < data.redGuesses.length; i += 1) {
            html +=
                '<div>' +
                    ' number: ' + data.redGuesses[i].number +
                    ' bulls: ' + data.redGuesses[i].bulls +
                    ' cows: ' + data.redGuesses[i].cows +
                '</div>';
        }

        return html + "</div>";
    }

    return {
        getLoginFormUI: getLoginFormUI,
        getRegisterFormUI: getRegisterFormUI,
        getGameUI: getGameUI,
        getOpenedGamesUI: getOpenedGamesUI,
        getJoinGameButton: getJoinGameButton,
        getActiveGamesUI: getActiveGamesUI,
        getStartGameButton: getStartGameButton,
        getMakeGuessButton: getMakeGuessButton,
        getGameStateUI: getGameStateUI,
        getGameGuessesUI: getGameGuessesUI
    }
})();