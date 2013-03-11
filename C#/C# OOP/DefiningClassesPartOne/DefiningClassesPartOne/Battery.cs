using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartOne
{
    // Exercise 3 - define BatteryType enumeration
    public enum BatteryType
    {
        Lion,
        NiMH,
        NiCd
    }

    // Exercise 1 - define class Battery
    class Battery
    {
        // Private:
        private string model;
        private int hoursIdle;
        private int hoursTalk;
        private BatteryType batteryType;

        // Exercise 2 - define several constructors
        // Public:
        public Battery()
        {
            this.model = null;
            this.hoursIdle = 0;
            this.hoursTalk = 0;
            this.batteryType = BatteryType.Lion;
        }

        public Battery(string model = null, int hoursIdle = 0, int hoursTalk = 0, BatteryType batteryType = BatteryType.Lion)
        {
            this.model = model;
            this.hoursIdle = hoursIdle;
            this.hoursTalk = hoursTalk;
            this.batteryType = batteryType;
        }

        // Exercise 4 - override ToString()
        public override string ToString()
        {
            return "Battery: " + "\n  battery model: " + this.model +
                                 "\n  hours idle: " + this.hoursIdle +
                                 "\n  hours talk: " + this.hoursTalk +
                                 "\n  battery type: " + this.batteryType + "\n";
        }

        // Exercise 5 - encapsulate data fields
        public string Model
        {
            get
            {
                return this.model; 
            }
            set 
            {
                this.model = value; 
            }
        }

        public int HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("the idle hours must be a positive number");
                }

                this.hoursIdle = value;
            }
        }

        public int HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The talk hours must be a positive number");
                }

                this.hoursTalk = value;
            }
        }

        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }
    }
}
