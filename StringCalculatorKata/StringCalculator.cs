using System.ComponentModel;

namespace StringCalculatorKata;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (numbers == "")
            return 0;

        var numbersArray = numbers.Split(',');
        var result = 0;
        foreach (var number in numbersArray)
        {
            result += Convert.ToInt32(number);
        }
        return result;
    }
}