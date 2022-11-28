using System;
using System.Collections.Generic;

namespace StringCalculatorClasses
{
    public class StringCalculator
    {
        public int Add(String numbers)
        {
            if (numbers == null)
                throw new ArgumentNullException("Invalid numbers!");
            if (string.IsNullOrWhiteSpace(numbers))
                return 0;
            else
            {
                var SpecialDelimiter = numbers.GetSpecialDelimiter();
                string[] delimiters = { ",", "\n", SpecialDelimiter };
                return SummationOfNumbers(numbers, delimiters);
            }
        }

        private static int SummationOfNumbers(string numbers, string[] delimiters)
        {
            int sum = 0;
            var numbersList = numbers.Split(delimiters,StringSplitOptions.None);
            foreach (var number in numbersList)
            {
                int num;
                int.TryParse(number, out num);
                sum += num;
            }
            return sum;
        }
    }
}
