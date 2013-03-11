using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalHierarchy
{
    class MainMethod
    {
        static void CalculateAverageAges(Animal[] animals)
        {
            double dogAgeSum = 0;
            double catAgeSum = 0;
            double frogAgeSum = 0;
            double kittenAgeSum = 0;
            double tomcatAgeSum = 0;

            int dogCount = 0;
            int catCount = 0;
            int frogCount = 0;
            int kittenCount = 0;
            int tomcatCount = 0;

            foreach (Animal animal in animals)
            {
                if (animal is Dog)
                {
                    dogAgeSum += animal.Age;
                    dogCount++;
                }
                else if (animal is Cat)
                {
                    if (animal is Kitten)
                    {
                        kittenAgeSum += animal.Age;
                        kittenCount++;
                    }
                    else if (animal is Tomcat)
                    {
                        tomcatAgeSum += animal.Age;
                        tomcatCount++;
                    }
                    else
                    {
                        catAgeSum += animal.Age;
                        catCount++;
                    }
                }
                else
                {
                    frogAgeSum += animal.Age;
                    frogCount++;
                }
            }

            Console.WriteLine("Average age for each kind of animal:");
            Console.WriteLine("Dog: {0}", dogAgeSum / dogCount);
            Console.WriteLine("Cat: {0}", catAgeSum / catCount);
            Console.WriteLine("Frog: {0}", frogAgeSum / frogCount);
            Console.WriteLine("Kitten: {0}", kittenAgeSum / kittenCount);
            Console.WriteLine("Tomcat: {0}", tomcatAgeSum / tomcatCount);
        }

        static void Main(string[] args)
        {

            // Solve the given problem
            Animal[] animals = new Animal[]
            {
                new Dog("doggy", 3, 'F'),
                new Cat("catty", 4, 'M'),
                new Frog("Jojo", 1, 'M'),
                new Kitten("Kity", 2),
                new Tomcat("Tom", 3),
                new Dog("silvester", 5, 'M'),
                new Cat("carolina", 9, 'F'),
                new Frog("frogy", 2, 'F'),
                new Kitten("coco", 7),
                new Tomcat("toto", 6)
            };

            CalculateAverageAges(animals);

            // Test animal sounds
            Console.WriteLine("\nTEST ANIMAL SOUNDS");
            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
        }
    }
}
