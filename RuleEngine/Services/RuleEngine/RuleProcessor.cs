using RuleEngine.Services.RuleProcessor.Validators;

namespace RuleEngine.Services.RuleProcessor;

public sealed class RuleProcessor(IEnumerable<IRuleValidatorBase> validators) : IRuleProcessor
{
    public bool DoAllRulesPass(string[] rulesToProcess)
    {
        foreach (var rule in rulesToProcess)
        {
            var processed = DoesRulePass(rule);
            if (processed.HasValue == false || processed == false)
            {
                return false;
            }
        }

        return true;
    }

    private bool? DoesRulePass(string ruleName)
    {
        List<bool?> results = [];

        foreach (var validator in validators)
        {
            var isValid = validator.IsValid(ruleName);
            if (isValid is true)
            {
                return true;
            }

            results.Add(isValid);
        }

        if (results.All(result => result.HasValue == false))
        {
            Console.WriteLine($"Rule {ruleName} was not processed by any rule validators");
            return null;
        }

        return false;
    }
}
