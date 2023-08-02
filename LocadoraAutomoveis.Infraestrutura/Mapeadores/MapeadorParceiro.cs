using LocadoraAutomoveis.Dominio.ModuloParceiro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorParceiro : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.ToTable("TBParceiro");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.Nome).HasColumnType("varchar(100)").IsRequired();
            //builder.HasMany()
        }
    }
}
