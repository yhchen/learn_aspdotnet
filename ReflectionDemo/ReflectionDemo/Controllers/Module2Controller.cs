using ClassLibrary2;
using Microsoft.AspNetCore.Mvc;

namespace ReflectionDemo.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class Module2Controller : ControllerBase
{
    private ModelInit2 _modelInit2;

    public Module2Controller(ModelInit2 modelInit2)
    {
        _modelInit2 = modelInit2;
    }

    [HttpPost]
    public int Multiply(int x, int y) => _modelInit2.Multiply(x, y);
}