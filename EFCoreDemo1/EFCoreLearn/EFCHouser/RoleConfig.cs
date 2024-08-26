using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFCHouser;

public class RoleConfig: IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("T_Role");
        builder.Property(b => b.Name).HasMaxLength(64).IsRequired();
        builder.Property(b => b.RoleName).HasMaxLength(64).IsRequired();
        builder.Property(b => b.Description).HasMaxLength(256).IsRequired();
        builder.Property(b => b.CreateTime)
            .ValueGeneratedOnAdd();
        builder.Property(b => b.UpdateTime)
            .ValueGeneratedOnAddOrUpdate()
            .IsRequired()
            .IsConcurrencyToken();
        builder.Property(b => b.IsDeleted)
            .HasDefaultValue(false)
            .IsRequired();
    }
}