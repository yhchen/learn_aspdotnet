using Microsoft.Extensions.DependencyInjection;

namespace MailServices;

public static class MailServiceRegister
{
    public static void RegisterMailService(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddLogService();
        serviceCollection.AddConfigService("config.ini");
        serviceCollection.AddScoped<IMailService, MailService>();
    }
}