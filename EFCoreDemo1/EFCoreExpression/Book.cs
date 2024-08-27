namespace EFCoreExpression;

public class Book
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public required string Author { get; set; }
    public required string Publisher { get; set; }
    public DateTime PublishDate { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public bool IsDeleted { get; set; }
}