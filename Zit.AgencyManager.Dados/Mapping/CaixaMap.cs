using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class CaixaMap : IEntityTypeConfiguration<Caixa>
    {
        public void Configure(EntityTypeBuilder<Caixa> builder)
        {
            builder.Property(x => x.TrocoInicial)
                .HasColumnType("decimal(6,2)");

            builder.Property(x => x.TrocoFinal)
                .HasColumnType("decimal(6,2)");
        }
    }
}
