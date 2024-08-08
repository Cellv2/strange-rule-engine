using RuleEngine.Services.RuleProcessor.Validators;

namespace RuleEngine.Services.RuleEngine.Validators;

public sealed class NumberValidator : INumberValidator
{
    public string[] RulesToProcess => ["RandomInt", "RandomInt2"];

    public bool? IsValid(string ruleName)
    {
        if (!RulesToProcess.Contains(ruleName))
        {
            return null;
        }

        return ruleName switch
        {
            "RandomInt" => TheFunctions.RandomInt(1, 2),
            "RandomInt2" => TheFunctions.RandomInt(100, 200),
            _ => null
        };
    }
}
