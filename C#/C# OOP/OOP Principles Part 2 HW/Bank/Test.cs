using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Test
    {
        static void Main(string[] args)
        {
            Account deposit1 = new DepositAccount(new Individual(), 500m, 3.5m);
            Account deposit2 = new DepositAccount(new Company(), 1500m, 3.4m);

            Console.WriteLine(deposit1.CalculateInterestAmount(2)); // 0
            Console.WriteLine(deposit2.CalculateInterestAmount(2)); // 6.8

            Account loan1 = new LoanAccount(new Individual(), 1000m, 5m);
            Account loan2 = new LoanAccount(new Company(), 1000m, 5m);

            Console.WriteLine(loan1.CalculateInterestAmount(2)); // 0
            Console.WriteLine(loan1.CalculateInterestAmount(4)); // 20
            Console.WriteLine(loan2.CalculateInterestAmount(1)); // 0
            Console.WriteLine(loan2.CalculateInterestAmount(3)); // 15

            Account mortgage1 = new MortgageAccount(new Individual(), 1000m, 5m);
            Account mortgage2 = new MortgageAccount(new Company(), 1000m, 5m);

            Console.WriteLine(mortgage2.CalculateInterestAmount(11)); // 65 / 2 = 27.5
            Console.WriteLine(mortgage2.CalculateInterestAmount(13)); // 65
            Console.WriteLine(mortgage1.CalculateInterestAmount(5)); // 0
            Console.WriteLine(mortgage1.CalculateInterestAmount(7)); // 35

            Individual customer1 = new Individual("Pesho");
            Company customer2 = new Company("Telerik");

            Console.WriteLine(customer1.Name); // Pesho
            Console.WriteLine(customer2.Name); // Telerik
        }
    }
}
