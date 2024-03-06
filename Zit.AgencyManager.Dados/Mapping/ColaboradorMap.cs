using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class ColaboradorMap : IEntityTypeConfiguration<Colaborador>
    {
        public void Configure(EntityTypeBuilder<Colaborador> builder)
        {
            builder.Property(x => x.CPF)
               .HasColumnType("varchar(11)");
        }
    }
}
