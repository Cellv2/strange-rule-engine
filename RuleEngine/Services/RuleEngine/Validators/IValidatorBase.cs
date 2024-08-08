namespace RuleEngine.Services.RuleProcessor.Validators;

public interface IValidatorBase
{
    public abstract string[] RulesToProcess { get; }
    public abstract bool? IsValid(string ruleName);
}
