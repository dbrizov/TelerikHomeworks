/// <reference path="jquery-2.0.3.js" />
/// <reference path="class.js" />
var controls = controls || {};
(function (c) {
	var TableView = Class.create({
		init: function (itemsSource, displayIn) {
			if (!(itemsSource instanceof Array)) {
				throw "The itemsSource of a ListView must be an array!";
			}

			this.itemsSource = itemsSource;
			this.displayIn = displayIn;
		},

		render: function (template) {
		    var table = document.createElement("table");

		    if (this.displayIn === "rows") {
		        for (var i = 0; i < this.itemsSource.length; i += 1) {
		            var tableRow = document.createElement("tr");

		            var list = document.createElement("ul");
		            var listItem = document.createElement("li");
		            var item = this.itemsSource[i];
		            listItem.innerHTML = template(item);
		            list.appendChild(listItem);

		            var tableData = document.createElement("td");
		            tableData.appendChild(list);

		            tableRow.appendChild(tableData);

		            table.appendChild(tableRow);
		        }
		    }
		    else {
		        var tableRow = document.createElement("tr");
		        for (var i = 0; i < this.itemsSource.length; i += 1) {
		            var list = document.createElement("ul");
		            var listItem = document.createElement("li");
		            var item = this.itemsSource[i];
		            listItem.innerHTML = template(item);
		            list.appendChild(listItem);

		            var tableData = document.createElement("td");
		            tableData.appendChild(list);

		            tableRow.appendChild(tableData);
		        }

		        table.appendChild(tableRow);
		    }

		    return table.outerHTML;
		}
	});

	c.getTableView = function (itemsSource, displayIn) {
	    return new TableView(itemsSource, displayIn);
	}
}(controls || {}));