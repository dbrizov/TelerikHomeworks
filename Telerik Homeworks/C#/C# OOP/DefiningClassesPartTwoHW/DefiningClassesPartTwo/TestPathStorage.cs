using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartTwo
{
    static class TestPathStorage
    {
        // To test it delete the saves.txt file in the Debug folder of the assembly.
        // Then write down some paths in the loads.txt file. Each path is on a single line.
        // The format of the paths is shown in the loads.txt file.
        public static void TestMethod()
        {
            PathStorage.LoadPaths(); // Loads the paths from the loads.txt file
            PathStorage.SavePaths(); // Saves the paths into the saves.txt file
        }
    }
}
