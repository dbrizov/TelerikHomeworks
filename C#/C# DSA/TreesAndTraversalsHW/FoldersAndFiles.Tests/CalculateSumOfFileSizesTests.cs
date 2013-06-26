using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FoldersAndFiles.Tests
{
    [TestClass]
    public class CalculateSumOfFileSizesTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestEmptyTree()
        {
            Folder folder = null;
            FoldersAndFilesMain.CalculateSumOfFileSizes(folder);
        }

        [TestMethod]
        public void TestTreeWithNoFoldersAndFiles()
        {
            Folder folder = new Folder("name");
            long expected = 0;
            long actual = FoldersAndFilesMain.CalculateSumOfFileSizes(folder);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestTreeWithRootOnlyAndOneFile()
        {
            File file = new File("asd", 10);

            Folder folder = new Folder("name");
            folder.Files.Add(file);

            long expected = 10;
            long actual = FoldersAndFilesMain.CalculateSumOfFileSizes(folder);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestBigTreeWithManyNodesAndFiles()
        {
            Folder folder = new Folder("name");

            // add 5 files to the folder
            for (int i = 0; i < 5; i++)
            {
                folder.Files.Add(new File("asd", 10));
            }

            // add 5 child folders to the folder
            for (int i = 0; i < 5; i++)
            {
                folder.ChildFolders.Add(new Folder("asd"));
            }

            // add 10 files to each child folder
            for (int i = 0; i < folder.ChildFolders.Count; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    folder.ChildFolders[i].Files.Add(new File("asd", 10));
                }
            }

            long expected = 550;
            long actual = FoldersAndFilesMain.CalculateSumOfFileSizes(folder);

            Assert.AreEqual(expected, actual);
        }
    }
}
