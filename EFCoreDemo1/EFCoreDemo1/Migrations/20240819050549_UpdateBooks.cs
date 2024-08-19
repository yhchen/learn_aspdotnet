using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo1.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "T_Books",
                keyColumn: "Title",
                keyValue: null,
                column: "Title",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "T_Books",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                comment: "标题",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PubTime",
                table: "T_Books",
                type: "datetime(6)",
                nullable: false,
                comment: "发布日期",
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "T_Books",
                type: "double",
                nullable: false,
                comment: "价格",
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "T_Books",
                type: "bigint",
                nullable: false,
                comment: "主键",
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "AuthName",
                table: "T_Books",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "作者名")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthName",
                table: "T_Books");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "T_Books",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldComment: "标题")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PubTime",
                table: "T_Books",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldComment: "发布日期");

            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "T_Books",
                type: "double",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double",
                oldComment: "价格");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "T_Books",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "主键")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
