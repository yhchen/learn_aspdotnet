using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFCoreScaffoldMigration;

public partial class Efcoredemo1Context : DbContext
{
    public Efcoredemo1Context()
    {
    }

    public Efcoredemo1Context(DbContextOptions<Efcoredemo1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<TBook> TBooks { get; set; }

    public virtual DbSet<TPerson> TPeople { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=efcoredemo1;user=dev;password=123456", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.0.1-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity.ToTable("__efmigrationshistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<TBook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("t_books", tb => tb.HasComment("书本表"));

            entity.HasIndex(e => e.Title, "IX_T_Books_Title").IsUnique();

            entity.Property(e => e.Id).HasComment("主键");
            entity.Property(e => e.AuthName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasComment("作者名");
            entity.Property(e => e.Price).HasComment("价格");
            entity.Property(e => e.PubTime)
                .HasMaxLength(6)
                .HasComment("发布日期");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasComment("标题");
        });

        modelBuilder.Entity<TPerson>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("t_person", tb => tb.HasComment("角色表"));

            entity.Property(e => e.Id).HasComment("主键");
            entity.Property(e => e.Age).HasComment("年龄");
            entity.Property(e => e.BirthPlace).HasComment("出生地");
            entity.Property(e => e.Name).HasComment("名字");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
