using System;

class StringDescription
{
    static void Main(string[] args)
    {
        /*
         * The string is immutable type. That means once created it can't be changed.
         * We can access the elements in the string with the [] operator but we can't
         * change them (with the arrays it's not like that). The string is a reference
         * type variable. That means in the stack there is kept only the address of the
         * string which is located somewhere in the heep (the dynamic memory).
         * Here is the catch. If you want to make a string concatenation, the result is
         * a brand new string. We take the value of the existing string and concat with the
         * string we want - the result is a new string. The old string will be deleted
         * by the CLR's garbage collector. The most important methods of the strings are
         * 1) str.Concat(string str2) - concats the current string with another and returns
         * a new string. This operation can also be done with the +, += operators.
         * 2) str.IndexOf("substring", [index to start searching]) - this method returns
         * the index of the first substring that is found in str (If not found - returns -1).
         * There is a second argument that can set the index from which we want the searching
         * process.
         * 3) str.Replace(oldString, newString) - replaces oldString with newString in the
         * string str.
         * 4) str.Split() - splits the string into substrings and returns and array of these
         * substrings. By default it splits them with the white-space separators. We can change
         * that if we give the method out separators like char[] { ' ', '.' };
         * 5) str.Substring(startIndex, length) - returns the substring that starts from
         * startIndex and ends within the given length.
         * Example:
         * string str = "denis";
         * str.Substring(1, 3) is the substring "eni"
         * 6) String.Compare(str1, str2) - compares str1 and str2 lexicographical.
         * If str1 < str2 returns negative integer (-1 in most programming languages)
         * If str1 == str2 returns 0
         * If str2 > str1 returns positive integer (1 in most programming languages)
         * 7) str1.Equals(str2) - The same as (str1 == str2) 
         */
    }
}