namespace RuleEngine.Services.RuleProcessor;

public interface IRuleProcessor
{
    bool DoAllRulesPass(string[] ruleNames);
}

public sealed class RuleProcessor : IRuleProcessor
{
    public bool DoAllRulesPass(string[] ruleNames)
    {

    }

    private bool DoesRulePass(string ruleName)
    {

    }
}
