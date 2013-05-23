using System;

public class SimpleMathExam : Exam
{
    public uint ProblemsSolvedCount { get; private set; }

    public SimpleMathExam(uint problemsSolvedCount)
    {
        this.ProblemsSolvedCount = problemsSolvedCount;
    }

    public override ExamResult Check()
    {
        ExamResult examResult;
        const int MinGrade = 2;
        const int MaxGrade = 6;

        if (this.ProblemsSolvedCount == 0)
        {
            examResult = new ExamResult(2, MinGrade, MaxGrade, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolvedCount == 1)
        {
            examResult = new ExamResult(3, MinGrade, MaxGrade, "Average result: 1 problem solved.");
        }
        else if (this.ProblemsSolvedCount == 2)
        {
            examResult = new ExamResult(4, MinGrade, MaxGrade, "Good result: 2 problems solved.");
        }
        else if (this.ProblemsSolvedCount == 3)
        {
            examResult = new ExamResult(5, MinGrade, MaxGrade, "Very Good result: 3 problems solved.");
        }
        else if (this.ProblemsSolvedCount == 4)
        {
            examResult = new ExamResult(6, MinGrade, MaxGrade, "Excellent result: 4 problems solved.");
        }
        else // if (this.ProblemsSolvedCount > 4)
        {
            examResult = new ExamResult(6, MinGrade, MaxGrade, "Excellent result: more than 4 problems solved. You get an extra bonus");
        }

        return examResult;
    }
}
