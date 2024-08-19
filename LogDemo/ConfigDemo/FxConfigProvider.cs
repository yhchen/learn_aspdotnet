using System.Xml;
using Microsoft.Extensions.Configuration;

namespace ConfigDemo;

public class FxConfigProvider : FileConfigurationProvider
{
    private FileConfigurationSource _source;

    public FxConfigProvider(FileConfigurationSource source) : base(source)
    {
        _source = source;
    }

    public override void Load(Stream stream)
    {
        var data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        XmlDocument xmlDocument = new();
        xmlDocument.Load(stream);
        var xmlNodeList = xmlDocument.SelectNodes("/configuration/configurationStrings/add");
        if (xmlNodeList != null)
        {
            foreach (XmlNode xmlNode in xmlNodeList)
            {
                string name = xmlNode.Attributes["name"].Value;
                string connectionString = xmlNode.Attributes["connectionString"].Value;
                string attProviderName = xmlNode.Attributes["providerName"].Value;
            }
        }
    }
}