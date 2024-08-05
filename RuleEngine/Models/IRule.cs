namespace RuleEngine.Models
{
    public interface IRule<T>
    {
        bool IsValid(T value);
    }
}