// See https://aka.ms/new-console-template for more information

using ConfigDemo;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

ServiceCollection serviceCollection = new();
serviceCollection.AddLogging(logBuilder =>
{
    logBuilder.AddConsole();
    logBuilder.SetMinimumLevel(LogLevel.Trace);
});
// serviceCollection.AddScoped<TestLog>();
serviceCollection.AddSingleton<TestLog>();
using var serviceProvider = serviceCollection.BuildServiceProvider();

var testLog = serviceProvider.GetRequiredService<TestLog>();
testLog.Debug("Debug Log");
testLog.Error("Error Log");