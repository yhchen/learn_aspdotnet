using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreExpression;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("T_Books");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Author).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Publisher).IsRequired().HasMaxLength(50);
        builder.Property(x => x.PublishDate).IsRequired();
        builder.Property(x => x.CreateDate).ValueGeneratedOnAdd();
        builder.Property(x => x.UpdateDate).ValueGeneratedOnAddOrUpdate();
        builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(false);
    }
}