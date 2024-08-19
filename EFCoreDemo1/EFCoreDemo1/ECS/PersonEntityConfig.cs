using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo1;

[Comment("角色表")]
public class Person
{
    [Comment("主键")]
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }

    [Comment("名字"), Required] public string Name { get; set; }

    [Comment("年龄"), Required] public int Age { get; set; }

    [Comment("出生地"), Required] public string BirthPlace { get; set; }
}

public class PersonEntityConfig : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("T_Person");
    }
}