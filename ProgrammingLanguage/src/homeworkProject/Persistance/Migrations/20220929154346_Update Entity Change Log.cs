using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class UpdateEntityChangeLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "TableColumn");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "TableColumnChangeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityId",
                table: "TableColumnChangeDetails");

            migrationBuilder.AddColumn<int>(
                name: "EntityId",
                table: "TableColumn",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
