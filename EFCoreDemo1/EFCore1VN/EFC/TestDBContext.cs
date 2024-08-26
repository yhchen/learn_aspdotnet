using EFCore1VN.EFC_1;
using EFCore1VN.EFC_Orga;
using EFCore1VN.EFCHouser;
using EFCore1VN.EFStudentTeacher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MySqlConnector.Logging;

namespace EFCore1VN.EFC;

public class TestDbContext : DbContext
{
    public DbSet<Article> Articles { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<Leave> Leaves { get; set; }

    public DbSet<OrgUnit> OrgUnits { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<House> Houses { get; set; }
    public DbSet<House1> House1s { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;port=3306;database=efcoredemo1;user=dev;password=123456";
        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version("9.0.1")));
        // optionsBuilder.LogTo(Console.WriteLine);
        var loggerFactory = LoggerFactory.Create(configure => configure.AddConsole());
        optionsBuilder.UseLoggerFactory(loggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
    }
}