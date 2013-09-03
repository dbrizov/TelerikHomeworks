/// <reference path="../libs/jquery-1.10.2.js" />
/// <reference path="../libs/class.js" />
/// <reference path="../libs/mustache.js" />
/// <reference path="../libs/require.js" />

define(["class", "jquery", "mustache"], function (Class) {
    var ComboBox = Class.create({
        init: function (items) {
            this.items = items;
        },

        render: function (mustacheTemplate) {
            var itemsContainer = $(document.createElement("ul"));
            itemsContainer.addClass("collapsed");
            itemsContainer.css({
                "border": "2px solid black",
                "width": "200px",
                "overflow": "hidden",
                "text-align": "center",
                "padding": "2px"
            });

            for (var i in this.items) {
                var listItem = $(document.createElement("li"));
                var listItemHtml = mustacheTemplate(this.items[i]);
                listItem.html(listItemHtml);
                listItem.css({
                    "display": "none",
                    "cursor": "pointer"
                });

                listItem.hover(function () {
                    if (itemsContainer.hasClass("expanded")) {
                        $(this).css("background-color", "red");
                    }
                }, function () {
                    if (itemsContainer.hasClass("expanded") && 
                            this.style.backgroundColor === "red") {
                        $(this).css("background-color", "white");
                    }
                });

                itemsContainer.append(listItem);
            }

            itemsContainer
                .children()
                .first()
                .css({
                    "display": "block",
                    "background-color": "#ff6a00"
                });

            itemsContainer.on("click", "li", function (ev) {
                var parent = $(this).parent();

                if (parent.hasClass("collapsed")) {
                    parent.children().show("slow");
                    parent.removeClass("collapsed").addClass("expanded");
                }
                else if (parent.hasClass("expanded")) {
                    parent.children().hide("fast").css("background-color", "#fff");
                    parent.removeClass("expanded").addClass("collapsed");
                    $(this).css({
                        "display": "block",
                        "background-color": "#ff6a00"
                    }).show("fast");;
                }
            });

            return itemsContainer;
        }
    });

    return ComboBox;
});