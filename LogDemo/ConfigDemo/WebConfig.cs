namespace ConfigDemo;

public class ConfigurationString
{
    public string name { get; set; }
    public string connectionString { get; set; }
    public string providerName { get; set; }
}

public class WebConfig
{
    public IEnumerable<ConfigurationString> configurationStrings;
}