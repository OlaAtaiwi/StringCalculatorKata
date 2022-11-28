using System;
using System.Linq;

namespace StringCalculatorClasses
{
    public static class Delimiter
    {
        public static string GetSpecialDelimiter(this string numbers)
        {
            string delimitersString = "";
            if (numbers.ContainsSpecialDelimiter())
            {
                numbers = numbers.Remove(0, 2);
                delimitersString = string.Concat(numbers.TakeWhile(x => !x.Equals('\n')));
            }
            if (delimitersString == "-")
                throw new ArgumentException("Sorry, - is Not Accepted Delimiter");
            return delimitersString;
        }

        public static bool ContainsSpecialDelimiter(this string numbers)
        {
            if (numbers.StartsWith("//"))
                return true;
            else
                return false;
        }
    }
}
