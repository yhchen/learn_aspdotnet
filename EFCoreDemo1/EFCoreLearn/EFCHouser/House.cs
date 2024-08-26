namespace EFCore1VN.EFCHouser;

public class House
{
    public long Id { get; set; }

    public string Address { get; set; }

    public string Owner { get; set; }

    public bool IsDeleted { get; set; }
}