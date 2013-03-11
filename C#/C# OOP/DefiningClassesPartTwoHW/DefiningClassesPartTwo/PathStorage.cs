using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    // Exercise 4 - define class PathStorage and Save and Load methods;
    static class PathStorage
    {
        // Field
        private static List<Path> pathStorage = new List<Path>();

        // Save method
        // The method gets all the paths from pathStorage field and saves them into a file named saves.txt
        public static void SavePaths()
        {
            StreamWriter writer = new StreamWriter("saves.txt", false, Encoding.GetEncoding("UTF-8"));

            using (writer)
            {
                for (int path = 0; path < pathStorage.Count; path++)
                {
                    int sequenceOfPointsCount = pathStorage[path].SequenceOfPoints.Count;

                    for (int point = 0; point < sequenceOfPointsCount - 1; point++)
                    {
                        writer.Write("{0} -> ", pathStorage[path].SequenceOfPoints[point]);
                    }

                    writer.WriteLine(pathStorage[path].SequenceOfPoints[sequenceOfPointsCount - 1]);
                }
            }
        }

        // Load method
        // The paths are loaded from the loads.txt file and are put into the pathStorage field
        public static void LoadPaths()
        {
            StreamReader reader = new StreamReader("loads.txt", Encoding.GetEncoding("UTF-8"));
            string allSaves;

            // Read the file and put the information into the string allSaves
            using (reader)
            {
                allSaves = reader.ReadToEnd();
            }

            // Split the string and get all the paths
            string[] paths = allSaves.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

            for (int path = 0; path < paths.Length; path++)
            {
                // (1, 2, 3) -> (4, 5, 6) => [1, 2, 3, 4, 5, 6]
                string[] pointsCoordinates = paths[path].Split(new string[] { "(", ")", " ", "->", "," }, StringSplitOptions.RemoveEmptyEntries);

                Path pathToBeAddedInPathStorage = new Path();

                // The next loop generates the path points
                // From [1, 2, 3, 4, 5, 6] => (1, 2, 3). We add that point to the pathToBeAddedInPathStorage.
                // Then we get point (4, 5, 6) and we add that point to the pathToBeAddedInPathStorage
                for (int i = 0; i < pointsCoordinates.Length; i += 3)
                {
                    Point3D point = new Point3D(double.Parse(pointsCoordinates[i]),
                                                double.Parse(pointsCoordinates[i + 1]),
                                                double.Parse(pointsCoordinates[i + 2]));

                    pathToBeAddedInPathStorage.AddPoint3D(point);
                }

                // Add the current loaded path into the pathStorage
                PathStorage.AddPath(pathToBeAddedInPathStorage);
            }
        }

        // Add path in pathStorage
        public static void AddPath(Path path)
        {
            pathStorage.Add(path);
        }

        // Remove path from pathStorage
        public static void RemovePath(Path path)
        {
            pathStorage.Remove(path);
        }
    }
}
