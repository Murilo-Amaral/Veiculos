using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Veiculos.Migrations
{
    public partial class casa01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cor",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cor",
                table: "Veiculo");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "Veiculo");
        }
    }
}
