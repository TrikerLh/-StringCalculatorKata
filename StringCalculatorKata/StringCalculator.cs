namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string numbers) {
        if (numbers == "") return 0;

        var numbersArray = GetNumbersArray(numbers);
        return TryToAdd(numbersArray);
    }

    private static string[] GetNumbersArray(string numbers) {
        var delimiterStrings = GetDelimiterChars(numbers);
        if (delimiterStrings.Length > 2)
        {
            var index = numbers.IndexOf('\n');
            numbers = numbers.Substring(index + 1, numbers.Length - index - 1);
        }

        return numbers.Split(delimiterStrings, StringSplitOptions.None);
    }

    private static string[] GetDelimiterChars(string numbers) {
        var listOfDelimeters = new List<string>() { ",", "\n" };
        if (numbers.StartsWith("//"))
            GetDelimeters(numbers.Split('\n')[0], listOfDelimeters);
        return listOfDelimeters.ToArray();
    }

    private static void GetDelimeters(string numbers, List<string> listOfDelimeters)
    {
        var delimeters = numbers.Split('[');
        if (delimeters.Length > 1)
        {
            for (var i = 1; i < delimeters.Length; i++) { 
                listOfDelimeters.Add(delimeters[i].Substring(0, delimeters[i].Length - 1));
            }
        }
        else 
        {
            listOfDelimeters.Add(numbers[2].ToString());
        }
    }

    private static int TryToAdd(IEnumerable<string> numbersArray) {
        var result = 0;
        var negativesNumbers = new List<string>();
        foreach (var number in numbersArray) {
            if (Convert.ToInt32(number) >= 0 && Convert.ToInt32(number) <= 1000) 
                result += Convert.ToInt32(number);
            else if (Convert.ToInt32(number) < 0)
                negativesNumbers.Add(number);
        }
        if (negativesNumbers.Count > 0) {
            throw new NegativesNotAllowed(negativesNumbers);
        }
        return result;
    }
}