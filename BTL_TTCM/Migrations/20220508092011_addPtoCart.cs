using Microsoft.EntityFrameworkCore.Migrations;

namespace BTL_TTCM.Migrations
{
    public partial class addPtoCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "proID",
                table: "carts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "proID",
                table: "carts");
        }
    }
}
