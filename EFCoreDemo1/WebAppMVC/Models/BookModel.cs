namespace WebAppMVC.Models;

public class BookModel
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
}