using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zit.AgencyManager.Dados.Migrations
{
    /// <inheritdoc />
    public partial class Colaborador_Status_Ativo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataDemissao",
                table: "Colaboradores",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Colaboradores",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Colaboradores");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DataDemissao",
                table: "Colaboradores",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date");
        }
    }
}
