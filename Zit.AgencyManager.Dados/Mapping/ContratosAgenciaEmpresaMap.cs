using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class ContratosAgenciaEmpresaMap : IEntityTypeConfiguration<ContratoAgenciaEmpresa>
    {
        public void Configure(EntityTypeBuilder<ContratoAgenciaEmpresa> builder)
        {
            builder.Property(x => x.Comissao)
                .HasColumnType("decimal(4,2)");
        }
    }
}
