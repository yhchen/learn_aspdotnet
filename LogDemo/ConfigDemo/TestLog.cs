using Microsoft.Extensions.Logging;

namespace ConfigDemo;

public class TestLog
{
    private readonly ILogger<TestLog> _logger;

    public TestLog(ILogger<TestLog> logger)
    {
        this._logger = logger;
    }

    public void Debug(string log)
    {
        _logger.LogDebug(log);
    }

    public void Error(string error)
    {
        _logger.LogError(error);
    }
}