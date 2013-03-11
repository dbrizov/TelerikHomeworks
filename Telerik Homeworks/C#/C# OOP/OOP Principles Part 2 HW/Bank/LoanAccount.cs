using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class LoanAccount : Account
    {
        // Constructors
        public LoanAccount() : base() { }
        public LoanAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate) { }

        // Methods
        public void DepositMoney(decimal amount)
        {
            this.Balance += amount;
        }

        public override decimal CalculateInterestAmount(int numberOfMonths)
        {
            if (numberOfMonths <= 3 && this.Customer is Individual)
            {
                return 0m;
            }
            else if (numberOfMonths <= 2 && this.Customer is Company)
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
