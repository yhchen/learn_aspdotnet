using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCoreDemo1;

public class TestDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public DbSet<Person> Persons { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;port=3306;database=efcoredemo1;user=dev;password=123456";
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version("9.0.1")));

        var loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
        optionsBuilder.UseLoggerFactory(loggerFactory);
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}