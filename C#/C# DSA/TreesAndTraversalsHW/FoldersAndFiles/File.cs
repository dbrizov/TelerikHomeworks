using System;

namespace FoldersAndFiles
{
    public class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null && value == string.Empty)
                {
                    throw new ArgumentException("File name can't be null or empty");
                }

                this.name = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The size of the file must be positive");
                }

                this.size = value;
            }
        }
    }
}
