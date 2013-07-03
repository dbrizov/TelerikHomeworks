/// <reference path="../libs/jquery-1.10.1.js" />
var Student = function (firstName, lastName, grade) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.grade = grade;
}

var generateTable = function (students) {
    var table = $('<table border="1px"></table>');
    table.append('<tr><th>First name</th><th>Last name</th><th>Grade</th></tr>');
    for (var i = 0; i < students.length; i++) {
        table.append('<tr><td>' + students[i].firstName + '</td>' +
                     '<td>' + students[i].lastName + '</td>' +
                     '<td>' + students[i].grade + '</td></tr>');
    }

    return table;
}

var students = [];
students.push(new Student("Pesho", "Peshov", 3));
students.push(new Student("Gosho", "Goshov", 4));
students.push(new Student("Ivan", "Ivanov", 5));
students.push(new Student("Georgi", "Georgiev", 6));

var table = generateTable(students);
$('#wrapper').append(table);