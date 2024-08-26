using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore1VN.Migrations
{
    /// <inheritdoc />
    public partial class OrgForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_OrgUnit_T_OrgUnit_ParentId",
                table: "T_OrgUnit");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "T_OrgUnit",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_T_OrgUnit_T_OrgUnit_ParentId",
                table: "T_OrgUnit",
                column: "ParentId",
                principalTable: "T_OrgUnit",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_OrgUnit_T_OrgUnit_ParentId",
                table: "T_OrgUnit");

            migrationBuilder.AlterColumn<long>(
                name: "ParentId",
                table: "T_OrgUnit",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_T_OrgUnit_T_OrgUnit_ParentId",
                table: "T_OrgUnit",
                column: "ParentId",
                principalTable: "T_OrgUnit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
