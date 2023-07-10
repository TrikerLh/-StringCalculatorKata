using FluentAssertions;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;
        [SetUp]
        public void Setup()
        {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void Return_0_when_string_is_empty()
        {
            var result = stringCalculator.Add("");

            result.Should().Be(0);
        }

        [Test]
        public void Return_1()
        {
            var result = stringCalculator.Add("1");

            result.Should().Be(1);
        }

        [Test]
        public void Return_2()
        {
            var result = stringCalculator.Add("2");

            result.Should().Be(2);
        }
    }
}