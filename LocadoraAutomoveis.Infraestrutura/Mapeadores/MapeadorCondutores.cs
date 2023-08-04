using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorCondutores : IEntityTypeConfiguration<Condutores>
    {
        public void Configure(EntityTypeBuilder<Condutores> builder)
        {
            builder.ToTable("TBCondutor");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.TipoCondutor).IsRequired();
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.CPF).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.CNH).HasColumnType("varchar(30)").IsRequired();
            builder.Property(c => c.Validade).IsRequired();

            builder.HasOne(c => c.Cliente)
                .WithMany()
                .IsRequired()
                .HasConstraintName("FK_TBCondutor_TBCliente")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
