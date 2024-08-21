using Microsoft.EntityFrameworkCore;

namespace EFCore1VN.EFC;

public class TestDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;port=3306;database=efcoredemo1;user=dev;password=123456";
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version("9.0.1")));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}