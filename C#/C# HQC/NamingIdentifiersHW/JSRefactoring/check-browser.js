function onClickCheckIfBrowserIsMozilla(event, args) {
    var pageWindow = window;
    var browser = pageWindow.navigator.appCodeName;
    var isMozzila = (browser == "Mozilla");

    if (isMozzila) {
        alert("Yes");
    }
    else {
        alert("No");
    }
}
