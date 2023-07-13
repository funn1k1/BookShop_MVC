using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopWeb.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FixMistakesInOrderHeader : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "OrderHeaders",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "PostalCode",
                table: "OrderHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "OrderHeaders",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "PostalCode",
                table: "OrderHeaders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
