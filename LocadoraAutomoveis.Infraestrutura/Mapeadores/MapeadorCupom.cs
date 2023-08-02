using LocadoraAutomoveis.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorCupom : IEntityTypeConfiguration<Cupom>
    {
        public void Configure(EntityTypeBuilder<Cupom> builder)
        {
            builder.ToTable("TBCupom");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c =>)
        }
    }
}
