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
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
