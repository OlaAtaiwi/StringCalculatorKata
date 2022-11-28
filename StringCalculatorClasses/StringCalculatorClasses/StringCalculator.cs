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
                string[] delimitersArray = { ",", "\n", specialDelimiter };
                List<int> listOfNumbers = GetNumbersList(numbers, delimitersArray);
                if (ContainsNegativeNumbers(listOfNumbers))
                    throw new Exception("Negatives are Not Allowed:" + NegativeNumbersInList(listOfNumbers));
                return SummationOfNumbers(listOfNumbers);
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
            List<int> finalList = new List<int>();
            foreach (var number in numbersList)
            {
                int num;
                if (int.TryParse(number, out num))
                    finalList.Add(num);
            }
            return finalList;
        }

        private static int SummationOfNumbers(List<int> numbers)
        {
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }
}
