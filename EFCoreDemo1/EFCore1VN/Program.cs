// See https://aka.ms/new-console-template for more information

using System.Data;
using System.Linq;
using EFCore1VN.EFC;
using EFCore1VN.EFC_1;
using EFCore1VN.EFC_Orga;
using EFCore1VN.EFCHouser;
using EFCore1VN.EFStudentTeacher;
using Microsoft.EntityFrameworkCore;
using MySqlConnector.Logging;

await using var testDbContext = new TestDbContext();

try
{
    // await InsertArticleAndComment(testDbContext);
    // await QueryArticleJoinWithComment(testDbContext);
    // await QueryArticleParticle(testDbContext);
    // await InsertOrgUnits(testDbContext);
    // await QueryOrgUnit(testDbContext);
    // await InsertStudentsAndTeachers(testDbContext, 100);
    // await QueryTeachersAndStudents(testDbContext, 2, 5);
    // await ExecuteOriginSql(testDbContext);
    await 悲观并发锁();
    await 乐观并发锁();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

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
async Task InsertStudentsAndTeachers(TestDbContext dbContext, int count)
{
    List<Teacher> teachers = new();
    List<Student> students = new();
    for (int i = 1; i <= count; ++i)
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
// query Teachers
async Task QueryTeachersAndStudents(TestDbContext dbContext, int page, int pageSize)
{
    var totalCount = await dbContext.Teachers.CountAsync();
    var maxPage = (totalCount + pageSize - 1) / pageSize;
    Console.WriteLine($"Total Count: {totalCount}, Max Page Count: {maxPage}");
    var teachers = await dbContext.Teachers.Include(t => t.Students)
        .IgnoreQueryFilters() // 忽略全局搜索过滤器
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();
    foreach (var teacher in teachers)
    {
        Console.WriteLine($"{teacher.Id},{teacher.Name}");
        foreach (var teacherStudent in teacher.Students)
        {
            Console.WriteLine($"\t{teacherStudent.Id},{teacherStudent.Name}");
        }
    }
}

// --------------------------------------------------------------------------------
// Update origin sql
async Task ExecuteOriginSql(TestDbContext dbContext)
{
    string name = "CYH";
    FormattableString sql = @$"INSERT INTO t_teacher (Name) VALUES ({name})";
    var res = await dbContext.Database.ExecuteSqlInterpolatedAsync(sql);
    Console.WriteLine($"Execute Sql:{sql} Result: {res}");
    string titlePattern = "%Hello%";
    var articles = dbContext.Articles
        .FromSqlInterpolated($"select * from t_article where title like {titlePattern} order by uuid()").Take(3);
    await foreach (var article in (IAsyncEnumerable<Article>)articles)
    {
        Console.WriteLine($"article: {article.Id}, {article.Title}, {article.Message}");
    }
}

async Task 悲观并发锁()
{
    Console.WriteLine("-----------------------------------------------------");
    long houseId;
    {
        await using var dbContext = new TestDbContext();

        var house = new House1 { Address = DateTime.Now.ToString() };
        foreach (var h in await dbContext.House1s.ToListAsync())
            h.IsDeleted = true;
        await dbContext.House1s.AddAsync(house);
        await dbContext.SaveChangesAsync();
        dbContext.Dispose();
        houseId = house.Id;
    }

    async Task UpdateHouse1(long houseId, string owner)
    {
        await Task.Delay(100);
        await using var context = new TestDbContext();
        await using var tx = context.Database.BeginTransaction();
        var queryHouse = await context.House1s
            .FromSqlInterpolated($"select * from t_house1 where Id = {houseId} for update")
            .SingleAsync();
        if (string.IsNullOrEmpty(queryHouse.Owner))
        {
            queryHouse.Owner = owner;
            Console.WriteLine($"房子赋予了新主人[{owner}]！");
            await context.SaveChangesAsync();
            await tx.CommitAsync();
        }
        else
        {
            Console.WriteLine($"房子已被[{queryHouse.Owner}]占用！");
        }
    }

    List<Task> tasks = new();
    for (int i = 0; i < 3; ++i)
    {
        var id = i;
        tasks.Add(Task.Run(async () => await UpdateHouse1(houseId, $"Owner_{id}")));
    }

    Task.WaitAll(tasks.ToArray());
}


async Task 乐观并发锁()
{
    Console.WriteLine("-----------------------------------------------------");
    long houseId;
    {
        await using var dbContext = new TestDbContext();
        foreach (var h in await dbContext.Houses.ToListAsync())
            h.IsDeleted = true;

        var house = new House { Address = DateTime.Now.ToString() };
        await dbContext.Houses.AddAsync(house);
        await dbContext.SaveChangesAsync();
        houseId = house.Id;
        dbContext.Dispose();
    }

    async Task UpdateHouse(long houseId, string owner)
    {
        await Task.Delay(100);
        await using var context = new TestDbContext();
        var queryHouse = await context.Houses.SingleAsync(h => h.Id == houseId);
        if (string.IsNullOrEmpty(queryHouse.Owner))
        {
            queryHouse.Owner = owner;
            try
            {
                await context.SaveChangesAsync();
                Console.WriteLine($"房子赋予了新主人[{owner}]！");
            }
            catch (DbUpdateConcurrencyException _)
            {
                Console.WriteLine("并发访问冲突！！！房子已被占用！");
                // Console.WriteLine(_);
            }
        }
        else
        {
            Console.WriteLine($"房子已被[{queryHouse.Owner}]占用！");
        }
    }

    List<Task> tasks = new();
    for (int i = 0; i < 3; ++i)
    {
        var id = i;
        tasks.Add(Task.Run(async () => await UpdateHouse(houseId, $"Owner_{id}")));
    }

    Task.WaitAll(tasks.ToArray());
}