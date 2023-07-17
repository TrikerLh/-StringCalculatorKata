namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string numbers) {
        if (numbers == "") return 0;

        var numbersArray = GetNumbersArray(numbers);
        return TryToAdd(numbersArray);
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

    private static int TryToAdd(IEnumerable<string> numbersArray) {
        var result = 0;
        var negativesNumbers = new List<string>();
        foreach (var number in numbersArray) {
            if (Convert.ToInt32(number) >= 0) 
                result += Convert.ToInt32(number);
            else 
                negativesNumbers.Add(number);
        }
        if (negativesNumbers.Count > 0) {
            throw new NegativesNotAllowed(negativesNumbers);
        }
        return result;
    }
}