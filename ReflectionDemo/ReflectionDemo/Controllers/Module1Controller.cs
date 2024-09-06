using ClassLibrary1;
using Microsoft.AspNetCore.Mvc;

namespace ReflectionDemo.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Module1Controller
{
    ModelInit1 _module1Init;

    public Module1Controller(ModelInit1 module1Init)
    {
        _module1Init = module1Init;
    }

    [HttpPost]
    public int Add(int x, int y) => _module1Init.Add(x, y);
}