using RuleEngine.Services.RuleProcessor.Validators;

namespace RuleEngine.Services.RuleEngine.Validators;

public sealed class NumberRuleValidator(INumberService numberService) : INumberRuleValidator
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
            "RandomInt" => numberService.RandomInt(5),
            "RandomInt2" => numberService.RandomInt(10),
            _ => null
        };
    }
}
