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
        [InlineData("1,5,7,15,32", 60)]
        [InlineData("10,10,10,10,10,10 ,10", 70)]
        public void ShouldReturnSumOfNumbersIfInputContainsNumbersSeparatedByComma(string input, int expected)
        {
            int actual = _stringCalculator.Add(input);
            Assert.Equal(actual, expected);
        }

        [Theory]
        [InlineData("0", 0)]
        [InlineData("0\n1", 1)]
        [InlineData("0,1\n2", 3)]
        [InlineData("115", 115)]
        [InlineData("1,5\n7\n15,32", 60)]
        [InlineData("10\n10,10\n10,10\n10 ,10", 70)]
        [InlineData("1,\n", 1)]
        public void ShouldReturnSumOfNumbersIfInputContainsNumbersSeparatedByNewLineOrComma(string input, int expected)
        {
            int actual = _stringCalculator.Add(input);
            Assert.Equal(actual, expected);
        }


    }
}
