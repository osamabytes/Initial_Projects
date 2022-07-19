using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookify.Migrations
{
    public partial class TypeConventionFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Types",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Types",
                newName: "id");
        }
    }
}
