using FluentAssertions;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorShould
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Return_0_when_string_is_empty()
        {
            var result = new StringCalculator().Add();

            result.Should().Be(0);
        }
    }
}