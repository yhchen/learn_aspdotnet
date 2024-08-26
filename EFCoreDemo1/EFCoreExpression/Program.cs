// See https://aka.ms/new-console-template for more information

using System.Linq.Expressions;
using EFCoreExpression;
using ExpressionTreeToString;
using Microsoft.EntityFrameworkCore;
using static System.Console;
using static System.Linq.Expressions.Expression;

// Expression tree
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

// vs Function
Func<Book, bool> f1 = b => b.Id > 5;
Func<Book, Book, double> f2 = (b1, b2) => b1.Id + b2.Id;

// dynamic Expression tree
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
                    Constant(5L, typeof(long))
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
}

using var context = new TestDbContext();
var books = context.Books.Where(e1);

await foreach (var book in (IAsyncEnumerable<Book>)books)
{
    WriteLine($"{book.Id},{book.Title},{book.Author},{book.Publisher},{book.PublishDate}" +
              $",{book.CreateDate},{book.UpdateDate},{book.IsDeleted}");
}