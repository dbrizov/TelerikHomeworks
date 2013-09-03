(function () {
    this.Student = function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.marks = [];
    }

    this.Student.prototype = {
        constructor: Student,
        getFullName: function () {
            return this.firstName + " " + this.lastName;
        },

        averageMarks: function () {
            var sum = 0;
            for (var i = 0, len = this.marks.length; i < len; i += 1) {
                sum += this.marks[i];
            }

            return sum / this.marks.length;
        }
    };
})();