using Microsoft.Extensions.Options;
using RuleEngine.Models.Configuration;

namespace RuleEngine.Services;

public sealed class CheckService(IOptions<CheckSettings> checkSettingsOptions) : ICheckService
{
    private CheckSettings checkSettings = checkSettingsOptions.Value;

    public void DoTheChecks()
    {
        Console.WriteLine(checkSettings.IntChecksEnabled);
        Console.WriteLine(checkSettings.MessageChecksEnabled);
    }
}
