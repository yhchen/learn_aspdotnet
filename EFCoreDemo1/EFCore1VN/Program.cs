// See https://aka.ms/new-console-template for more information

using EFCore1VN.EFC;
using EFCore1VN.EFC_Orga;
using EFCore1VN.EFStudentTeacher;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

await using var testDbContext = new TestDbContext();

// await InsertArticleAndComment(testDbContext);
// await QueryArticleJoinWithComment(testDbContext);
// await QueryArticleParticle(testDbContext);
// await InsertOrgUnits(testDbContext);
// await QueryOrgUnit(testDbContext);
await InsertStudentsAndTeachers(testDbContext);

// --------------------------------------------------------------------------------
async Task InsertArticleAndComment(TestDbContext dbContext)
{
    for (int i = 1; i < 10; ++i)
    {
        var c1 = new Comment()
        {
            Message = "Comment1_" + i,
        };
        var c2 = new Comment()
        {
            Message = "Comment2" + i,
        };

        var article = new Article()
        {
            Title = "Hello world" + i,
            Message = "Hello Foreign Link" + i,
            Comments = new() { c1, c2 },
        };

        dbContext.Articles.Add(article);
    }


    var res = await dbContext.SaveChangesAsync();
    Console.WriteLine("Save Change Async Result: " + res);
}

// --------------------------------------------------------------------------------
// Join操作
async Task QueryArticleJoinWithComment(TestDbContext dbContext)
{
    var datas = await dbContext.Articles.Include(a => a.Comments).ToListAsync();
    foreach (var data in datas)
    {
        Console.WriteLine($"{data.Id},{data.Title},{data.Message}");

        foreach (var dataComment in data.Comments)
        {
            Console.WriteLine($"{dataComment.Id},{dataComment.Message}");
        }
    }
}

// --------------------------------------------------------------------------------
// 只获取其中几个字段（非全部）
async Task QueryArticleParticle(TestDbContext dbContext)
{
    var datas = await dbContext.Articles.Select(a => new { a.Id, a.Title }).ToListAsync();
    foreach (var data in datas)
    {
        Console.WriteLine($"{data.Id},{data.Title},{data}");
    }
}


// --------------------------------------------------------------------------------
// org unit insert
async Task InsertOrgUnits(TestDbContext dbContext)
{
    var root = new OrgUnit()
    {
        Name = "总经理", Children =
        {
            new()
            {
                Name = "总经办", Children =
                {
                    new() { Name = "财务" }, new() { Name = "战略部" }
                }
            },
            new()
            {
                Name = "市场部", Children =
                {
                    new() { Name = "公关部" }, new() { Name = "渠道部" }, new() { Name = "商务部" }
                }
            },
            new()
            {
                Name = "产品部", Children =
                {
                    new() { Name = "技术部" }, new() { Name = "策划部" }, new() { Name = "美术中心" }
                }
            }
        }
    };
    dbContext.OrgUnits.Add(root);
    await dbContext.SaveChangesAsync();
}

// --------------------------------------------------------------------------------
// org unit Query
async Task QueryOrgUnit(TestDbContext dbContext)
{
    var orgList = await dbContext.OrgUnits.ToListAsync();
    Dictionary<long, OrgUnit> dict = new();
    OrgUnit? root = null;
    foreach (var org in orgList)
    {
        dict[org.Id] = org;
    }

    void Print(OrgUnit unit, int deep = 0)
    {
        Console.WriteLine(new string('\t', deep) + $"{unit.Name}");
        foreach (var unitChild in unit.Children)
        {
            Print(unitChild, deep + 1);
        }
    }

    foreach (var (_, orgUnit) in dict)
    {
        if (orgUnit.ParentId == null)
        {
            root = orgUnit;
            continue;
        }

        var parent = dict[(long)orgUnit.ParentId];
        orgUnit.Parent = parent;
        parent.Children.Add(orgUnit);
    }

    if (root != null) Print(root);


    await dbContext.SaveChangesAsync();
}

// --------------------------------------------------------------------------------
// insert student and teachers
async Task InsertStudentsAndTeachers(TestDbContext dbContext)
{
    List<Teacher> teachers = new();
    List<Student> students = new();
    for (int i = 1; i <= 10; ++i)
    {
        teachers.Add(new() { Name = "Teacher_" + i });
        students.Add(new() { Name = "Student_" + i });
    }

    foreach (var teacher in teachers)
    {
        teacher.Students.AddRange(students);
    }

    dbContext.Teachers.AddRange(teachers);
    await dbContext.SaveChangesAsync();
}

// --------------------------------------------------------------------------------