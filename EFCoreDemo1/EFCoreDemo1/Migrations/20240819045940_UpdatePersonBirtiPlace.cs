using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreDemo1.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePersonBirtiPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "T_Person",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "T_Person");
        }
    }
}
