using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    internal class RepositorioAutomovel : RepositorioBase<Automovel>, IRepositorioAutomovel
    {
        public RepositorioAutomovel(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioAutomovel()
        {
        }

        public override bool Existe(Automovel automovelParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(automovelParaVerificar);

            return Registros.ToList().Any(c => Registros.Contains(automovelParaVerificar) && c.ID != automovelParaVerificar.ID);
        }
    }
}
