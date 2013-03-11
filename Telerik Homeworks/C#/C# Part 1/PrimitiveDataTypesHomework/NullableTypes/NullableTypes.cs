using System;

class NullableTypes
{
    static void Main()
    {
        int? someInteger = null;
        double? someDouble = null;

        Console.WriteLine(someInteger);
        Console.WriteLine(someDouble);

        someInteger = 5;
        someDouble = 10.75;

        Console.WriteLine(someInteger);
        Console.WriteLine(someDouble);
    }
}
