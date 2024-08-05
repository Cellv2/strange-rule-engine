namespace RuleEngine.Models;

public abstract class Rule<T> : IRule<T>
{
    public abstract bool IsValid(T value);
}

public abstract class RuleEngine<T>
{
    public T Ctx { get; set; }

    public IEnumerable<Rule<T>> Rules { get; set; }

    public virtual IDictionary<string, string> All(string valid = "Ok")
    {
        return Rules
                 .Where(r => r.IsValid(Ctx) == false)
                 .Select(r => new KeyValuePair<string, string>(
                     r.ReasonIfFails, nameof(r)
                 ))
                 .ToDictionary(pair => pair.Key, pair => pair.Value);
    }
}

public static class TheFunctions
{
    public static string SendTheMessage(string message) => $"The message was: {message}";

    public static int RandomInt(int min, int max) => new Random().Next(min, max);
}