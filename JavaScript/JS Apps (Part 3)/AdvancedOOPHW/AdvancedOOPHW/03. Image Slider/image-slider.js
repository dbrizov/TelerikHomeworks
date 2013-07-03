var ImageSlider = {
    _Image: {
        init: function (title, url) {
            this.title = title;
            this.url = url;
        }
    },

    _images: [],

    _thumbnailIndex: 0,

    _changeBigImage: function (ev) {
        ev.preventDefault();
        ev.stopPropagation();

        var bigImage = document.getElementById("big-image");
        bigImage.src = ev.target.src;
    },

    _next: function (ev) {
        ev.preventDefault();
        ev.stopPropagation();

        if (ImageSlider._thumbnailIndex != ImageSlider._images.length - 2) {
            ImageSlider._thumbnailIndex++;
            var rightImg = document.getElementById("right-image");
            rightImg.src = ImageSlider._images[ImageSlider._thumbnailIndex + 1].url;

            var leftImg = document.getElementById("left-image");
            leftImg.src = ImageSlider._images[ImageSlider._thumbnailIndex].url;
        }
    },

    _prev: function (ev) {
        ev.preventDefault();
        ev.stopPropagation();

        if (ImageSlider._thumbnailIndex != 0) {
            ImageSlider._thumbnailIndex--;
            var rightImg = document.getElementById("right-image");
            rightImg.src = ImageSlider._images[ImageSlider._thumbnailIndex + 1].url;

            var leftImg = document.getElementById("left-image");
            leftImg.src = ImageSlider._images[ImageSlider._thumbnailIndex].url;
        }
    },

    addImage: function (title, url) {
        var image = Object.create(this._Image);
        image.init(title, url);
        this._images.push(image);
    },

    appendTo: function (selector) {
        var container = document.querySelector(selector);

        var bigImage = document.createElement("img");
        bigImage.id = "big-image";
        bigImage.style.margin = "auto";
        bigImage.style.width = "500px";
        bigImage.style.height = "350px";
        bigImage.style.display = "block";
        bigImage.border = "1px solid black";

        var prevButton = document.createElement("button");
        prevButton.addEventListener("click", this._prev, false);
        prevButton.innerHTML = "Prev";

        var nextButton = document.createElement("button");
        nextButton.addEventListener("click", this._next, false);
        nextButton.innerHTML = "Next";

        var leftThumbnail = document.createElement("a");
        leftThumbnail.href = "#";
        var leftImg = document.createElement("img");
        leftImg.addEventListener("click", this._changeBigImage, false);
        leftImg.id = "left-image";
        leftImg.style.width = "100px";
        leftImg.style.height = "80px";
        leftThumbnail.appendChild(leftImg);

        if (this._images.length > 0) {
            leftImg.src = this._images[this._thumbnailIndex].url;
        }

        var rightThumbnail = document.createElement("a");
        rightThumbnail.href = "#";
        var rightImg = document.createElement("img");
        rightImg.addEventListener("click", this._changeBigImage, false);
        rightImg.id = "right-image";
        rightImg.style.width = "100px";
        rightImg.style.height = "80px";
        rightThumbnail.appendChild(rightImg);

        if (this._images.length > 1) {
            rightImg.src = this._images[this._thumbnailIndex + 1].url;
        }

        var docFragment = document.createDocumentFragment();
        docFragment.appendChild(bigImage);

        var controls = document.createElement("div");
        controls.style.width = "500px";
        controls.style.textAlign = "center";
        controls.style.margin = "auto";
        controls.appendChild(prevButton);
        controls.appendChild(leftThumbnail);
        controls.appendChild(rightThumbnail);
        controls.appendChild(nextButton);

        docFragment.appendChild(controls);

        container.appendChild(docFragment);
    }
}