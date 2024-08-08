using RuleEngine.Models.Configuration;

namespace RuleEngine.Extensions.Configuration;

public static class CheckSettingsExtensions
{
    public static string[] GetAllEnabledChecks(this CheckSettings checkSettings)
    {
        // could do this nicer with an expression
        var ruleNames = typeof(CheckSettings).GetProperties()
                                             .Where(x => x.PropertyType == typeof(bool))
                                             .Where(x => x.GetValue(checkSettings) is true)
                                             .Select(x => x.Name)
                                             .ToArray();

        return ruleNames;
    }
}
