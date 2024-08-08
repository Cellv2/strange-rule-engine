using RuleEngine.Services.RuleProcessor.Validators;

namespace RuleEngine.Services.RuleEngine.Validators;

public sealed class MessageValidator : IMessageValidator
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
            "SendTheMessage" => TheFunctions.SendTheMessage("this is the message"),
            _ => null
        };
    }
}
