using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class MortgageAccount : Account
    {
        // Constructors
        public MortgageAccount() : base() { }
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        // Methods
        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (this.Customer is Company && numberOfMonths <= 12)
            {
                return (this.InterestRate * numberOfMonths) / 2;
            }
            else if (this.Customer is Individual && numberOfMonths <= 6)
            {
                return 0m;
            }
            else
            {
                return this.InterestRate * numberOfMonths;
            }
        }
    }
}
