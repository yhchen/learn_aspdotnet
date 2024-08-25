using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore1VN.EFStudentTeacher;

public class StudentConfig : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("T_Student");
        builder.Property(s => s.Name).HasMaxLength(64).IsUnicode().IsRequired();
        builder.HasMany<Teacher>(s => s.Teachers)
            .WithMany(t => t.Students)
            .UsingEntity(str => { str.ToTable("T_Student_Teacher_Relation"); });
        builder.HasQueryFilter(s => !s.IsDeleted);
    }
}