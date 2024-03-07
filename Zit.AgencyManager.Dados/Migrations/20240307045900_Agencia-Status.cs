using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zit.AgencyManager.Dados.Migrations
{
    /// <inheritdoc />
    public partial class AgenciaStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Agencias",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Agencias");
        }
    }
}
