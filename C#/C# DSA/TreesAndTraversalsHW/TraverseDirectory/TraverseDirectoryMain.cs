using System;

namespace TraverseDirectory
{
    public class TraverseDirectoryMain
    {
        static void Main(string[] args)
        {
            try
            {
                // I get an exception
                string directoryPath = "C:\\Windows";
                string filesExtension = ".exe";
                DirectoryTraverserDFS.TraverseAndDisplayFiles(directoryPath, filesExtension);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
