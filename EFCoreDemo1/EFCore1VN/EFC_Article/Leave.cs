namespace EFCore1VN.EFC_1;

public class Leave
{
    public long Id { get; set; }

    public long RequestId { get; set; }
    public required User Requset { get; set; }

    public long? ApproverId { get; set; }
    public User? Approver { get; set; }

    public required string Remarks { get; set; }
    
    public bool IsDeleted { get; set; }
}