using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFC;

public class ArticleConfig : IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("T_Article");
        builder.Property(a => a.Title).HasMaxLength(128).IsRequired().IsUnicode();
        builder.Property(a => a.Message).HasMaxLength(512).IsRequired().IsUnicode();
    }
}