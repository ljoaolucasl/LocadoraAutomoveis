using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LocadoraAutomoveis.Dominio.ModuloPadrao;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorPadrao// : IEntityTypeConfiguration<Padrao>
    {
        public void Configure(EntityTypeBuilder<Padrao> builder)
        {
            builder.ToTable("TBPadrao");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Nome).HasColumnType("varchar(100)");
        }
    }
}