using LogServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class LogProvideRegister
{
    public static void AddLogService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ILogProvider, ConsoleLogProvider>();
    }
}