var images = 
    [
        "fish.jpg",
        "fox.jpg",
        "frog.jpg",
        "horse.jpg",
        "jaguar.jpg",
        "tiger.jpg",
        "puppy.jpg",
        "seabird.jpg",
        "snake.jpg",
        "tiger2.jpg",
        "wolf.jpg"
    ]

var img = document.getElementsByTagName("img")[0];
var prefix = "images/";

var frame = document.getElementById("carousel-frame");
frame.appendChild(img);

var previousButton = document.getElementById("prev");
previousButton.addEventListener("click", showPreviousImage, false);

var nextButton = document.getElementById("next");
nextButton.addEventListener("click", showNextImage, false);

var imgIndex = 0;

function showPreviousImage() {
    if (imgIndex === 0) {
        imgIndex = images.length - 1;
    }
    else {
        imgIndex--;
    }

    img.src = prefix + images[imgIndex];
}


function showNextImage() {
    if (imgIndex === images.length - 1) {
        imgIndex = 0;
    }
    else {
        imgIndex++;
    }

    img.src = prefix + images[imgIndex];
}