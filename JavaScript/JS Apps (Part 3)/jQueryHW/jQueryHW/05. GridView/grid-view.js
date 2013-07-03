/// <reference path="../libs/jquery-1.10.1.js" />
var gridControls = (function ($) {
    function GridRow(args) {
        this.tr = $('<tr></tr>');
        for (var i = 0; i < args.length; i++) {
            this.tr.append('<td>' + args[i] + '</td>');
        }
    }

    GridRow.prototype = {
        constructor: GridRow,
        addNestedGridView: function (gridView) {
            gridView.render();
            this.tr.append(gridView.container);
        }
    }

    function GridHeader(args) {
        this.tr = $('<tr></tr>');
        for (var i = 0; i < args.length; i++) {
            this.tr.append('<th>' + args[i] + '</th>');
        }
    }

    function GridView(selector) {
        this.container = $(selector);
        this.header;
        this.rows = [];
    }

    GridView.prototype = {
        constructor: GridView,
        addRow: function () {
            this.rows.push(new GridRow(arguments));
        },

        addHeader: function () {
            this.header = new GridHeader(arguments);
        },

        render: function () {
            var table = $('<table></table>');
            table.append(this.header.tr);
            for (var i = 0; i < this.rows.length; i++) {
                table.append(this.rows[i].tr);
            }

            this.container.remove('table').append(table);
        }
    }

    return {
        createGridView: function (selector) {
            return new GridView(selector);
        }
    }
})(jQuery);