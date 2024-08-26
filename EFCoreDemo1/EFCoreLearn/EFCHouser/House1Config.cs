using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFCHouser;

public class House1Config : IEntityTypeConfiguration<House1>
{
    public void Configure(EntityTypeBuilder<House1> builder)
    {
        builder.ToTable("T_House1");
        builder.HasKey(h => h.Id);
        builder.HasQueryFilter(h => !h.IsDeleted);
        builder.Property(h => h.Owner)
            .HasDefaultValue("");
            // .IsConcurrencyToken();
    }
}