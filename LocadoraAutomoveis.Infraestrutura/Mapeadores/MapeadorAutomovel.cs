using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorAutomovel : IEntityTypeConfiguration<Automovel>
    {
        public void Configure(EntityTypeBuilder<Automovel> builder)
        {
            builder.ToTable("TBAutomovel");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.Placa).HasColumnType("varchar(20)").IsRequired();
            builder.Property(a => a.Marca).HasColumnType("varchar(100)").IsRequired();
            builder.Property(a => a.Cor).HasColumnType("varchar(100)").IsRequired();
            builder.Property(a => a.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(a => a.Modelo).HasColumnType("varchar(100)").IsRequired();
            builder.Property(a => a.Imagem).IsRequired();
            builder.Property(a => a.TipoCombustivel).IsRequired();
            builder.Property(a => a.CapacidadeCombustivel).IsRequired();
            builder.Property(a => a.Ano).IsRequired();
            builder.Property(a => a.Quilometragem).IsRequired();
            builder.Property(a => a.Alugado).IsRequired();

            builder.HasOne(a => a.Categoria)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAutomovel_TBCategoriaAutomoveis")
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
