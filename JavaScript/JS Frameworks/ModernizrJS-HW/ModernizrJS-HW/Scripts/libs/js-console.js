function JavaScriptConsole(selector) {
    var Type = {
        normal: 0,
        error: 1,
        warning: 2
    }

    Object.freeze(Type);

    var consoleElement = document.querySelector(selector);

    var textArea = document.createElement("p");
    consoleElement.appendChild(textArea);

    var _write = function (args, type) {
        var text = document.createElement("span");
        if (args[0]) {
            if (type === Type.normal) {
                text.innerHTML = args[0].toString();
                text.style.color = "#fff";
            }
            else if (type === Type.error) {
                text.innerHTML = "Error: " + args[0].toString();
                text.style.color = "#f00";
            }
            else if (type === Type.warning) {
                text.innerHTML = "Warning: " + args[0].toString();
                text.style.color = "#ff0";
            }

            for (var i = 1; i < args.length; i++) {
                var placeHolder = "{" + (i - 1) + "}";
                text.innerHTML = text.innerHTML.replace(placeHolder, args[i].toString());
            }

            textArea.appendChild(text);
            consoleElement.scrollTop = consoleElement.scrollHeight;
        }
    }

    // Writes on the console without line break (new line)
    this.write = function () {
        _write(arguments, Type.normal);
    }

    // Writes a line in the console
    this.writeLine = function writeLine() {
        _write(arguments, Type.normal);
        textArea.appendChild(document.createElement("br"));
    }

    // Writes an error in the console
    this.writeError = function writeError() {
        _write(arguments, Type.error);
        textArea.appendChild(document.createElement("br"));
    }

    // Writes a warning in the console
    this.writeWarning = function writeWarning() {
        _write(arguments, Type.warning);
        textArea.appendChild(document.createElement("br"));
    }
}