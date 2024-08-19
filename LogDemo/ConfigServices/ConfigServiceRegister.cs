using ConfigService;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigServiceRegister
{
    public static void AddConfigService(this IServiceCollection serviceCollection, string configPath)
    {
        serviceCollection.AddScoped<IConfigService, EnvConfigService>();
    }
}