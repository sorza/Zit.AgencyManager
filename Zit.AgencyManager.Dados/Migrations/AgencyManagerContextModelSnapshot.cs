﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zit.AgencyManager.Dados.Banco;

#nullable disable

namespace Zit.AgencyManager.Dados.Migrations
{
    [DbContext(typeof(AgencyManagerContext))]
    partial class AgencyManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Agencia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Ativa")
                        .HasColumnType("bit");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Agencias");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Caixa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aberto")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("TrocoFinal")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("TrocoInicial")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("UsuarioId")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Caixa");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Atribuicoes")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<decimal>("Salario")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Cargos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Colaborador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DataDemissao")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataNascimento")
                        .HasColumnType("date");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("RG")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("CargoId");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Colaboradores");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<int?>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("TipoContato")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("ColaboradorId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Contatos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.ContratoAgenciaEmpresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AgenciaId")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<decimal>("Comissao")
                        .HasColumnType("decimal(4,2)");

                    b.Property<DateOnly>("DataContrato")
                        .HasColumnType("date");

                    b.Property<DateOnly?>("DataDistrato")
                        .HasColumnType("date");

                    b.Property<bool>("EmiteNota")
                        .HasColumnType("bit");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("FrequenciaAcerto")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("ModalidadeAcerto")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("ModalidadeComissao")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("AgenciaId");

                    b.HasIndex("EmpresaId");

                    b.ToTable("ContratosAgenciaEmpresa");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnType("varchar(14)");

                    b.Property<int>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeFantasia")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("RazaoSocial")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("CEP")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Complemento")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Localidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Localidades");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Movimentacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaixaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasColumnType("varchar(90)");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<string>("FormaPagamento")
                        .HasColumnType("varchar(90)");

                    b.Property<bool>("Pago")
                        .HasColumnType("bit");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(90)");

                    b.Property<int?>("TrajetoId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("TrajetoId");

                    b.ToTable("Movimentacoes");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Trajeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DestinoId")
                        .HasColumnType("int");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<int>("OrigemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DestinoId");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("OrigemId");

                    b.ToTable("Trajetos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Usuario", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(90)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(90)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("varchar(90)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("varchar(90)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Venda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaixaId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Cartao")
                        .HasColumnType("decimal(9,2)");

                    b.Property<int>("ContratoAgenciaEmpresaId")
                        .HasColumnType("int");

                    b.Property<decimal?>("Dinheiro")
                        .HasColumnType("decimal(9,2)");

                    b.HasKey("Id");

                    b.HasIndex("CaixaId");

                    b.HasIndex("ContratoAgenciaEmpresaId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Agencia", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Caixa", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Colaborador", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Agencia", "Agencia")
                        .WithMany("Colaboradores")
                        .HasForeignKey("AgenciaId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Cargo");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Contato", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Agencia", null)
                        .WithMany("Contatos")
                        .HasForeignKey("AgenciaId");

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Colaborador", null)
                        .WithMany("Contatos")
                        .HasForeignKey("ColaboradorId");

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Empresa", null)
                        .WithMany("Contatos")
                        .HasForeignKey("EmpresaId");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.ContratoAgenciaEmpresa", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Agencia", "Agencia")
                        .WithMany("Empresas")
                        .HasForeignKey("AgenciaId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Empresa", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Movimentacao", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Caixa", "Caixa")
                        .WithMany()
                        .HasForeignKey("CaixaId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Trajeto", "Trajeto")
                        .WithMany()
                        .HasForeignKey("TrajetoId");

                    b.Navigation("Caixa");

                    b.Navigation("Empresa");

                    b.Navigation("Trajeto");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Trajeto", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Localidade", "Destino")
                        .WithMany()
                        .HasForeignKey("DestinoId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Empresa", null)
                        .WithMany("Trajetos")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Localidade", "Origem")
                        .WithMany()
                        .HasForeignKey("OrigemId")
                        .IsRequired();

                    b.Navigation("Destino");

                    b.Navigation("Origem");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Usuario", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId")
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Venda", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Caixa", "Caixa")
                        .WithMany()
                        .HasForeignKey("CaixaId")
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.ContratoAgenciaEmpresa", "ContratoAgenciaEmpresa")
                        .WithMany()
                        .HasForeignKey("ContratoAgenciaEmpresaId")
                        .IsRequired();

                    b.Navigation("Caixa");

                    b.Navigation("ContratoAgenciaEmpresa");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Agencia", b =>
                {
                    b.Navigation("Colaboradores");

                    b.Navigation("Contatos");

                    b.Navigation("Empresas");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Colaborador", b =>
                {
                    b.Navigation("Contatos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Empresa", b =>
                {
                    b.Navigation("Contatos");

                    b.Navigation("Trajetos");
                });
#pragma warning restore 612, 618
        }
    }
}
