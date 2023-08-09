using LocadoraAutomoveis.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorAluguel : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("TBAluguel");
            builder.HasKey(a => a.ID);
            builder.Property(a => a.DataLocacao).IsRequired();
            builder.Property(a => a.DataPrevistaRetorno).IsRequired();
            builder.Property(a => a.ValorTotal).IsRequired();
            builder.Property(a => a.Concluido).IsRequired();
            builder.Property(a => a.Plano).IsRequired();
            builder.Property(a => a.DataDevolucao);
            builder.Property(a => a.QuilometrosRodados);
            builder.Property(a => a.CombustivelRestante);

            builder.HasOne(a => a.Funcionario)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAluguel_TBFuncionario")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Cliente)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAluguel_TBCliente")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.CategoriaAutomoveis)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAluguel_TBCategoriaAutomoveis")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.PlanoCobranca)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAluguel_TBPlanoCobranca")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Condutor)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAluguel_TBCondutor")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Automovel)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBAluguel_TBAutomovel")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.Cupom)
                .WithMany()
                .HasConstraintName("FK_TBAluguel_TBCupom")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(a => a.ListaTaxasEServicos)
                .WithMany()
                .UsingEntity(x => x.ToTable("FK_TBAluguel_TBTaxaEServico"));
        }
    }
}
