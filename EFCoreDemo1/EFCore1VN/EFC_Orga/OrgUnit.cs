namespace EFCore1VN.EFC_Orga;

public class OrgUnit
{
    public long Id { get; set; }
    public long ParentId;
    public OrgUnit Parent;
    public List<OrgUnit> Children { get; set; } = new();
}