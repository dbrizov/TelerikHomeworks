using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace StudentsAndTheirCourses
{
    public class StudentsAndTheirCoursesMain
    {
        public static void Main(string[] args)
        {
            string path = "..\\..\\course-records.txt";
            var records = ParseCourseRecords(path);

            foreach (var course in records)
            {
                Console.Write("{0}: ", course.Key);
                foreach (var student in course.Value)
                {
                    Console.Write(student + ", ");
                }

                Console.WriteLine();
            }
        }

        public static SortedDictionary<string, List<Student>> ParseCourseRecords(string filePath)
        {
            var result = new SortedDictionary<string, List<Student>>();
            StreamReader reader = new StreamReader(filePath);
            using (reader)
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] record = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);
                    string firstName = record[0];
                    string lastName = record[1];
                    string course = record[2];

                    if (result.ContainsKey(course))
                    {
                        result[course].Add(new Student(firstName, lastName));
                    }
                    else
                    {
                        result.Add(course, new List<Student>());
                        result[course].Add(new Student(firstName, lastName));
                    }
                }
            }

            foreach (var entry in result)
            {
                entry.Value.Sort((x, y) =>
                    (x.FirstName + x.LastName).CompareTo(y.FirstName + y.LastName));
            }

            return result;
        }
    }
}
