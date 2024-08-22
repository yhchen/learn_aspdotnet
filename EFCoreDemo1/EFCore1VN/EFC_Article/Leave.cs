namespace EFCore1VN.EFC_1;

public class Leave
{
    public long Id { get; set; }

    public long RequestId { get; set; }
    public User Requset { get; set; }

    public long ApproverId { get; set; }
    public User Approver { get; set; }

    public string Remarks { get; set; }
}