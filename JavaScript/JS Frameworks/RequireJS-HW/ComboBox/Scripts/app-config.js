/// <reference path="libs/require.js" />
/// <reference path="libs/jquery-1.10.2.js" />
/// <reference path="libs/mustache.js" />
/// <reference path="app/combo-box.js" />

(function () {
    require.config({
        paths: {
            "jquery": "libs/jquery-1.10.2",
            "class": "libs/class",
            "mustache": "libs/mustache",
            "combo-box": "app/combo-box"
        }
    });

    require(["combo-box", "jquery", "mustache"], function (ComboBox, $, Mustache) {
        var people = [];
        for (var i = 0; i < 10; i += 1) {
            people.push(
                {
                    name: "person#" + i,
                    age: i + 20
                });
        }

        var personTemplate = Mustache.compile(document.getElementById("person-template").innerHTML);
        var comboBox = new ComboBox(people);
        var comboBoxJqueryElement = comboBox.render(personTemplate);

        var comboBoxContainer = $(document.getElementById("combo-box"));
        comboBoxContainer.append(comboBoxJqueryElement);
    });
}());