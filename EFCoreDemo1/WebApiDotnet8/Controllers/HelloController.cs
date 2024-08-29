﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDotnet8.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class HelloController : ControllerBase
{
    /// <summary>
    /// 加法
    /// </summary>
    /// <param name="i">加数1</param>
    /// <param name="j">加数2</param>
    /// <returns>返回i+j</returns>
    [HttpGet]
    public int Add(int i, int j)
    {
        return i + j;
    }

    [HttpGet]
    public ActionResult<int> Add1(int i, int j)
    {
        if (((long)i + (long)j) >= (long)int.MaxValue) return BadRequest("超出最大值");
        return i + j;
    }

    [HttpGet]
    public string Add2()
    {
        return System.IO.File.ReadAllText("D://git凭据.txt");
    }

    [HttpGet("{i}/{j}")]
    public int Add3(int i, int j)
    {
        return i + j;
    }

    [HttpPost("{i}")]
    public int Add4([FromRoute(Name = "i")] int i // FromRoute 可有可无
        , [FromQuery] int j) // FromQuery 可有可无
    {
        return i + j;
    }
}