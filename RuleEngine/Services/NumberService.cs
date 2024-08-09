namespace RuleEngine.Services;

public sealed class NumberService : INumberService
{
    public bool RandomInt(int number) => number >= 5;
}
