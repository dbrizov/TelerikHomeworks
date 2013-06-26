using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoldersAndFiles
{
    public class Folder
    {
        private string name;
        private List<Folder> childFolders;
        private List<File> files;

        public Folder(string name)
        {
            this.Name = name;
            this.ChildFolders = new List<Folder>();
            this.Files = new List<File>();
        }

        public Folder(string name, IEnumerable<Folder> folders, IEnumerable<File> files)
        {
            this.Name = name;
            this.childFolders = folders.ToList<Folder>();
            this.Files = files.ToList<File>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("The name of the folder can't be null or empty");
                }

                this.name = value;
            }
        }

        public List<Folder> ChildFolders
        {
            get
            {
                return this.childFolders;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The folders in the folder can't be null");
                }

                this.childFolders = value;
            }
        }

        public List<File> Files
        {
            get
            {
                return this.files;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The files in the folder can't  be null");
                }

                this.files = value;
            }
        }
    }
}
