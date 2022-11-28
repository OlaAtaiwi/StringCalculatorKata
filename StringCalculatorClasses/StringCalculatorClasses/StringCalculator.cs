﻿using System;

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
                var numbersList = numbers.Split(',');
                foreach (var number in numbersList)
                    sum += int.Parse(number);
                return sum;
            }
        }
    }
}
