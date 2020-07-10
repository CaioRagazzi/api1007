using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpenOS.Migrations
{
    public partial class TableCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "PriorityType");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TicketType",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "PriorityType",
                nullable: false);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "TicketType");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "PriorityType");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "TicketType",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "PriorityType",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");
        }
    }
}
