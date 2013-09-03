/// <reference path="data-persister.js" />
/// <reference path="../libs/require.js" />
/// <reference path="../libs/class.js" />

define(["data-persister", "class", "mustache", "jquery"], function (DataPersister, Class, Mustache, $) {
    var Controller = Class.create({
        init: function (rootUrl) {
            this.dataPersister = new DataPersister(rootUrl);
        },

        loadStudents: function (selector) {
            var studentTemplate = Mustache.compile(document.getElementById("student-template").innerHTML);
            var studentsContainer = $(selector);

            this.dataPersister.studentPersister.getStudents()
                .then(function (students) {
                    for (var i in students) {
                        var studentHtml = studentTemplate(students[i]);
                        studentsContainer.append(studentHtml);
                    }
                }, function (errorData) {
                    studentsContainer.append(errorData.toString());
                });
        },

        loadMarksOfStudent: function (selector, studentId) {
            var markTemplate = Mustache.compile(document.getElementById("mark-template").innerHTML);
            var marksContainer = $(selector);
            marksContainer.html("");

            this.dataPersister.studentPersister.getMarksOfStudent(studentId)
                .then(function (marks) {
                    for (var i in marks) {
                        var markHtml = markTemplate(marks[i]);
                        marksContainer.append(markHtml);
                    }
                });
        }
    });

    return Controller;
});