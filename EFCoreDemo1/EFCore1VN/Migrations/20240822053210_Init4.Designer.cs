﻿// <auto-generated />
using EFCore1VN.EFC;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore1VN.Migrations
{
    [DbContext(typeof(TestDbContext))]
    [Migration("20240822053210_Init4")]
    partial class Init4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("EFCore1VN.EFC.Article", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(512)
                        .IsUnicode(true)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .IsUnicode(true)
                        .HasColumnType("varchar(128)");

                    b.HasKey("Id");

                    b.ToTable("T_Article", (string)null);
                });

            modelBuilder.Entity("EFCore1VN.EFC.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ArticleId")
                        .HasColumnType("bigint");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(512)
                        .IsUnicode(true)
                        .HasColumnType("varchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("T_Comment", (string)null);
                });

            modelBuilder.Entity("EFCore1VN.EFC_1.Leave", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ApproverId")
                        .HasColumnType("bigint");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("RequestId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ApproverId");

                    b.HasIndex("RequestId");

                    b.ToTable("T_Leave", (string)null);
                });

            modelBuilder.Entity("EFCore1VN.EFC_1.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("T_User", (string)null);
                });

            modelBuilder.Entity("EFCore1VN.EFC_Orga.OrgUnit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("ParentId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("T_OrgUnit", (string)null);
                });

            modelBuilder.Entity("EFCore1VN.EFC.Comment", b =>
                {
                    b.HasOne("EFCore1VN.EFC.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("EFCore1VN.EFC_1.Leave", b =>
                {
                    b.HasOne("EFCore1VN.EFC_1.User", "Approver")
                        .WithMany()
                        .HasForeignKey("ApproverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore1VN.EFC_1.User", "Requset")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Approver");

                    b.Navigation("Requset");
                });

            modelBuilder.Entity("EFCore1VN.EFC_Orga.OrgUnit", b =>
                {
                    b.HasOne("EFCore1VN.EFC_Orga.OrgUnit", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("EFCore1VN.EFC.Article", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("EFCore1VN.EFC_Orga.OrgUnit", b =>
                {
                    b.Navigation("Children");
                });
#pragma warning restore 612, 618
        }
    }
}
