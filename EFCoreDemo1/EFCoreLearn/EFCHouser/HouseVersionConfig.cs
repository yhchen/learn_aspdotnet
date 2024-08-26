using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFCHouser;

public class HouseVersionConfig : IEntityTypeConfiguration<HouseVersion>
{
    public void Configure(EntityTypeBuilder<HouseVersion> builder)
    {
        builder.ToTable("T_HouseRawVersion");
        builder.Property(b => b.Name).HasMaxLength(64).IsRequired();
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