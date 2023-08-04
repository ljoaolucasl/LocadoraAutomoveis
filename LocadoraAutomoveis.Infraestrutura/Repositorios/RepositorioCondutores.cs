using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioCondutores : RepositorioBase<Condutores>, IRepositorioCondutores
    {
        public RepositorioCondutores(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioCondutores()
        {
        }

        public override bool Existe(Condutores condutorParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(condutorParaVerificar);

            return Registros.ToList().Any(c => string.Equals(c.Nome.RemoverAcento(), condutorParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != condutorParaVerificar.ID);
        }
    }
}
