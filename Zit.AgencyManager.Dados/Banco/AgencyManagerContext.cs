using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zit.AgencyManager.Dados.Modelos;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Banco
{
    public class AgencyManagerContext : IdentityDbContext<Usuario, PerfilDeAcesso, int>
    {
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<ContratoAgenciaEmpresa> ContratosAgenciaEmpresa { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<Caixa> Caixas { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AgencyManager;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public AgencyManagerContext()
        {
            
        }
        public AgencyManagerContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }
            optionsBuilder
                .UseSqlServer(connectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
               .SelectMany(e => e.GetProperties()
               .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(90)");
            }   

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgencyManagerContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
