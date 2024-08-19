using ConfigService;
using LogServices;

namespace MailServices;

internal class MailService : IMailService
{
    public MailService(ILogProvider logProvider, IConfigService configService)
    {
        this._logProvider = logProvider;
        this._configService = configService;
    }

    private ILogProvider _logProvider;
    private IConfigService _configService;

    public void Send(string title, string to, string context)
    {
        string smtpService = _configService.Config().SmtpService;
        this._logProvider.LogInfo($"准备发送， 地址:{smtpService}");
        Console.WriteLine($"发邮件 标题:{title} 发送给:{to} 内容:{context}");
        this._logProvider.LogInfo("发送完成");
    }
}