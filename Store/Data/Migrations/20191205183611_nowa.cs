using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.Data.Migrations
{
    public partial class nowa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Count",
                table: "Cart",
                newName: "Quantity");

            migrationBuilder.AddColumn<bool>(
                name: "MarktAsremoved",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MarktAsremoved",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Cart",
                newName: "Count");
        }
    }
}
