var schoolRepository = (function () {
    var Person = {
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },

        introduce: function () {
            return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
        }
    }

    var Student = Person.extend({
        init: function (firstName, lastName, age, grade) {
            Person.init.apply(this, arguments);
            this.grade = grade;
        },

        introduce: function () {
            return Person.introduce.apply(this) + " Grade: " + this.grade;
        }
    });

    var Teacher = Person.extend({
        init: function (firstName, lastName, age, specialty) {
            Person.init.apply(this, arguments);
            this.specialty = specialty;
        },

        introduce: function () {
            return Person.introduce.apply(this) + " Specialty: " + this.specialty;
        }
    });

    var Class = {
        init: function (name, studentsCapacity, students, formTeacher) {
            this.name = name;
            this.studentsCapacity = studentsCapacity;
            this.students = students;
            this.formTeacher = formTeacher;
        }
    }

    var School = {
        init: function (name, town, classesOfStudents) {
            this.name = name;
            this.town = town;
            this.classesOfStudents = classesOfStudents;
        }
    }

    return {
        Student: Student,
        Teacher: Teacher,
        Class: Class,
        School: School
    }
})();

// The demo is in the index.html