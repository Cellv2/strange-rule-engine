namespace RuleEngine.Services;

public sealed class MessageService : IMessageService
{
    public bool IsMessageValid(string message) => !message.Contains("1");
}
