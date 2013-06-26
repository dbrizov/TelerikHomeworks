using System;
using System.IO;

namespace TraverseDirectory
{
    public static class DirectoryTraverserDFS
    {
        public static void TraverseAndDisplayFiles(string directoryPath, string fileExtention)
        {
            TraverseAndDisplayFiles(new DirectoryInfo(directoryPath), fileExtention);
        }

        private static void TraverseAndDisplayFiles(DirectoryInfo directory, string fileExtention)
        {
            var files = directory.GetFiles("*" + fileExtention);
            foreach (var file in files)
            {
                Console.WriteLine(file.Name);
            }

            var children = directory.GetDirectories();
            foreach (var dir in children)
            {
                TraverseAndDisplayFiles(dir, fileExtention);
            }
        }
    }
}
