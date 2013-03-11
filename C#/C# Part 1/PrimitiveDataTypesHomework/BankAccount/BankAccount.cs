using System;

class BankAccount
{
    static void Main()
    {
        string firstName = "Denis";
        string middleName = "Borislavov";
        string lastName = "Rizov";
        decimal balance = 12345678901234567890m;
        string bankName = "OBB";
        string IBAN = "ASGD AJSG DJASGDJ 0000 AJHSD";
        string BIC = "ASD ASD ASD";
        long cardNumber1 = 1;
        long cardNumber2 = 2;
        long cardNumber3 = 3;

        Console.WriteLine(firstName);
        Console.WriteLine(middleName);
        Console.WriteLine(lastName);
        Console.WriteLine(balance);
        Console.WriteLine(bankName);
        Console.WriteLine(IBAN);
        Console.WriteLine(BIC);
        Console.WriteLine(cardNumber1);
        Console.WriteLine(cardNumber2);
        Console.WriteLine(cardNumber3);
    }
}
