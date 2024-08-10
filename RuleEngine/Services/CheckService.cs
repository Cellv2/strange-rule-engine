using Microsoft.Extensions.Options;
using RuleEngine.Extensions.Configuration;
using RuleEngine.Models.Configuration;
using RuleEngine.Services.RuleProcessor;

namespace RuleEngine.Services;

public sealed class CheckService(IOptions<CheckSettings> checkSettingsOptions, IRuleProcessor ruleProcessor) : ICheckService
{
    private CheckSettings checkSettings = checkSettingsOptions.Value;

    public bool DoTheChecks()
    {
        var enabledRules = checkSettings.GetAllEnabledChecks();
        var doAllChecksPass = ruleProcessor.DoAllRulesPass(enabledRules);

        if (doAllChecksPass == false)
        {
            Console.WriteLine("Checks failed");
            return false;
        }

        Console.WriteLine("All checks passed");

        return doAllChecksPass;
    }
}
