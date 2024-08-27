using Microsoft.AspNetCore.Mvc;
using WebAppMVC.Models;

namespace WebAppMVC.Controllers;

public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger)
    {
        _logger = logger;
    }

    public IActionResult GetRandomBook()
    {
        var bookModel = new BookModel
        {
            Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Publisher = "Charles Scribner's Sons",
            PublishDate = new DateTime(1925, 4, 10)
        };
        _logger.LogInformation("Returning random book {@BookModel}", bookModel);
        return View(bookModel);
    }
}