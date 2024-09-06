using Microsoft.AspNetCore.Mvc;
using WebApiDotnet6.Services;

namespace WebApiDotnet6.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class InjectTestController : ControllerBase
{
    // The CalculationService is injected into the controller
    private CalculationService CalculationService { get; init; }

    // The CalculationService is injected into the controller
    public InjectTestController(CalculationService service)
    {
        CalculationService = service;
    }

    [HttpGet]
    // This is a simple controller action that adds two numbers
    public int Add(int a, int b) => CalculationService.Add(a, b);


    [HttpGet]
    // [FromServices] is used to inject a service into a controller action
    public int Add2([FromServices] CalculationService calculationService, int a, int b)
        => calculationService.Add(a, b);
}