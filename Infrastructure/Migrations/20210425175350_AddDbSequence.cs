using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddDbSequence : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "shared");

            migrationBuilder.CreateSequence<int>(
                name: "OrderNumbers",
                schema: "shared");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "OrderNumbers",
                schema: "shared");
        }
    }
}
