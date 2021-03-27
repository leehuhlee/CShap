using Microsoft.EntityFrameworkCore.Migrations;

namespace MMO_EFCore.Migrations
{
    public partial class ItemGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemGreade",
                table: "Item",
                newName: "ItemGrade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ItemGrade",
                table: "Item",
                newName: "ItemGreade");
        }
    }
}
