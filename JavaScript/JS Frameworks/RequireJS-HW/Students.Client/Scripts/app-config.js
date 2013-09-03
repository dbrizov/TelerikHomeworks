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
            "controller": "app/controller",
            "data-persister": "app/data-persister"
        }
    });

    require(["controller"], function (Controller) {
        var rootUrl = "http://localhost:3438/api/";
        var controller = new Controller(rootUrl);

        controller.loadStudents("#students-container");

        // attach event handlers
        var studentsContainer = $("#students-container");
        studentsContainer.on("click", "div", function () {
            var studentId = this.id;
            controller.loadMarksOfStudent("#marks-container", studentId);
        });
    });
}());