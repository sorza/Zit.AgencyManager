using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zit.AgencyManager.Dados.Migrations
{
    /// <inheritdoc />
    public partial class CriandoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(90)", nullable: false),
                    Atribuicoes = table.Column<string>(type: "varchar(300)", nullable: false),
                    Salario = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Localidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cidade = table.Column<string>(type: "varchar(90)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(90)", nullable: false),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(90)", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    RG = table.Column<string>(type: "varchar(90)", nullable: false),
                    DataNascimento = table.Column<DateOnly>(type: "date", nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false),
                    DataAdmissao = table.Column<DateOnly>(type: "date", nullable: false),
                    DataDemissao = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colaboradores_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Colaboradores_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEP = table.Column<string>(type: "varchar(90)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(90)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(90)", nullable: false),
                    Bairro = table.Column<string>(type: "varchar(90)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(90)", nullable: false),
                    Uf = table.Column<string>(type: "varchar(90)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(90)", nullable: true),
                    ColaboradorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enderecos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(90)", nullable: false),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(90)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(90)", nullable: true),
                    Email = table.Column<string>(type: "varchar(90)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(90)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "varchar(90)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "varchar(90)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(90)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(90)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "varchar(90)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(90)", nullable: true),
                    CNPJ = table.Column<string>(type: "varchar(14)", nullable: false),
                    EnderecoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empresas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "varchar(90)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TrocoInicial = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    TrocoFinal = table.Column<decimal>(type: "decimal(6,2)", nullable: true),
                    Aberto = table.Column<bool>(type: "bit", nullable: false),
                    Saldo = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caixa_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoContato = table.Column<string>(type: "varchar(90)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(90)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(90)", nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: true),
                    ColaboradorId = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contatos_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contatos_Colaboradores_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Colaboradores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contatos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ContratosAgenciaEmpresa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    AgenciaId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Comissao = table.Column<decimal>(type: "decimal(4,2)", nullable: false),
                    ModalidadeComissao = table.Column<string>(type: "varchar(90)", nullable: false),
                    FrequenciaAcerto = table.Column<string>(type: "varchar(90)", nullable: false),
                    ModalidadeAcerto = table.Column<string>(type: "varchar(90)", nullable: false),
                    EmiteNota = table.Column<bool>(type: "bit", nullable: false),
                    DataContrato = table.Column<DateOnly>(type: "date", nullable: false),
                    DataDistrato = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContratosAgenciaEmpresa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContratosAgenciaEmpresa_Agencias_AgenciaId",
                        column: x => x.AgenciaId,
                        principalTable: "Agencias",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContratosAgenciaEmpresa_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Trajetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrigemId = table.Column<int>(type: "int", nullable: false),
                    DestinoId = table.Column<int>(type: "int", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trajetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trajetos_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trajetos_Localidades_DestinoId",
                        column: x => x.DestinoId,
                        principalTable: "Localidades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Trajetos_Localidades_OrigemId",
                        column: x => x.OrigemId,
                        principalTable: "Localidades",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaixaId = table.Column<int>(type: "int", nullable: false),
                    ContratoAgenciaEmpresaId = table.Column<int>(type: "int", nullable: false),
                    Dinheiro = table.Column<decimal>(type: "decimal(9,2)", nullable: true),
                    Cartao = table.Column<decimal>(type: "decimal(9,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Caixa_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vendas_ContratosAgenciaEmpresa_ContratoAgenciaEmpresaId",
                        column: x => x.ContratoAgenciaEmpresaId,
                        principalTable: "ContratosAgenciaEmpresa",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaixaId = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(90)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(90)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    TrajetoId = table.Column<int>(type: "int", nullable: true),
                    FormaPagamento = table.Column<string>(type: "varchar(90)", nullable: true),
                    Pago = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Caixa_CaixaId",
                        column: x => x.CaixaId,
                        principalTable: "Caixa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Trajetos_TrajetoId",
                        column: x => x.TrajetoId,
                        principalTable: "Trajetos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencias_EnderecoId",
                table: "Agencias",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Caixa_UsuarioId",
                table: "Caixa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_AgenciaId",
                table: "Colaboradores",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Colaboradores_CargoId",
                table: "Colaboradores",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_AgenciaId",
                table: "Contatos",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_ColaboradorId",
                table: "Contatos",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_EmpresaId",
                table: "Contatos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAgenciaEmpresa_AgenciaId",
                table: "ContratosAgenciaEmpresa",
                column: "AgenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_ContratosAgenciaEmpresa_EmpresaId",
                table: "ContratosAgenciaEmpresa",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EnderecoId",
                table: "Empresas",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_ColaboradorId",
                table: "Enderecos",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_CaixaId",
                table: "Movimentacoes",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_EmpresaId",
                table: "Movimentacoes",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_TrajetoId",
                table: "Movimentacoes",
                column: "TrajetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajetos_DestinoId",
                table: "Trajetos",
                column: "DestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajetos_EmpresaId",
                table: "Trajetos",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Trajetos_OrigemId",
                table: "Trajetos",
                column: "OrigemId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ColaboradorId",
                table: "Usuarios",
                column: "ColaboradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_CaixaId",
                table: "Vendas",
                column: "CaixaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ContratoAgenciaEmpresaId",
                table: "Vendas",
                column: "ContratoAgenciaEmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agencias_Enderecos_EnderecoId",
                table: "Agencias",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agencias_Enderecos_EnderecoId",
                table: "Agencias");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Trajetos");

            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropTable(
                name: "ContratosAgenciaEmpresa");

            migrationBuilder.DropTable(
                name: "Localidades");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Agencias");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
