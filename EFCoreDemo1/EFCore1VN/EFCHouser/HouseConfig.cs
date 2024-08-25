using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFCHouser;

public class HouseConfig : IEntityTypeConfiguration<House>
{
    public void Configure(EntityTypeBuilder<House> builder)
    {
        builder.ToTable("T_House");
        builder.HasQueryFilter(h => !h.IsDeleted);
        builder.Property(h => h.Owner).IsConcurrencyToken();
    }
}