namespace RuleEngine.Services;

public sealed class MessageService : IMessageService
{
    public string SendTheMessage(string message) => $"The message was: {message}";
}
