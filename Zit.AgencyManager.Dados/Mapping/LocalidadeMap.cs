using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class LocalidadeMap : IEntityTypeConfiguration<Localidade>
    {
        public void Configure(EntityTypeBuilder<Localidade> builder)
        {
            builder.Property(l => l.Estado)
                .HasColumnType("varchar(2)");
        }
    }
}
