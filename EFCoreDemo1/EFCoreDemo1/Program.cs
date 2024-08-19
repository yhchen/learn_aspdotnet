// See https://aka.ms/new-console-template for more information

using EFCoreDemo1;
using Microsoft.EntityFrameworkCore;

using TestDbContext testDbContext = new();

// Book book = new()
// {
//     Title = "第二本书",
//     AuthName = "yhchen",
//     Price = 100000000,
//     PubTime = DateTime.Now,
// };
//
// testDbContext.Books.Add(book);
// testDbContext.Update(book);
// await testDbContext.SaveChangesAsync();

var books = await testDbContext.Books
    // .Where(book => book.Title == "第二本书")
    .OrderByDescending(book => book.Price)
    .ToListAsync();
Console.WriteLine(books);