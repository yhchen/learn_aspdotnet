namespace EFCore1VN.EFC;

public class Comment
{
    public long Id { get; set; }
    public string Message { get; set; }
    public Article Article { get; set; }
}