using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFC;

public class CommentConfig : IEntityTypeConfiguration<Comment>

{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("T_Comment");
        builder.Property(c => c.Message).HasMaxLength(512).IsUnicode().IsRequired();
        builder.HasOne<Article>(c => c.Article).WithMany(a => a.Comments).IsRequired();
    }
}