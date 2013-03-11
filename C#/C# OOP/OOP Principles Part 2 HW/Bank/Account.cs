using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Account
    {
        // Fields
        private Customer customer;
        private decimal balance;
        private decimal interestRate; // monthly based

        // Constructors
        public Account()
        {
            this.customer = null;
            this.balance = 0m;
            this.interestRate = 0m;
        }

        public Account(Customer customer, decimal balance, decimal interestRate)
        {
            if (customer is Individual)
            {
                this.customer = new Individual(customer.Name);
            }
            else
            {
                this.customer = new Company(customer.Name);
            }

            this.balance = balance;
            this.interestRate = interestRate;
        }

        // Properties
        public Customer Customer
        {
            get
            {
                return this.customer;
            }
            set
            {
                this.customer = value;
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                this.interestRate = value;
            }
        }

        // Methods
        public virtual decimal CalculateInterestAmount(int numberOfMonths)
        {
            return this.interestRate * numberOfMonths;
        }
    }
}
