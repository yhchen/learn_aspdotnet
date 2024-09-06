using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace ReflectionDemo.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ResponseCacheController
{
    // GET: api/ResponseCache/GetDate
    // 带缓存的接口，缓存时间为5秒
    [HttpGet]
    [ResponseCache(Duration = 5)]
    public string GetDate()
    {
        return DateTime.Now.ToString(CultureInfo.InvariantCulture);
    }
}