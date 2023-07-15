using System.ComponentModel;

namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string numbers) {
        if (numbers == "") return 0;

        var numbersArray = GetNumbersArray(numbers);
        var result = 0;
        foreach (var number in numbersArray) {
            if (Convert.ToInt32(number) >= 0) {
                result = result + Convert.ToInt32(number);
            }
            else {
                throw new NegativesNotAllowed(Convert.ToInt32(number));
            }
        }

        return result;
    }

    private static string[] GetNumbersArray(string numbers) {
        var delimiterChars = GetDelimiterChars(numbers);
        if (delimiterChars.Length > 2) numbers = numbers.Substring(4);
        return numbers.Split(delimiterChars);
    }

    private static char[] GetDelimiterChars(string numbers) {
        var listOfSeparators = new List<char>() { ',', '\n' };
        if (numbers.StartsWith("//")) 
            listOfSeparators.Add(numbers[2]);
        return listOfSeparators.ToArray();
    }
}