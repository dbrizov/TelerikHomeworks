function Node(content) {
    var that = this;
    var li = document.createElement("li");
    li.innerHTML = content;

    var ul = document.createElement("ul");
    li.appendChild(ul);

    that.getLI = function getLI() {
        return li;
    }

    that.getContent = function getContent() {
        return li.innerHTML;
    }

    that.setContent = function setContent(content) {
        li.innerHTML = content;
    }

    that.addNode = function addNode(content) {
        var node = new Node(content);
        ul.appendChild(node.getLI());

        return node;
    }
}

function TreeView(selector) {
    var that = this;
    var treeViewElement = document.querySelector(selector);

    var mainUL = document.createElement("ul");
    treeViewElement.appendChild(mainUL);

    that.addNode = function addNode(content) {
        var node = new Node(content);
        mainUL.appendChild(node.getLI());

        return node;
    }
}

// Main() :D
var treeView = new TreeView("#tree-view");

// generating nodes
var node1 = treeView.addNode("Node 1");
var node2 = treeView.addNode("Node 2");
var node3 = treeView.addNode("Node 3");

// generating subsnodes
var subNode1 = node1.addNode("Subnode 1");
var subNode2 = node1.addNode("Subnode 2");

var subNode3 = node2.addNode("Subnode 3");
var subNode4 = node2.addNode("Subnode 4");

var subNode5 = node3.addNode("Subnode 5");
var subNode6 = node3.addNode("Subnode 6");

// generating sub-subnodes
subNode1.addNode("Sub-subnode 1");
subNode2.addNode("Sub-subnode 2");
subNode3.addNode("Sub-subnode 3");
subNode4.addNode("Sub-subnode 4");
subNode5.addNode("Sub-subnode 5");
subNode6.addNode("Sub-subnode 6");

// Experiment with your own unordered lists :)