using System.ComponentModel.DataAnnotations;

namespace EFCore1VN.EFCHouser;

public class HouseVersion
{
    public long Id { get; set; }
    public required string Name { get; set; }

    public string Owner { get; set; }

    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }

    public bool IsDeleted { get; set; }
}