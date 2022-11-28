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

        [Theory]
        [InlineData("//;\n5", 5)]
        [InlineData("// \n13  100", 113)]
        [InlineData("//O\n1O  2O 15 ", 18)]
        [InlineData("//_\n11_4_17_3_10", 45)]
        [InlineData("//\n12", 12)]
        public void ShouldReturnCorrectSumOfIfInputContainsNumbersSeparatedBySpecialDelimiterOnly(string numbers, int expectedSum)
        {
            var actual = this._stringCalculator.Add(numbers);
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("//;\n5,10\n20;10", 45)]
        [InlineData("// \n13  100,200", 313)]
        [InlineData("//O\n1O7,15\n  2O 15 ", 40)]
        [InlineData("//_\n11_4_17,3_10", 45)]
        [InlineData("//\n12,", 12)]
        public void ShouldReturnCorrectSumOfIfInputContainsNumbersSeparatedByCommaOrNewLineOrSpecialDelimiter(string numbers, int expectedSum)
        {
            var actual = this._stringCalculator.Add(numbers);
            Assert.Equal(expectedSum, actual);
        }

        [Theory]
        [InlineData("//-\n5-10-20")]
        [InlineData("//-\n13,100-200")]
        [InlineData("//-\n1O7,15\n")]
        public void ShouldThrowExceptionWhenInputContainsMinusDelimiter(string input)
        {
            Assert.Throws<ArgumentException>(() => _stringCalculator.Add(input));
        }

        [Theory]
        [InlineData("1,2, -3, 4", "-3")]
        [InlineData("//n\n1n-2n 3 n4", "-2")]
        [InlineData("-1, 7, -1, -3, 10, -9, 1, 0", "-1, -1, -3, -9")]
        public void ShouldThrowExceptionWithErrorMessageIfInputContainsOneOrMoreNegativeNumbers(string input, string expectedMessage)
        {
            var actual = Assert.Throws<Exception>(() => this._stringCalculator.Add(input));
            Assert.Equal("Negatives are Not Allowed:" + expectedMessage, actual.Message);
        }

        [Theory]
        [InlineData("2000,5", 5)]
        [InlineData("1001, 1000, 1234", 1000)]
        [InlineData("3000, 8 \n1111\n4", 12)]
        public void ShouldIgnoreNumbersBiggerThan_1000(string input, int expected)
        {
            Assert.Equal(expected, this._stringCalculator.Add(input));
        }
    }
}
