using Microsoft.Extensions.DependencyInjection;
using Zack.Commons;

namespace ClassLibrary2;

// This class is not used in the project, but it is here to show that the same class name can be used in different projects.
public class ModelInit2 : IModuleInitializer
{
    public void Initialize(IServiceCollection services)
    {
        services.AddScoped<ModelInit2>();
    }

    public int Multiply(int x, int y) => x * y;
}