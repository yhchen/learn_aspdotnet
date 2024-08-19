using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo1.Migrations
{
    /// <inheritdoc />
    public partial class BookTitlePrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_T_Books_Title",
                table: "T_Books",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_T_Books_Title",
                table: "T_Books");
        }
    }
}
