using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zit.AgencyManager.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CorrigindoEnderecoColaborador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Colaboradores_ColaboradorId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ColaboradorId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "ColaboradorId",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoId",
                table: "Colaboradores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_EnderecoId",
                table: "Colaboradores",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Colaboradores_Enderecos_EnderecoId",
                table: "Colaboradores",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaboradores_Enderecos_EnderecoId",
                table: "Colaboradores");

            migrationBuilder.DropIndex(
                name: "IX_Colaboradores_EnderecoId",
                table: "Colaboradores");

            migrationBuilder.DropColumn(
                name: "EnderecoId",
                table: "Colaboradores");

            migrationBuilder.AddColumn<int>(
                name: "ColaboradorId",
                table: "Enderecos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ColaboradorId",
                table: "Enderecos",
                column: "ColaboradorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Colaboradores_ColaboradorId",
                table: "Enderecos",
                column: "ColaboradorId",
                principalTable: "Colaboradores",
                principalColumn: "Id");
        }
    }
}
