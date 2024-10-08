﻿namespace RuleEngine.Services.RuleProcessor.Validators;

public interface IRuleValidatorBase
{
    public abstract string[] RulesToProcess { get; }
    public abstract bool? IsValid(string ruleName);
}
