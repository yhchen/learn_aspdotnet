using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFC_Orga;

public class OrgUnitConfig : IEntityTypeConfiguration<OrgUnit>
{
    public void Configure(EntityTypeBuilder<OrgUnit> builder)
    {
        builder.ToTable("T_OrgUnit");
        builder.HasOne<OrgUnit>(o => o.Parent)
            .WithMany(o => o.Children)
            .HasForeignKey(o => o.ParentId)
            .IsRequired(false)
            ;
        builder.Property(o => o.Name).HasMaxLength(50).IsUnicode().IsRequired();
    }
}