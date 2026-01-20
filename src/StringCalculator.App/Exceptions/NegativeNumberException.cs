namespace StringCalculator.App.Exceptions;

public class NegativeNumberException : Exception
{
    public NegativeNumberException(IEnumerable<int> negatives)
        : base($"Negatives not allowed: {string.Join(", ", negatives)}")
    {
    }
}
