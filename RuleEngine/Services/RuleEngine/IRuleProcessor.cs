namespace RuleEngine.Services.RuleProcessor;

public interface IRuleProcessor
{
    bool DoAllRulesPass(string[] ruleNames);
}
