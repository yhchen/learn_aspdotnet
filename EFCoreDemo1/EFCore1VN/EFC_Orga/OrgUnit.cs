namespace EFCore1VN.EFC_Orga;

public class OrgUnit
{
    public long Id { get; set; }

    public required string Name { get; set; }

    public long? ParentId { get; set; }
    public OrgUnit? Parent { get; set; }
    public List<OrgUnit> Children { get; set; } = new();
}