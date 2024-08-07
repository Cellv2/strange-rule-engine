namespace RuleEngine.Models;

public interface IRule
{
    public abstract string[] RulesToProcess { get; }
    public abstract bool IsValid();
}