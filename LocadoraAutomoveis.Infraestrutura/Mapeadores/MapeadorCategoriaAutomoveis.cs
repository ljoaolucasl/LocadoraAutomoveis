using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorCategoriaAutomoveis : IEntityTypeConfiguration<CategoriaAutomoveis>
    {
        public void Configure(EntityTypeBuilder<CategoriaAutomoveis> builder)
        {
            builder.ToTable("TBCategoriaAutomoveis");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
        }
    }
}
