var textArea = document.getElementById("text-area");

function setBackgroundColor() {
    return textArea.style.backgroundColor =
        document.getElementsByName('background')[0].value;
}
function setFontColor() {
    return textArea.style.color =
        document.getElementsByName('font')[0].value;

}