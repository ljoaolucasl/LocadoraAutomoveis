using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorTaxaEServico : IEntityTypeConfiguration<TaxaEServico>
    {
        public void Configure(EntityTypeBuilder<TaxaEServico> builder)
        {
            builder.ToTable("TBTaxaEServico");
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(t => t.Valor).IsRequired();
            builder.Property(t => t.Tipo).IsRequired();
        }
    }
}
