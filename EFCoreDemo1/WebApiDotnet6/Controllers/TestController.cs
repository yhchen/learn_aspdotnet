using Microsoft.AspNetCore.Mvc;
using WebApiDotnet6.Model;

namespace WebApiDotnet6.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("person")]
    public PersonResponse GetPerson()
    {
        return new PersonResponse("John Doe", 30);
    }

    [HttpPost("save-note")]
    public string SaveNote(SaveNoteRequest request)
    {
        System.IO.File.WriteAllText(request.Title + ".txt", request.Description);
        return request.Title + " saved successfully";
    }
}