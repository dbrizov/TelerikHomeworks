using System;

public class ExamResult
{
    public uint Grade { get; private set; }
    public uint MinGrade { get; private set; }
    public uint MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(uint grade, uint minGrade, uint maxGrade, string comments)
    {
        if (grade < minGrade)
        {
            throw new ArgumentException("The minGrade can't be bigger than the grade");
        }

        if (maxGrade <= minGrade)
        {
            throw new ArgumentException("maxGrade must be bigger than minGrade");
        }

        if (comments == null || comments == string.Empty)
        {
            throw new ArgumentException("The comments must be != null and != string.Empty");
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
