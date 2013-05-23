using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOfFreeContent
{
    public class Content : IComparable, IContent
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public long Size { get; set; }

        private string url;

        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.TextRepresentation = this.ToString();
            }
        }

        public ContentType Type { get; set; }

        public string TextRepresentation { get; set; }

        public Content(ContentType type, string[] commandParams)
        {
            this.Type = type;
            this.Title = commandParams[(int)CommandParameter.Title];
            this.Author = commandParams[(int)CommandParameter.Author];
            this.Size = long.Parse(commandParams[(int)CommandParameter.Size]);
            this.URL = commandParams[(int)CommandParameter.URL];
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            Content objAsContent = obj as Content;
            if (objAsContent != null)
            {
                int comparisonResult =
                    this.TextRepresentation.CompareTo(objAsContent.TextRepresentation);

                return comparisonResult;
            }

            throw new ArgumentException("Object is not a Content");
        }

        public override string ToString()
        {
            string output = String.Format("{0}: {1}; {2}; {3}; {4}",
                this.Type.ToString(), this.Title, this.Author, this.Size, this.URL);

            return output;
        }
    }
}
