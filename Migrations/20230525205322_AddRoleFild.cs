using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaTelefonica.Migrations
{
    public partial class AddRoleFild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "usuario");
        }
    }
}
