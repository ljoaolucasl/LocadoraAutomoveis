using LocadoraAutomoveis.Dominio.ModuloPadrao;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioPadrao : RepositorioBase<Padrao>
    {
        public RepositorioPadrao(ContextoDados contextoDb) : base(contextoDb)
        {
        }
    }
}
