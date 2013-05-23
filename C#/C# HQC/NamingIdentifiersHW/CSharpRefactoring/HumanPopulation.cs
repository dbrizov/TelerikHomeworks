using System;

public class HumanPopulation
{
    public enum Gender
    {
        Male,
        Female
    }

    public Human CreateHuman(int ages)
    {
        Human human = new Human();
        human.Age = ages;

        if (ages % 2 == 0)
        {
            human.FullName = "Pesho Peshov";
            human.Gender = Gender.Male;
        }
        else
        {
            human.FullName = "Ivan Ivanov";
            human.Gender = Gender.Female;
        }

        return human;
    }

    public class Human
    {
        public Gender Gender { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }
    }
}