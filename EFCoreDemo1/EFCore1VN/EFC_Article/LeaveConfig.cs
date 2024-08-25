using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFC_1;

public class LeaveConfig : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> builder)
    {
        builder.ToTable("T_Leave");
        builder.HasOne<User>(l => l.Requset).WithMany().HasForeignKey(l => l.RequestId).IsRequired();
        builder.HasOne<User>(l => l.Approver).WithMany().HasForeignKey(l => l.ApproverId).IsRequired();
        builder.HasQueryFilter(l => !l.IsDeleted);
    }
}