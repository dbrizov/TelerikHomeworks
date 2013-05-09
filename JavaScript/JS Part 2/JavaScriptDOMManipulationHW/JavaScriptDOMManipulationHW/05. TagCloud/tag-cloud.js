function generateTagCloud(tags, minFontSize, maxFontSize) {
    var tagCounts = [];

    // generating a dictionary with key(the tag) and value(the number of occurrences)
    for (var i = 0; i < tags.length; i++) {
        if (tagCounts[tags[i]]) {
            tagCounts[tags[i]]++;
        }
        else {
            tagCounts[tags[i]] = 1;
        }
    }

    // finding the minTagCount and maxTagCount
    var minTagCount = Number.MAX_VALUE;
    var maxTagCount = Number.MIN_VALUE;
    for (var i in tagCounts) {
        if (tagCounts[i] < minTagCount) {
            minTagCount = tagCounts[i];
        }

        if (tagCounts[i] > maxTagCount) {
            maxTagCount = tagCounts[i];
        }
    }

    // generating the tagCloud
    var tagCloud = document.createElement("div");
    tagCloud.style.width = "500px";
    tagCloud.style.border = "1px solid black";
    tagCloud.style.wordWrap = "break-word";
    tagCloud.style.borderRadius = "10px";

    // http://en.wikipedia.org/wiki/Tag_cloud - the formula I use for the font size and the color
    var deltaCount = maxTagCount - minTagCount;
    var deltaFontSize = maxFontSize - minFontSize;
    for (var i in tagCounts) {
        var span = document.createElement("span");

        span.style.fontSize =
            (Math.floor((deltaFontSize * (tagCounts[i] - minTagCount)) / deltaCount) + minFontSize) + "px";
        span.innerHTML = i + "&nbsp;";

        var colorFactor =
            255 - (Math.floor((200 * (tagCounts[i] - minTagCount)) / deltaCount) + 55);
        span.style.color = "rgb(" + colorFactor + "," + colorFactor + "," + colorFactor + ")";

        tagCloud.appendChild(span);
    }

    return tagCloud;
}

function onGenerateTagCloudButtonClick() {
    var text = document.getElementById("text-area").value
    var tags = text.split(/[\s]+/);

    var tagCloud = generateTagCloud(tags, 17, 60);
    var divTagCloud = document.getElementById("tag-cloud");
    
    while (divTagCloud.firstChild) {
        divTagCloud.removeChild(divTagCloud.firstChild);
    }

    divTagCloud.appendChild(tagCloud);
}