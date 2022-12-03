using StringCalculatorClasses;
using System;
using Xunit;

namespace StringCalculatorTests
{
    public class DelimiterTests
    {
        [Theory]
        [InlineData(";\n5,10\n20;10")]
        [InlineData(" \n13")]
        [InlineData("\n1O7,15 ")]
        [InlineData("")]
        public void ContainsSpecialDelimiter_ShouldReturnFalse_IfInputDoesnotContainSpecialDelimiter(string input)
        {
            Assert.False(input.ContainsSpecialDelimiter());
        }

        [Theory]
        [InlineData("//;\n5,10\n20;10")]
        [InlineData("// \n13  100,200")]
        [InlineData("//O\n1O7,15\n  2O 15 ")]
        [InlineData("//_\n11_4_17,3_10")]
        public void ContainsSpecialDelimiter_ShouldReturnTrue_IfInputContainsSpecialDelimiter(string input)
        {
            Assert.True(input.ContainsSpecialDelimiter());
        }

        [Theory]
        [InlineData("1,2,3")]
        [InlineData("1\n5\n88")]
        public void GetSpecialDelimiter_ShouldReturnEmptyString_IfInputDoesnotContainSpecialDelimiter(string input)
        {
            var expected = "";
            Assert.Equal(input.GetSpecialDelimiter(), expected);
        }

        [Theory]
        [InlineData("//;\n5,10\n20;10", ";")]
        [InlineData("// \n13  100,200", " ")]
        [InlineData("//O\n1O7,15\n  2O 15 ", "O")]
        [InlineData("//_\n11_4_17,3_10", "_")]
        [InlineData("//Ola\n11Ola4Ola17", "Ola")]
        public void GetSpecialDelimiter_ShouldReturnTheSpecialDelimiter_IfInputStringContainsSpecialDelimiter(string input, string expected)
        {
            Assert.Equal(input.GetSpecialDelimiter(), expected);
        }

        [Theory]
        [InlineData("//-\n1,2,3")]
        [InlineData("//-")]
        public void GetSpecialDelimiter_ShouldThrowException_WhenInputContainsMinusDelimiter(string input)
        {
            Assert.Throws<ArgumentException>(() => input.GetSpecialDelimiter());
        }
    }
}
