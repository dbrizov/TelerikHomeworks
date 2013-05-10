(function loadTopFiveScores() {
    function Pair(key, value) {
        this.key = key;
        this.value = value;
    }

    var allScores = [];
    for (var prop in localStorage) {
        allScores.push(new Pair(prop, localStorage[prop]));
    }

    // sort the scores
    for (var i = 0; i < allScores.length - 1; i++) {
        var minScoreIndex = i;
        for (var j = i + 1; j < allScores.length; j++) {
            if (allScores[j].value < allScores[minScoreIndex].value) {
                minScoreIndex = j
            }
        }

        var temp = allScores[i];
        allScores[i] = allScores[minScoreIndex];
        allScores[minScoreIndex] = temp;
    }

    // load the top five scores
    var rankList = document.getElementById("rank-list");
    var length;
    if (allScores.length < 5) {
        length = allScores.length;
    }
    else {
        length = 5;
    }

    for (var i = 0; i < length; i++) {
        var div = document.createElement("div");
        div.innerHTML = allScores[i].key + ": " + allScores[i].value;
        rankList.appendChild(div);
    }
})();

var timer = document.getElementById("timer");

var firstDate;
var firstDateHours;
var firstDateMinutes;
var firstDateSeconds;

var interval;
function startTimer() {
    if (!firstDate) {
        firstDate = new Date();
        firstDateHours = firstDate.getHours();
        firstDateMinutes = firstDate.getMinutes();
        firstDateSeconds = firstDate.getSeconds();
        interval = setInterval(updateTimer, 100);
    }
}

var trash = document.getElementsByClassName("trash");
for (var i = 0; i < trash.length; i++) {
    trash[i].addEventListener("dragstart", startTimer);
}

function stopTimer() {
    clearInterval(interval);
}

function saveScore(score) {
    var name = prompt("nickname:");
    if (localStorage[name]) {
        if (localStorage[name] > score) {
            localStorage[name] = score;
        }
    }
    else {
        localStorage[name] = score;

        //var div = document.createElement("div");
        //div.innerHTML = name + ": " + score;

        //var rankList = document.getElementById("rank-list");
        //rankList.appendChild(div);
    }

    document.location.reload(true);
}

function updateTimer() {
    var secondDate = new Date();
    var elapsedHours = secondDate.getHours() - firstDateHours;
    var elapsedMinutes = secondDate.getMinutes() - firstDateMinutes;
    var elapsedSeconds = secondDate.getSeconds() - firstDateSeconds;

    if (elapsedHours < 10) {
        elapsedHours = '0' + elapsedHours;
    }

    if (elapsedMinutes < 10) {
        elapsedMinutes = "0" + elapsedMinutes;
    }

    if (elapsedSeconds < 10) {
        elapsedSeconds = '0' + elapsedSeconds;
    }

    timer.innerHTML = elapsedHours + ':' + elapsedMinutes + ':' + elapsedSeconds;

    if (trash.length === 0) {
        stopTimer();

        var score = timer.innerHTML;
        saveScore(score);
    }
}