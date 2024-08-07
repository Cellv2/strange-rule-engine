namespace RuleEngine.Services;

public sealed class NumberService : INumberService
{
    public int RandomInt(int min, int max) => new Random().Next(min, max);
}
