using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodCalendar.Migrations
{
    public partial class DishTypeMod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DishName",
                table: "DishType",
                newName: "DishTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DishTypeName",
                table: "DishType",
                newName: "DishName");
        }
    }
}
