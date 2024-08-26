namespace EFCore1VN.EFC;

public class Article
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public List<Comment> Comments { get; set; } = new();
}