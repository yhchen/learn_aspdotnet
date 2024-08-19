using Microsoft.Extensions.Options;

namespace ConfigService;

internal class EnvConfigService : IConfigService
{
    private IOptionsSnapshot<ConfigSetting> _configure;

    public EnvConfigService(IOptionsSnapshot<ConfigSetting> configure)
    {
        this._configure = configure;
    }

    public ConfigSetting Config() => this._configure.Value;
}