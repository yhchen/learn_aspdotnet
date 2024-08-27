// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;
using EFCoreExpression;
using ExpressionTreeToString;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.Linq.Expressions.Expression;

#pragma warning disable CS0162

await using var context = new TestDbContext();

// Expression tree
if (false)
{
    Expression<Func<Book, bool>> e1 = b => b.Id > 5 && b.CreateDate > DateTime.Now;
    Expression<Func<Book, Book, double>> e2 = (b1, b2) => b1.Id + b2.Id;

    WriteLine("----------------------------------------------------------------------");
    WriteLine(e1.ToString(BuiltinRenderer.ObjectNotation, ZSpitz.Util.Language.CSharp));
    WriteLine("----------------------------------------------------------------------");
    WriteLine(e1.ToString(BuiltinRenderer.FactoryMethods, ZSpitz.Util.Language.CSharp));

    WriteLine("----------------------------------------------------------------------");
    WriteLine(e2.ToString(BuiltinRenderer.ObjectNotation, ZSpitz.Util.Language.CSharp));
    WriteLine("----------------------------------------------------------------------");
    WriteLine(e2.ToString(BuiltinRenderer.FactoryMethods, ZSpitz.Util.Language.CSharp));
}

// vs Function
if (false)
{
    Func<Book, bool> f1 = b => b.Id > 5;
    Func<Book, Book, double> f2 = (b1, b2) => b1.Id + b2.Id;
}

// dynamic Expression tree
if (false)
{
    var b = Parameter(
        typeof(Book),
        "b"
    );

    var e3 = Lambda(
            AndAlso(
                GreaterThan(
                    MakeMemberAccess(b,
                        typeof(Book).GetProperty("Id")
                    ),
                    Constant(System.Convert.ChangeType(5, typeof(long)), typeof(long))
                ),
                MakeBinary(ExpressionType.GreaterThan,
                    MakeMemberAccess(b,
                        typeof(Book).GetProperty("CreateDate")
                    ),
                    MakeMemberAccess(null,
                        typeof(DateTime).GetProperty("Now")
                    ), false,
                    typeof(DateTime).GetMethod("op_GreaterThan")
                )
            ),
            b
        )
        ;

    WriteLine(e3);
    var c = e3.Compile();
    var c1 = c.DynamicInvoke(new Book()
    {
        Id = 6, Title = "TestDynamicInvoke", Author = "CYH", Publisher = "G-bits", CreateDate = DateTime.Now.AddDays(1)
    });
    Console.WriteLine(c1);
}

// 传入Expression方式查询
if (false)
{
    Expression<Func<Book, bool>> e1 = b => b.Id > 5 && b.CreateDate > DateTime.Now;
    var books = context.Books.Where(e1);

    await foreach (var book in (IAsyncEnumerable<Book>)books)
    {
        WriteLine($"{book.Id},{book.Title},{book.Author},{book.Publisher},{book.PublishDate}" +
                  $",{book.CreateDate},{book.UpdateDate},{book.IsDeleted}");
    }

    var random = new Random();
    var authors = new List<string> { "CYH", "WJF", "YZK", "ZXL", "CB" };
    var publisher = new List<string> { "CYH", "WJF", "YZK", "ZXL", "CB" };
    var count = await context.Books.CountAsync();
    for (int i = 0; i < 100; ++i)
    {
        context.Books.Add(new Book()
        {
            Author = authors[random.Next() % authors.Count], Publisher = publisher[random.Next() % publisher.Count],
            PublishDate = DateTime.Now, Title = $"Title_{publisher[random.Next() % publisher.Count]}_{count + i + 1}"
        });
    }

    await context.SaveChangesAsync();
}

// 动态Expression构造查询函数
if (false)
{
    IEnumerable<Book> QueryExpression(string propertyName, object value)
    {
        var parameterExpressionBook = Parameter(
            typeof(Book),
            "book"
        );
        var member = typeof(Book).GetProperty(propertyName)!;

        Expression<Func<Book, bool>> expression;
        if (member.PropertyType.IsPrimitive)
        {
            expression = Lambda<Func<Book, bool>>(
                Equal(
                    MakeMemberAccess(parameterExpressionBook, member),
                    Constant(System.Convert.ChangeType(value, member.PropertyType), member.PropertyType)
                ),
                parameterExpressionBook
            );
        }
        else
        {
            expression = Lambda<Func<Book, bool>>(
                MakeBinary(
                    ExpressionType.Equal,
                    MakeMemberAccess(parameterExpressionBook, member),
                    Constant(System.Convert.ChangeType(value, member.PropertyType), member.PropertyType),
                    false,
                    typeof(string).GetMethod("op_Equality")
                ),
                parameterExpressionBook
            );
        }


        return context!.Books.Where(expression.Compile());
    }

    WriteLine("----------------------------------------------------------------------");
    foreach (var book in QueryExpression("Id", 3))
    {
        WriteLine($"{book.Id},{book}.Title,{book.Author},{book.Publisher},{book.PublishDate}" +
                  $",{book.CreateDate},{book.UpdateDate},{book.IsDeleted}");
    }

    WriteLine("----------------------------------------------------------------------");
    foreach (var book in QueryExpression("Author", "CYH"))
    {
        WriteLine($"{book.Id},{book}.Title,{book.Author},{book.Publisher},{book.PublishDate}" +
                  $",{book.CreateDate},{book.UpdateDate},{book.IsDeleted}");
    }

    WriteLine("----------------------------------------------------------------------");
    var iEnumerable = QueryExpression("CreateTime", DateTime.Now);
    foreach (var book in iEnumerable)
    {
        WriteLine($"{book.Id},{book}.Title,{book.Author},{book.Publisher},{book.PublishDate}" +
                  $",{book.CreateDate},{book.UpdateDate},{book.IsDeleted}");
    }
}

// 动态Expression构造查询函数
if (true)
{
    IQueryable<object[]> Query<T>(DbContext dbContext, params string[] propertyNames) where T : class
    {
        var p = Parameter(typeof(T));
        List<Expression> propExprList = new();
        foreach (var propertyName in propertyNames)
        {
            var prop = typeof(T).GetProperty(propertyName)!;
            var propExpr = Convert(MakeMemberAccess(p, prop), typeof(object) /*prop.PropertyType*/);
            propExprList.Add(propExpr);
        }

        var newArrayExpr = NewArrayInit(typeof(object), propExprList);
        var selectExpr = Lambda<Func<T, object[]>>(newArrayExpr, p);
        var query = dbContext.Set<T>().Select(selectExpr);
        return query;
    }

    var res = Query<Book>(context, "Id", "Title", "Author", "Publisher", "PublishDate", "CreateDate", "UpdateDate",
        "IsDeleted");

    foreach (var row in res)
    {
        WriteLine(string.Join(",", row));
    }
}

#pragma warning restore CS0162