using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class VendaVirtualMap : IEntityTypeConfiguration<VendaVirtual>
    {
        public void Configure(EntityTypeBuilder<VendaVirtual> builder)
        {
            builder.Property(x => x.Valor)
                   .HasColumnType("decimal(12,4)");
        }
    }
}
