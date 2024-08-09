using RuleEngine.Services.RuleProcessor.Validators;

namespace RuleEngine.Services.RuleEngine.Validators;

public sealed class MessageRuleValidator(IMessageService messageService) : IMessageRuleValidator
{
    public string[] RulesToProcess => ["SendTheMessage"];

    public bool? IsValid(string ruleName)
    {
        if (!RulesToProcess.Contains(ruleName))
        {
            return null;
        }

        return ruleName switch
        {
            "SendTheMessage" => messageService.IsMessageValid("this is the message"),
            _ => null
        };
    }
}
