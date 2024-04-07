using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zit.AgencyManager.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CidadeToLocalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cidade",
                table: "Enderecos",
                newName: "Localidade");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Localidades",
                type: "varchar(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)");

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Colaboradores",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(90)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Localidade",
                table: "Enderecos",
                newName: "Cidade");

            migrationBuilder.AlterColumn<string>(
                name: "UF",
                table: "Localidades",
                type: "varchar(90)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(2)");

            migrationBuilder.AlterColumn<string>(
                name: "RG",
                table: "Colaboradores",
                type: "varchar(90)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");
        }
    }
}
