using System;

namespace CSharpRefactoring
{
    public class Converter
    {
        public static void Main(string[] args)
        {
            Converter.BoolConverter converter = new Converter.BoolConverter();
            converter.PrintBoolToString(false);
        }

        public class BoolConverter
        {
            public void PrintBoolToString(bool boolVar)
            {
                string boolVarToString = boolVar.ToString();
                Console.WriteLine(boolVarToString);
            }
        }
    }
}
