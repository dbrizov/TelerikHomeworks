using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    private string firstName;
    private string lastName;
    private IList<Exam> exams;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        if (firstName == null)
        {
            throw new ArgumentNullException("The input string (firstName) is null");
        }

        if (lastName == null)
        {
            throw new ArgumentNullException("The input string (lastName) is null");
        }

        if (exams == null)
        {
            throw new ArgumentNullException("The IList<Exam> exams is null");
        }

        this.firstName = firstName;
        this.lastName = lastName;
        this.exams = exams;
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException("The firstName can't be null or an empty string");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null || value == string.Empty)
            {
                throw new ArgumentException("The lastName can't be null or an empty string");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentException("The exams are null");
            }

            this.exams = value;
        }
    }

    public IList<ExamResult> CheckExams()
    {
        //// I don't need to check anything because the constructor
        //// and the setter doesn't allow the exams to be null

        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results; // returns an empty List (The student has no exams yet)
    }

    public double CalcAverageExamResultInPercents()
    {
        //// I don't need to check anything because the constructor
        //// and the setter doesn't allow the exams to be null

        if (this.Exams.Count == 0)
        {
            return 0;
        }

        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Grade - examResults[i].MinGrade) / 
                (examResults[i].MaxGrade - examResults[i].MinGrade);
        }

        return examScore.Average();
    }
}
