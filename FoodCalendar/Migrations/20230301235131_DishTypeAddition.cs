using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodCalendar.Migrations
{
    public partial class DishTypeAddition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DishTypeId",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DishName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_DishTypeId",
                table: "Food",
                column: "DishTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_DishType_DishTypeId",
                table: "Food",
                column: "DishTypeId",
                principalTable: "DishType",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_DishType_DishTypeId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropIndex(
                name: "IX_Food_DishTypeId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "DishTypeId",
                table: "Food");
        }
    }
}
