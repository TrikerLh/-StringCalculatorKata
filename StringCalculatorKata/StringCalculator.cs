using System.ComponentModel;

namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == "") return 0;

        var listOfSeparators = new List<char>() {',', '\n' };

        if (numbers.StartsWith("//"))
        {
            listOfSeparators.Add(numbers[2] );
            numbers = numbers.Substring(4);
        }
        char[] delimiterChars = listOfSeparators.ToArray();
        var numbersArray = numbers.Split(delimiterChars);
        var result = 0;
        foreach (var number in numbersArray)
        {
            result += Convert.ToInt32(number);
        }
        return result;
    }
}