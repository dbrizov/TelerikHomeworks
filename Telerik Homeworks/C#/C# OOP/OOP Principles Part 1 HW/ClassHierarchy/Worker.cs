using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassHierarchy
{
    public class Worker : Human
    {
        // Fields
        private double weekSalary;
        private double workHoursPerDay;

        // Constructors
        public Worker()
            : base()
        {
            weekSalary = 0;
            workHoursPerDay = 0;
        }

        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            this.weekSalary = weekSalary;
            this.workHoursPerDay = workHoursPerDay;
        }

        public Worker(Worker worker)
            : base((Human)worker)
        {
            this.weekSalary = worker.weekSalary;
            this.workHoursPerDay = worker.workHoursPerDay;
        }

        // Properties
        public double WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                this.weekSalary = value;
            }
        }

        public double WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                this.workHoursPerDay = value;
            }
        }

        // Methods
        public double MoneyPerHour()
        {
            double moneyPerDay = this.weekSalary / 7;
            double moneyPerHour = moneyPerDay / this.workHoursPerDay;

            return moneyPerHour;
        }

        public override string ToString()
        {
            return string.Format("Worker: {0}\nWeek salary: {1}\nWork hours per day: {2}\nMoney per hour: {3}\n",
                this.FirstName + " " + this.LastName, this.weekSalary, this.workHoursPerDay, this.MoneyPerHour());
        }

        public override void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
