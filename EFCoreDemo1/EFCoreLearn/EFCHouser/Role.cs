namespace EFCore1VN.EFCHouser;

public class Role
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string RoleName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
    public bool IsDeleted { get; set; }
}