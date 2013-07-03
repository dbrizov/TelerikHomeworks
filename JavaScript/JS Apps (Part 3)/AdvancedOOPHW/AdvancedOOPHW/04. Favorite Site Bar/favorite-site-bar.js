var Url = Class.create({
    init: function (title, url) {
        this.title = title;
        this.url = url;
    },

    display: function (selector) {
        var container = document.querySelector(selector);
        var div = document.createElement("div");

        var a = document.createElement("a");
        a.href = this.url;
        a.innerHTML = this.title;
        a.target = "_blank";

        div.appendChild(a);
        container.appendChild(div);
    }
});

var Folder = Class.create({
    init: function (title, urls) {
        this.title = title;
        this.urls = urls;
    },

    display: function (selector) {
        var container = document.querySelector(selector);

        var div = document.createElement("div");
        div.innerHTML = "[" + this.title + "]";
        div.id = this.title.toLowerCase().replace(/\s+/g, "-");

        container.appendChild(div);

        for (var i = 0, len = this.urls.length; i < len; i++) {
            this.urls[i].display("#" + div.id);
        }
    }
});

var FavoriteSiteBar = Class.create({
    init: function (folders, urls) {
        this.folders = folders;
        this.urls = urls;
    },

    display: function (selector) {
        var container = document.querySelector(selector);

        for (var i = 0, len = this.folders.length; i < len; i++) {
            this.folders[i].display(selector);
        }

        var otherUrls = new Folder("Other", this.urls);
        otherUrls.display(selector);
    }
});

// The demo is in the index.html