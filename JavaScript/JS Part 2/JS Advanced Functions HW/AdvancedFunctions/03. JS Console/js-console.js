function JavaScriptConsole(selector) {
    var that = this;
    var consoleElement = document.querySelector(selector);

    var textArea = document.createElement("p");
    consoleElement.appendChild(textArea);
    
    var privateWrite = function write(args) {
        var text = document.createElement("span");
        text.innerHTML = args[0].toString();

        for (var i = 1; i < args.length; i++) {
            var placeHolder = "{" + (i - 1) + "}";
            text.innerHTML = text.innerHTML.replace(placeHolder, args[i].toString());
        }

        textArea.appendChild(text);
    }

    // Writes on the console without line break (new line)
    that.write = function write(args) {
        privateWrite(arguments);
    }

    // Writes a line in the console
    that.writeLine = function writeLine(args) {
        privateWrite(arguments);
        textArea.appendChild(document.createElement("br"));
    }

    // Writes an error in the console
    that.writeError = function writeError(args) {
        var errorPrefix = document.createElement("span");
        errorPrefix.innerHTML = "Error: ";
        textArea.appendChild(errorPrefix);

        privateWrite(arguments);
        textArea.appendChild(document.createElement("br"));
    }

    // Writes a warning in the console
    that.writeWarning = function writeWarning(args) {
        var warningPrefix = document.createElement("span");
        warningPrefix.innerHTML = "Warning: ";
        textArea.appendChild(warningPrefix);

        privateWrite(arguments);
        textArea.appendChild(document.createElement("br"));
    }
}

// Main() :D
var specialConsole = new JavaScriptConsole("#js-console");

var person = {
    firstName: "Pesho",
    lastName: "Peshov",
    age: 21
}

specialConsole.writeLine(
    "My name is {0} {1}. I am {2} years old",
    person.firstName,
    person.lastName,
    person.age
);

specialConsole.writeError("Some error");
specialConsole.writeWarning("{0}", "Some warning");

for (var i = 0; i < 10; i++) {
    specialConsole.writeLine(i);
}

for (var i = 0; i < 10; i++) {
    specialConsole.write("{0}", i);
}