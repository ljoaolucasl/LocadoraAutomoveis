using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorPlanosCobrancas : IEntityTypeConfiguration<PlanoCobranca>
    {
        public void Configure(EntityTypeBuilder<PlanoCobranca> builder)
        {
            builder.ToTable("TBPlanoCobranca");
            builder.HasKey(p => p.ID);
            builder.Property(p => p.PlanoDiario_ValorDiario).IsRequired();
            builder.Property(p => p.PlanoDiario_ValorKm).IsRequired();
            builder.Property(p => p.PlanoLivre_ValorDiario).IsRequired();
            builder.Property(p => p.PlanoControlador_ValorDiario).IsRequired();
            builder.Property(p => p.PlanoControlador_ValorKm).IsRequired();
            builder.Property(p => p.PlanoControlador_LimiteKm).IsRequired();

            builder.HasOne(p => p.CategoriaAutomoveis)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBPlanoCobranca_TBCategoriaAutomoveis")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
