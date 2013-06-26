using System;
using System.IO;
using System.Collections.Generic;

namespace FoldersAndFiles
{
    public static class FoldersAndFilesMain
    {
        // Traverses a given directory (with DFS) and parses
        // it to a Folder. The Folder has subfolders and files.
        // This Folder is the root of the tree.
        public static Folder ParseDirectory(string directoryPath)
        {
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            var children = directory.GetDirectories();
            var allFiles = directory.GetFiles();

            var subfolders = new Folder[children.Length];
            for (int i = 0; i < subfolders.Length; i++)
            {
                // Recursively parses the subfolders
                subfolders[i] = ParseDirectory(children[i].FullName);
            }

            var files = new File[allFiles.Length];
            for (int i = 0; i < files.Length; i++)
            {
                files[i] = new File(allFiles[i].Name, allFiles[i].Length);
            }

            Folder currentFolder = new Folder(directory.Name, subfolders, files);

            return currentFolder;
        }

        // Traverses a given folder and writes the result in a StreamWriter
        public static void TraverseFolder(Folder folder, StreamWriter writer, string spaces = "")
        {
            writer.WriteLine(spaces + "[" + folder.Name + "]");

            if (folder.Files != null)
            {
                foreach (var file in folder.Files)
                {
                    writer.WriteLine("{0}{1}: {2}", spaces, file.Name, file.Size);
                }
            }

            writer.WriteLine();

            foreach (var childFolder in folder.ChildFolders)
            {
                TraverseFolder(childFolder, writer, spaces + "   ");
            }
        }

        // Calculates the sum of the file sizes of a folder tree(subtree)
        public static long CalculateSumOfFileSizes(Folder folder)
        {
            if (folder == null)
            {
                throw new ArgumentNullException("The folder does not exists");
            }

            long sum = 0;

            var childFolders = folder.ChildFolders;
            foreach (var child in childFolders)
            {
                sum += CalculateSumOfFileSizes(child);
            }

            var files = folder.Files;
            foreach (var file in files)
            {
                sum += file.Size;
            }

            return sum;
        }

        public static void Main(string[] args)
        {
            // I get an UnauthorizedAccessException when traversing the C:\Windows.
            // That's why I traversed the D:\Dropbox\.
            // Check the traversed-folder.txt to see the result.
            string directoryPath = @"D:\Dropbox\"; // Traverse a directory of your choise
            Folder folder = ParseDirectory(directoryPath);

            StreamWriter writer = new StreamWriter("..\\..\\traversed-folder.txt");
            using (writer)
            {
                TraverseFolder(folder, writer);
            }

            long sumOfFileSizes = CalculateSumOfFileSizes(folder);
            Console.WriteLine("Sum of the file sizes = {0}", sumOfFileSizes);
        }
    }
}
