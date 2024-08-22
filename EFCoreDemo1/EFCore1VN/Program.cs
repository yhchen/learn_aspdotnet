// See https://aka.ms/new-console-template for more information

using EFCore1VN.EFC;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using var dbcontext = new TestDbContext();

// for (int i = 1; i < 10; ++i)
// {
//     var c1 = new Comment()
//     {
//         Message = "Comment1_" + i,
//     };
//     var c2 = new Comment()
//     {
//         Message = "Comment2" + i,
//     };
//
//     var article = new Article()
//     {
//         Title = "Hello world" + i,
//         Message = "Hello Foreign Link" + i,
//         Comments = new() { c1, c2 },
//     };
//
//     dbcontext.Articles.Add(article);
// }
//
//
// var res = await dbcontext.SaveChangesAsync();
// Console.WriteLine("Save Change Async Result: " + res);

// Join操作
{
    var datas = await dbcontext.Articles.Include(a => a.Comments).ToListAsync();
    foreach (var data in datas)
    {
        Console.WriteLine($"{data.Id},{data.Title},{data.Message}");

        foreach (var dataComment in data.Comments)
        {
            Console.WriteLine($"{dataComment.Id},{dataComment.Message}");
        }
    }
}

// 只获取其中几个字段（非全部）
{
    var datas = await dbcontext.Articles.Select(a => new { a.Id, a.Title }).ToListAsync();
    foreach (var data in datas)
    {
        Console.WriteLine($"{data.Id},{data.Title},{data}");
    }
}