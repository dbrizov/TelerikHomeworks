using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClassesPartOne
{
    // Exercise 1 - define class GSM
    class GSM
    {
        // Private:
        private string model;
        private string manufacturer;
        private double price;
        private string owner;
        private Battery battery;
        private Display display;

        // Exercise 2 - define several constructors
        // Public:
        public GSM()
        {
            this.model = null;
            this.manufacturer = null;
            this.price = 0.0;
            this.owner = null;
            this.battery = null;
            this.display = null;
            callHistory = new List<Call>();
        }

        public GSM(string model, string manufacturer, double price = 0.0, string owner = null, Battery battery = null, Display display = null)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            this.battery = battery;
            this.display = display;
            callHistory = new List<Call>();
        }

        // Exercise 4 - override ToString()
        public override string ToString()
        {
            string result = "";
            result += "Model: " + this.model + "\n";
            result += "Manufacturer: " + this.manufacturer + "\n";
            result += "Price: " + this.price + "\n";
            result += "Owner: " + this.owner + "\n";

            if (this.battery == null)
            {
                result += "Battery:\n";
            }
            else
            {
                result += this.battery.ToString();
            }

            if (this.display == null)
            {
                result += "Display:\n";
            }
            else
            {
                result += this.display.ToString();
            }

            return result;
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

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The price can't be a negative number");
                }

                this.price = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        // Exercise 6 - static field IPhone4S and  static properties
        private static string iPhone4S = 
            "Model: IPhone4S\n" + 
            "Manufacturer: Apple\n" + 
            "Price: 1000\n" + 
            "Owner: me\n" + 
            "Battery model: IBattery\n" + 
            "Battery hours idle: 20\n" + 
            "Battery hours talk: 10\n" + 
            "Battery type: NiHM\n" + 
            "Display witdh: 400\n" + 
            "Display height: 800\n" + 
            "Display colors: 16000000";

        public static string GetIPhone4S()
        {
            return iPhone4S;
        }

        public static void SetIPhone4S(string value)
        {
            iPhone4S = value;
        }

        // Exercise 9 - define callHistory field and property
        private List<Call> callHistory;

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }

            set
            {
                this.callHistory = value;
            }
        }

        // Exercise 10 - define Add, Remove, Cleat methods for callHistory
        public void AddCallInHistory(Call call)
        {
            callHistory.Add(call);
        }

        public void DeleteCallFromHistory(Call call)
        {
            callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            callHistory = new List<Call>();
        }

        // Exercise 11 - define CalCulateTotalPriceOfCalls
        public double CalculateTotalPriceOfCalls(double pricePerMinute)
        {
            double result = 0;

            for (int i = 0; i < callHistory.Count; i++)
            {
                result += (callHistory[i].Duration / 60.0) * pricePerMinute;
            }

            return result;
        }
    }
}
