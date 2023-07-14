namespace StringCalculatorKata;

public class NegativesNotAllowed : Exception
{
    public int Number { get; set; }

    public NegativesNotAllowed(int number)
    {
        this.Number = number;
    }
}