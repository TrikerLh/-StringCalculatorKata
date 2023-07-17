namespace StringCalculatorKata;

public class NegativesNotAllowed : Exception
{
    public NegativesNotAllowed(IReadOnlyList<string> negativeNumbers) : base(GetExceptionMessage(negativeNumbers)) {}


    private static string GetExceptionMessage(IReadOnlyList<string> negativesNumbers) {
        var message = "Negative not allowed : ";
        for (var i = 0; i < negativesNumbers.Count; i++) {
            message += negativesNumbers[i];
            if (i < negativesNumbers.Count - 1)
                message += ", ";
        }
        return message;
    }
}