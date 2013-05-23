using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFormatting
{
    public class Event : IComparable
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
        }

        public string Location
        {
            get
            {
                return this.location;
            }
        }

        public int CompareTo(object obj)
        {
            Event otherObj = obj as Event;
            int byDate = this.date.CompareTo(otherObj.date);
            int byTitle = this.title.CompareTo(otherObj.title);
            int byLocation = this.location.CompareTo(otherObj.location);

            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.Append(" | " + this.title);

            if (this.location != null && this.location != string.Empty)
            {
                result.Append(" | " + this.location);
            }

            return result.ToString();
        }
    }
}
