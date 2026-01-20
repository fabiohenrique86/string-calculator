using StringCalculator.App;

var calculator = new Calculator(new CalculatorOptions());

Console.WriteLine("String Calculator (.NET 9)");
Console.WriteLine("Press Ctrl+C to exit.");

while (true)
{
    Console.Write("Input: ");
    var input = Console.ReadLine();

    try
    {
        var result = calculator.Add(input ?? string.Empty, out var formula);
        Console.WriteLine($"{formula} = {result}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
