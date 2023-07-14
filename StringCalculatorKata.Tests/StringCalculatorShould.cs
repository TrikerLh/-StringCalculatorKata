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

        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("50", 50)]
        public void Return_the_same_number(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("5,5", 10)]
        [TestCase("6,4", 10)]
        [TestCase("50,20", 70)]
        public void Return_add_with_two_number(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3,4,10", 20)]
        public void Return_add_whit_some_numbers(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n23\n37", 70)]
        [TestCase("96,58\n37", 191)]
        public void Return_add_whit_return_separator(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);
            
            result.Should().Be(expected);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//(\n1(2,3", 6)]
        [TestCase("//-\n1-2,3\n4", 10)]
        public void Return_add_using_diferent_separator(string numbers, int expected)
        {
            var result = stringCalculator.Add(numbers);

            result.Should().Be(expected);
        }

        [Test]
        public void throw_exception_when_contains_negative_numbers()
        {
            Action act = () => stringCalculator.Add("1;2;-3");

            act.Should().Throw<NegativesNotAllowed>().And.Number.Should().Be(-3);
        }
    }
}