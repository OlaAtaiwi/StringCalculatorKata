using System;
using System.Collections.Generic;
using System.Linq;

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
                var specialDelimiter = numbers.GetSpecialDelimiter();
                var delimitersArray = new string[] { ",", "\n", specialDelimiter };
                var listOfNumbers = GetNumbersList(numbers, delimitersArray);
                if (ContainsNegativeNumbers(listOfNumbers))
                    throw new Exception("Negatives are Not Allowed:" + NegativeNumbersInList(listOfNumbers));
                return listOfNumbers.Where(x => x <= 1000).Sum();
            }
        }

        private string NegativeNumbersInList(List<int> listOfNumbers)
        {
            var negativeNums = listOfNumbers.Where(x => x < 0).Select(x => x.ToString());
            return String.Join(", ", negativeNums);
        }

        private bool ContainsNegativeNumbers(List<int> listOfNumbers)
        {
            foreach (int item in listOfNumbers)
                if (item < 0)
                    return true;
            return false;
        }

        private List<int> GetNumbersList(string numbers, string[] delimiters)
        {
            var numbersList = numbers.Split(delimiters, StringSplitOptions.None);
            var finalList = new List<int>();
            foreach (var number in numbersList)
            {
                int num;
                if (int.TryParse(number, out num))
                    finalList.Add(num);
            }
            return finalList;
        }
    }
}
