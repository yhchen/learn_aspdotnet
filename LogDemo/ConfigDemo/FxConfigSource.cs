using Microsoft.Extensions.Configuration;

namespace ConfigDemo;

public class FxConfigSource : FileConfigurationSource
{
    public override IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new FxConfigProvider(this);
    }
}