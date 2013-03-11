using System;

class CompanyInfo
{
    static void Main()
    {
        Console.Write("name: ");
        string name = Console.ReadLine();
        Console.Write("address: ");
        string address = Console.ReadLine();
        Console.Write("phone number: ");
        long phoneNumber = long.Parse(Console.ReadLine());
        Console.Write("fax number: ");
        int faxNumber = int.Parse(Console.ReadLine());
        Console.Write("web site: ");
        string webSite = Console.ReadLine();
        Console.Write("managers first name: ");
        string managerFirstName = Console.ReadLine();
        Console.Write("managers last name: ");
        string managerLastName = Console.ReadLine();
        Console.Write("managers age: ");
        byte managerAge = byte.Parse(Console.ReadLine());
        Console.Write("managers phone number: ");
        long managerPhoneNumber = long.Parse(Console.ReadLine());

        Console.WriteLine();

        Console.WriteLine(name);
        Console.WriteLine(address);
        Console.WriteLine("{0:0### ### ###}", phoneNumber);
        Console.WriteLine(faxNumber);
        Console.WriteLine(webSite);
        Console.WriteLine(managerFirstName);
        Console.WriteLine(managerLastName);
        Console.WriteLine(managerAge);
        Console.WriteLine("{0:0### ### ###}", managerPhoneNumber);
    }
}
