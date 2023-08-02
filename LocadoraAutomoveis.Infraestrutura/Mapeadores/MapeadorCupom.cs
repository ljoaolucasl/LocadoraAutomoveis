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
            builder.Property(c => c.Valor).IsRequired();
            builder.Property(c => c.DataValidade).IsRequired();

            builder.HasOne(c => c.Parceiro)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBCupom_TBParceiro")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
