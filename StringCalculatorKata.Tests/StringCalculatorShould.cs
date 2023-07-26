using FluentAssertions;

namespace StringCalculatorKata.Tests
{
    public class StringCalculatorShould
    {
        private StringCalculator stringCalculator;
        [SetUp]
        public void Setup() {
            stringCalculator = new StringCalculator();
        }

        [Test]
        public void Return_0_when_string_is_empty() {
            var result = Add("");

            result.Should().Be(0);
        }

        [TestCase("1",1)]
        [TestCase("2", 2)]
        [TestCase("50", 50)]
        public void Return_the_same_number(string numbers, int expected) {
            var result = Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("5,5", 10)]
        [TestCase("6,4", 10)]
        [TestCase("50,20", 70)]
        public void Return_add_with_two_number(string numbers, int expected) {
            var result = Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1,2,3", 6)]
        [TestCase("1,2,3,4", 10)]
        [TestCase("1,2,3,4,10", 20)]
        public void Return_add_whit_some_numbers(string numbers, int expected) {
            var result = Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1\n2,3", 6)]
        [TestCase("10\n23\n37", 70)]
        [TestCase("96,58\n37", 191)]
        public void Return_add_whit_return_separator(string numbers, int expected) {
            var result = Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("//;\n1;2", 3)]
        [TestCase("//(\n1(2,3", 6)]
        [TestCase("//-\n1-2,3\n4", 10)]
        public void Return_add_using_diferent_separator(string numbers, int expected) {
            var result = Add(numbers);

            result.Should().Be(expected);
        }

        [TestCase("1,2,-3", "Negative not allowed : -3")]
        [TestCase("1,2,-3,-4", "Negative not allowed : -3, -4")]
        [TestCase("1,2\n-3,-4", "Negative not allowed : -3, -4")]
        [TestCase("//(\n1(2,-89(-90", "Negative not allowed : -89, -90")]
        [TestCase("//t\n1t2,3\n4\n-85t5,-25t-99", "Negative not allowed : -85, -25, -99")]
        public void throw_exception_when_contains_negative_numbers(string numbers, string expected) {
            Action act = () => Add(numbers);

            act.Should().Throw<NegativesNotAllowed>().And.Message.Should().Be(expected);
        }

        [TestCase("1001, 2", 2)]
        [TestCase("//;\n1;2005", 1)]
        [TestCase("//(\n1(2,3225\n5,10(4(58962", 22)]
        public void Ignore_numbers_greater_than_a_thousand(string numbers, int expected)
        {
            var result = Add(numbers);

            result.Should().Be(expected);
        }

        [Test]
        public void Separators_with_different_lengths()
        {
            var result = Add("//[***]\n1***2***3");

            result.Should().Be(6);
        }

        private int Add(string numbers) {
            return stringCalculator.Add(numbers);
        }
    }
}