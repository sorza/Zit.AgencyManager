using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zit.AgencyManager.Dominio.Modelos;

namespace Zit.AgencyManager.Dados.Mapping
{
    internal class LocalidadeMap : IEntityTypeConfiguration<Localidade>
    {
        public void Configure(EntityTypeBuilder<Localidade> builder)
        {
            builder.Property(x => x.UF)
                .HasColumnType("varchar(2)");
        }
    }
}
