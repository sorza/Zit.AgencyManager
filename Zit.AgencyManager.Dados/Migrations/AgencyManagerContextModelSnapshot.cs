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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(90)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("varchar(90)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("varchar(90)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Value")
                        .HasColumnType("varchar(90)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Zit.AgencyManager.Dados.Modelos.PerfilDeAcesso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(90)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

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

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("TrocoFinal")
                        .HasColumnType("decimal(6,2)");

                    b.Property<decimal?>("TrocoInicial")
                        .HasColumnType("decimal(6,2)");

                    b.HasKey("Id");

                    b.HasIndex("ColaboradorId");

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

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<int>("CargoId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("DataAdmissao")
                        .HasColumnType("date");

                    b.Property<DateOnly>("DataDemissao")
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

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

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

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("varchar(90)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(90)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(90)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
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
                        .HasMaxLength(256)
                        .HasColumnType("varchar(90)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dados.Modelos.PerfilDeAcesso", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dados.Modelos.PerfilDeAcesso", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Usuario", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Agencia", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Caixa", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Colaborador", "Colaborador")
                        .WithMany()
                        .HasForeignKey("ColaboradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Colaborador");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Colaborador", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Agencia", "Agencia")
                        .WithMany()
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Cargo", "Cargo")
                        .WithMany()
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
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
                        .WithMany()
                        .HasForeignKey("AgenciaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agencia");

                    b.Navigation("Empresa");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Empresa", b =>
                {
                    b.HasOne("Zit.AgencyManager.Dominio.Modelos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Agencia", b =>
                {
                    b.Navigation("Contatos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Colaborador", b =>
                {
                    b.Navigation("Contatos");
                });

            modelBuilder.Entity("Zit.AgencyManager.Dominio.Modelos.Empresa", b =>
                {
                    b.Navigation("Contatos");
                });
#pragma warning restore 612, 618
        }
    }
}
