using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class VendaMap : IEntityTypeConfiguration<Venda>
    {
        public void Configure(EntityTypeBuilder<Venda> builder)
        {
            builder.Property(x => x.Cartao)
                   .HasColumnType("decimal(12,4)");

            builder.Property(x => x.Dinheiro)
                  .HasColumnType("decimal(12,4)");
        }
    }
}
