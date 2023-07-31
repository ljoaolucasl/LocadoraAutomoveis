using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioParceiro : RepositorioBase<Parceiro>, IRepositorioBase<Parceiro>
    {
        public RepositorioParceiro(ContextoDados contextoDb) : base(contextoDb)
        {
        }
    }
}
