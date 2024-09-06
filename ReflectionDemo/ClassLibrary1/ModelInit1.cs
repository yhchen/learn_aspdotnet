using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;

namespace ClassLibrary1;

// This class is not used in the project, but it is here to show that the same class name can be used in different projects.
public class ModelInit1 : IModuleInitializer
{
    public void Initialize(IServiceCollection services)
    {
        services.AddScoped<ModelInit1>();
    }

    public int Add(int a, int b)
    {
        return a + b;
    }
}