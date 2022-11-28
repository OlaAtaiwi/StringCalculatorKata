using StringCalculatorClasses;
using System;
using Xunit;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        private StringCalculator _stringCalculator;
        public StringCalculatorTests()
        {
            _stringCalculator = new StringCalculator();
        }

        [Fact]
        public void ShouldThrowArgumentNullExceptionWhenInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => _stringCalculator.Add(null));
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("\n", 0)]
        public void ShouldReturnZeroIfInputIsWhiteSpaceOrEmpty(String input, int expected)
        {
            int actual = _stringCalculator.Add(input);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("0,1", 1)]
        [InlineData("0,1,2", 3)]
        [InlineData("115", 115)]
        public void ShouldReturnSumOfNumbersIfInputContainsThreeOrLessNumbers(string input, int expected)
        {
            int actual = _stringCalculator.Add(input);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("1,2,3,4")]
        [InlineData("1,2,3,4,7,2")]
        public void ShouldThrowArgumentExceptionWhenInputContainsMoreThanThreeNumbers(String input)
        {
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add(input));
        }

    }
}
