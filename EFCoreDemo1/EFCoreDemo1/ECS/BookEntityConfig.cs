using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo1;

[Comment("书本表")]
[Index(nameof(Title), IsUnique = true)]
public class Book
{
    [Comment("主键")] public long Id { get; set; }

    [Comment("标题"), Required, MaxLength(50), DefaultValue("")]
    public string Title { get; set; } = "";

    [Comment("发布日期")] public DateTime PubTime { get; set; }

    [Comment("价格")] public double Price { get; set; }

    [Comment("作者名"), Required, MaxLength(50), DefaultValue("")]
    public string AuthName { get; set; } = "";
}

public class BookEntityConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("T_Books");
        builder.Property(b => b.Title).HasMaxLength(50).IsRequired();
    }
}