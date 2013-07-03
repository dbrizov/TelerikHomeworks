var schoolRepository = (function () {
    // Person
    function Person(firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }

    Person.prototype = {
        introduce: function () {
            return "Name: " + this.firstName + " " + this.lastName + ", Age: " + this.age;
        }
    }

    // Student
    function Student(firstName, lastName, age, grade) {
        Person.apply(this, arguments);
        this.grade = grade;
    }

    Student.prototype = new Person();
    Student.prototype.constructor = Student;
    Student.prototype.introduce = function () {
        return Person.prototype.introduce.apply(this) + ", Grade: " + this.grade;
    }

    // Teacher
    function Teacher(firstName, lastName, age, specialty) {
        Person.apply(this, arguments);
        this.specialty = specialty;
    }

    Teacher.prototype = new Person();
    Teacher.prototype.constructor = Teacher;
    Teacher.prototype.introduce = function () {
        return Person.prototype.introduce.apply(this) + ", Specialty: " + this.specialty;
    }

    // Class
    function Class(name, studentsCapacity, students, formTeacher) {
        this.name = name;
        this.studentsCapacity = studentsCapacity;
        this.students = students;
        this.formTeacher = formTeacher;
    }

    // School
    function School(name, town, classesOfStudents) {
        this.name = name;
        this.town = town;
        this.classesOfStudents = classesOfStudents;
    }

    return {
        createStudent: function (firstName, lastName, age, grade) {
            return new Student(firstName, lastName, age, grade);
        },

        createTeacher: function (firstName, lastName, age, specialty) {
            return new Teacher(firstName, lastName, age, specialty);
        },

        createClass: function (name, studentsCapacity, students, formTeacher) {
            return new Class(name, studentsCapacity, students, formTeacher);
        },

        createSchool: function (name, town, classesOfStudents) {
            return new School(name, town, classesOfStudents);
        }
    }
})();

// The demo is in the index.html