namespace ConfigService;

public class DBSetting
{
    string Address { get; set; }
    int Port { get; set; }
    string User { get; set; }
    string Password { get; set; }
}

public class ConfigSetting
{
    public string SmtpService { get; set; }
    public string Proxy { get; set; }
    public DBSetting DB { get; set; }
}