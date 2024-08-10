using RuleEngine.Services.RuleProcessor.Validators;

namespace RuleEngine.Services.RuleEngine.Validators;

public sealed class MessageRuleValidator(IMessageService messageService) : IMessageRuleValidator
{
    public string[] RulesToProcess => ["MessageChecksEnabled"];

    public bool? IsValid(string ruleName)
    {
        if (!RulesToProcess.Contains(ruleName))
        {
            return null;
        }

        return ruleName switch
        {
            "MessageChecksEnabled" => messageService.IsMessageValid("this is the message"),
            _ => null
        };
    }
}
