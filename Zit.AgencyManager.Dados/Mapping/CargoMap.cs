using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class CargoMap : IEntityTypeConfiguration<Cargo>
    {
        public void Configure(EntityTypeBuilder<Cargo> builder)
        {
            builder.Property(x => x.Salario)
                .HasColumnType("decimal(10,2)");

            builder.Property(x => x.Atribuicoes)
                .HasColumnType("varchar(300)");
        }
    }
}
