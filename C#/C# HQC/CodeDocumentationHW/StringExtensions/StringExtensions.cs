namespace StringExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Implements string extension methods
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// MD5 is a hashing algorithm
        /// </summary>
        /// <returns>The hash code of the input</returns>
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Converts the string to Boolean
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <remarks>"true", "ok", "yes", "1", "да" are convertable to True</remarks>
        /// <returns>
        /// True - if the string is convertable to true
        /// False - otherwise
        /// </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts the string representation of a number to Int16
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <remarks>
        /// If the convertion is successful the number is returned.
        /// Otherwise 0 is returned.
        /// </remarks>
        /// <returns>An Int16 number</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts the string representation of a number to Int32
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <remarks>
        /// If the converting is successful the number is returned.
        /// Otherwise 0 is returned.
        /// </remarks>
        /// <returns>An Int32 number</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts the string representation of a number to Int64
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <remarks>
        /// If the convertion is successful the number is returned.
        /// Otherwise 0 is returned.
        /// </remarks>
        /// <returns>An Int64 number</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts the string representation of a date and time to System.DateTime
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <remarks>
        /// This method returns the System.DateTime value equivalent to
        /// the date and time contained in instance string, if the conversion succeeded, or System.DateTime.MinValue
        /// if the conversion failed. The conversion fails if the instance is null,
        /// is an empty string (""), or does not contain a valid string representation
        /// of a date and time.
        /// </remarks>
        /// <returns>a System.DateTime</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of the string
        /// </summary>
        /// <param name="input">The instance string which will be changed</param>
        /// <returns>
        /// null if the string is null,
        /// the string with uppercase first letter otherwise
        /// </returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }

        /// <summary>
        /// Returns the substring between startString and endString
        /// </summary>
        /// <param name="input">The instance string from which the substring will be taken</param>
        /// <param name="startString">The string left of the returned substring</param>
        /// <param name="endString">The string right of the returned substring</param>
        /// <param name="startFrom">An index from which the search of the between substring will start</param>
        /// <returns>
        /// empty string if there is no substring between startString and endString or
        /// the substring between startString and endString
        /// </returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Converters the cyrillic letters in the string to their latin representation
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <returns>a string with replaced cyrillic letters with their latin representation</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Converters the latin letters in the string to their cyrillic representation
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <returns>a string with replaced latin letters with their cyrillic representation</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts the string to a valid username
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <remarks>Replaces all simbols not equal to [a-z, A-Z, 0-9, _, \, .] with empty strings</remarks>
        /// <returns>a string representing the valid username</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts the file name to a valid latin file name
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <returns>a string representing the valid file name</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Returns the first chars of the string
        /// </summary>
        /// <param name="input">The instance string from which the result will be taken</param>
        /// <param name="charsCount">The number of the first chars</param>
        /// <returns>the first chars of the string</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }

        /// <summary>
        /// Returns the extension of the file represented as string
        /// </summary>
        /// <param name="fileName">The instance string(the file name)</param>
        /// <returns>the file extension as string</returns>
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }

            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Converts the file extension to it's content type
        /// </summary>
        /// <param name="fileExtension">The file extension</param>
        /// <remarks>
        /// "jpg" -> "image/jpeg"
        /// "doc" -> "application/msword"
        /// </remarks>
        /// <returns>the content type of the file extension represented as a string</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };

            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Converts the string to byte array
        /// </summary>
        /// <param name="input">The instance string which will be converted</param>
        /// <returns>a byte array</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
