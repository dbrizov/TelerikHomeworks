using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartOne
{
    // Exercise 8 - define class Call
    class Call
    {
        // Private:
        private DateTime dateAndTime;
        private string dialedPhoneNumber;
        private int duration;

        // Public:
        // Constructor
        public Call(DateTime dateAndTime, string dialedPhoneNumber, int duration)
        {
            this.dateAndTime = dateAndTime;
            this.dialedPhoneNumber = dialedPhoneNumber;
            this.duration = duration;
        }

        // ToString() override
        public override string ToString()
        {
            string result = "";

            result += "Date and time: " + this.dateAndTime + "\n";
            result += "Dialed phone number: " + this.dialedPhoneNumber + "\n";
            result += "Duration: " + this.duration;

            return result;
        }

        // Properties
        public DateTime DateAndTime
        {
            get
            {
                return this.dateAndTime;
            }
            set
            {
                this.dateAndTime = value;
            }
        }

        public string DialedPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }
            set
            {
                this.dialedPhoneNumber = value;
            }
        }

        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }
    }
}
