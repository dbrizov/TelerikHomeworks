/// <reference path="../libs/jquery-1.10.1.js" />
var Slider = (function () {
    function slider(width, height, selector) {
        var that = this;
        this._width = width;
        this._height = height;
        this._slides = [];
        this._currentSlideIndex = -1;
        this._frame = $(document.createElement("div")).css({
            "background-color": "#ffe",
            "box-shadow": "0px 0px 15px #555",
            "width": this._width + "px",
            "height": this._height + "px",
            "margin": "10px",
            "padding": "10px",
            "word-wrap": "break-word",
            "float": "left",
            "overflow": "hidden"
        });

        this._prevButton = $("<button>prev</button>").css({
            "color": "#fff",
            "background-color": "#222",
            "font-weight": "bold",
            "margin-right": "10px",
            "float": "left",
            "margin-top": (this._height / 2) + "px"
        });

        this._nextButton = $("<button>next</button>").css({
            "color": "#fff",
            "background-color": "#222",
            "font-weight": "bold",
            "margin-left": "10px",
            "float": "left",
            "margin-top": (this._height / 2) + "px"
        });

        this._next = function () {
            if (that._slides[that._currentSlideIndex + 1]) {
                that._currentSlideIndex += 1;
                that._frame.html(that._slides[that._currentSlideIndex]);
            }
        }

        this._prev = function () {
            if (that._slides[that._currentSlideIndex - 1]) {
                that._currentSlideIndex -= 1;
                that._frame.html(that._slides[that._currentSlideIndex]);
            }
        }

        this._nextButton.on("click", this._next);
        this._prevButton.on("click", this._prev);

        this._container = $(selector);
        this._container.append(this._prevButton);
        this._container.append(this._frame);
        this._container.append(this._nextButton);

        this._interval = setInterval(this._next, 5000);

        this._frame.on("mouseenter", function () {
            clearInterval(that._interval);
        });

        this._frame.on("mouseleave", function () {
            that._interval = setInterval(that._next, 5000);
        });
    }

    slider.prototype = {
        addSlide: function (slide) {
            this._slides.push(slide);
            this._currentSlideIndex = 0;
            this._frame.html(this._slides[this._currentSlideIndex]);
        }
    }

    return slider;
})();