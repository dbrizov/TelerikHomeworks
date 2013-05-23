using System;

public class CSharpExam : Exam
{
    private uint score;

    public CSharpExam(uint score)
    {
        this.score = score;
    }

    public uint Score
    {
        get
        {
            return this.score;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.score, 0, 100, "Exam results calculated by score.");
    }
}
