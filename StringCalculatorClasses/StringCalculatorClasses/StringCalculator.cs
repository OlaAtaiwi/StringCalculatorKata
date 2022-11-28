using System;

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
                int sum = 0;
                var numbersList = numbers.Split(',', '\n');
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
}
