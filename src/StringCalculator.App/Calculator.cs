using StringCalculator.App.Exceptions;

namespace StringCalculator.App;

public class Calculator
{
    private readonly CalculatorOptions _options;

    public Calculator(CalculatorOptions options)
    {
        _options = options;
    }

    public int Add(string input, out string formula)
    {
        formula = "0";

        if (string.IsNullOrWhiteSpace(input))
            return 0;

        var (numbersPart, delimiters) = DelimiterParser.Parse(input);

        foreach (var delimiter in delimiters)
            numbersPart = numbersPart.Replace(delimiter, "|");

        var tokens = numbersPart.Split('|');

        if (tokens.Length > 2)
            throw new InvalidOperationException("Maximum of 2 numbers allowed");

        var values = new List<int>();
        var negatives = new List<int>();

        foreach (var token in tokens)
        {
            if (!int.TryParse(token, out var value))
                value = 0;

            if (value < 0)
                negatives.Add(value);

            if (value > _options.UpperBound)
                value = 0;

            values.Add(value);
        }

        if (_options.DenyNegativeNumbers && negatives.Any())
            throw new NegativeNumberException(negatives);

        formula = string.Join("+", values);

        return values.Sum();
    }
}
