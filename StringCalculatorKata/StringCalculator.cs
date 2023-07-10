using System.ComponentModel;

namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == "")
            return 0;

        char[] delimiterChars = {',','\n' };
        var numbersArray = numbers.Split(delimiterChars);
        var result = 0;
        foreach (var number in numbersArray)
        {
            result += Convert.ToInt32(number);
        }
        return result;
    }
}