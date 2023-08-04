using LocadoraAutomoveis.Dominio.ModuloCondutores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocadoraAutomoveis.Infraestrutura.Mapeadores
{
    public class MapeadorCondutores
    {
        public void Configure(EntityTypeBuilder<Condutores> builder)
        {
            builder.ToTable("TBCondutores");
            builder.HasKey(c => c.ID);
            builder.Property(c => c.cliente).IsRequired();
            builder.Property(c => c.TipoCondutor).IsRequired();
            builder.Property(c => c.Nome).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(c => c.Telefone).HasColumnType("varchar(20)").IsRequired();
            builder.Property(c => c.CPF).HasColumnType("varchar(20)");
            builder.Property(c => c.CNH).HasColumnType("varchar(30)");
            builder.Property(c => c.Validade).IsRequired();
        }
    }
}
