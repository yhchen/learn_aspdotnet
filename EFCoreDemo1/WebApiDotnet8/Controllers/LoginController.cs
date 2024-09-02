using Microsoft.AspNetCore.Mvc;

namespace WebApiDotnet8.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class LoginController : ControllerBase
{
    [HttpPost]
    public ActionResult<LoginResponse> Login(LoginRequest loginRequest)
    {
        if (loginRequest.Username == "admin" && loginRequest.Password == "123456")
        {
            List<ProcessInfo> processInfos = new();
            foreach (var process in System.Diagnostics.Process.GetProcesses())
            {
                processInfos.Add(new ProcessInfo(process.Id, process.ProcessName, process.WorkingSet64.ToString()));
            }
            return new LoginResponse(true, processInfos.ToArray());
        }

        return new LoginResponse(false, null);
    }
}

public record LoginRequest(string Username, string Password);

public record LoginResponse(bool OK, ProcessInfo[] WorkingInfos);

public record ProcessInfo(long Id, string Name, string WorkingSet);

