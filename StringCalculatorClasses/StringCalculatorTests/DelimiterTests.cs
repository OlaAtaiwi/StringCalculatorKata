using StringCalculatorClasses;
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
        public void ShouldReturnFalseIfInputDoesnotContainSpecialDelimiter(string input)
        {
            Assert.False(input.ContainsSpecialDelimiter());
        }

        [Theory]
        [InlineData("//;\n5,10\n20;10")]
        [InlineData("// \n13  100,200")]
        [InlineData("//O\n1O7,15\n  2O 15 ")]
        [InlineData("//_\n11_4_17,3_10")]
        public void ShouldReturnTrueIfInputContainsSpecialDelimiter(string input)
        {
            Assert.True(input.ContainsSpecialDelimiter());
        }
        
        [Theory]
        [InlineData("1,2,3")]
        [InlineData("1\n5\n88")]
        public void ShouldReturnEmptyStringIfInputDoesnotContainSpecialDelimiter(string input)
        {
            string expected = "";
            Assert.Equal(input.GetSpecialDelimiter(), expected);
        }

        [Theory]
        [InlineData("//;\n5,10\n20;10", ";")]
        [InlineData("// \n13  100,200", " ")]
        [InlineData("//O\n1O7,15\n  2O 15 ", "O")]
        [InlineData("//_\n11_4_17,3_10", "_")]
        [InlineData("//Ola\n11Ola4Ola17", "Ola")]
        public void ShouldReturnTheSpecialDelimiterIfInputStringContains(string input, string expected)
        {
            Assert.Equal(input.GetSpecialDelimiter(), expected);
        }
    }
}
