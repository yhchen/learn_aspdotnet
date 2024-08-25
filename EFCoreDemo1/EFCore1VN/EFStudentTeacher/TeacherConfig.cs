using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFStudentTeacher;

public class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("T_Teacher");
        builder.Property(t => t.Name).HasMaxLength(64).IsUnicode().IsRequired();
        builder.HasQueryFilter(t => !t.IsDeleted);
    }
}