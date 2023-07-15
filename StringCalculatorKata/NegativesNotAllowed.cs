namespace StringCalculatorKata;

public class NegativesNotAllowed : Exception
{
    public NegativesNotAllowed(string message) : base (message) { }
}