using System;

namespace BiDictionaryImplementation
{
    public class BiDictionaryImplementationMain
    {
        public static void Main(string[] args)
        {
            // Demo
            BiDictionary<string, string, string> people = new BiDictionary<string, string, string>();
            people.Add("Ivan", "Ivanov", "Front-Ender");
            people.Add("Ivan", "Ivanov", ".NET Ninja");
            people.Add("Ivan", "Georgiev", "Web Developer");
            people.Add("Ivan", "Georgiev", "Student");
            people.Add("Georgi", "Ivanov", "Driver");
            people.Add("Georgi", "Georgiev", "Lawyer");

            var jobsOfPeopleWithFirstNameIvan = people.FindByFirstKey("Ivan");
            var jobsOfPeopleWithFirstNameGeorgi = people.FindByFirstKey("Georgi");
            var jobsOfPeopleWithSecondNameIvanov = people.FindBySecondKey("Ivanov");
            var jobsOfPeopleWithSecondNameGeorgiev = people.FindBySecondKey("Georgiev");
            var jobsOfPeopleWithNameIvanIvanov = people.FindByBothKeys("Ivan", "Ivanov");

            Console.WriteLine("The jobs of the people with first name Ivan");
            foreach (var job in jobsOfPeopleWithFirstNameIvan)
            {
                Console.WriteLine(job);
            }

            Console.WriteLine("\nThe jobs of the people with first name Georgi");
            foreach (var job in jobsOfPeopleWithFirstNameGeorgi)
            {
                Console.WriteLine(job);
            }

            Console.WriteLine("\nThe jobs of the people with second name Ivanov");
            foreach (var job in jobsOfPeopleWithSecondNameIvanov)
            {
                Console.WriteLine(job);
            }

            Console.WriteLine("\nThe jobs of the people with second name Georgiev");
            foreach (var job in jobsOfPeopleWithSecondNameGeorgiev)
            {
                Console.WriteLine(job);
            }

            Console.WriteLine("\nThe jobs of the people with full name Ivan Ivanov");
            foreach (var job in jobsOfPeopleWithNameIvanIvanov)
            {
                Console.WriteLine(job);
            }
        }
    }
}
