namespace RuleEngine.Models;

public abstract class Rule<T> : IRule<T>
{
    public abstract bool IsValid(T value);
}

public abstract class RuleEngine<T>
{
    public IEnumerable<Rule<T>> Rules { get; set; }
}

public sealed class MessageValidator
{
    string[] rules = ["SendTheMessage"];

    public string? IsValid(string ruleName)
    {
        if (!rules.Contains(ruleName))
        {
            return null;
        }

        return (ruleName) switch
        {
            "SendTheMessage" => TheFunctions.SendTheMessage("this is the message"),
            _ => null
        };
    }
}

public sealed class NumberValidator
{
    string[] rules = ["RandomInt", "RandomInt2"];

    public int? IsValid(string ruleName)
    {
        if (!rules.Contains(ruleName)) {
            return null;
        }

        return (ruleName) switch
        {
            "RandomInt" => TheFunctions.RandomInt(1, 2),
            "RandomInt2" => TheFunctions.RandomInt(100, 200),
            _ => null
        };
    }
}

public static class TheFunctions
{
    public static string SendTheMessage(string message) => $"The message was: {message}";

    public static int RandomInt(int min, int max) => new Random().Next(min, max);
}