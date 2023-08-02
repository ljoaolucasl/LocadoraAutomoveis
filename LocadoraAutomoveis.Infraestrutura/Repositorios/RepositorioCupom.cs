using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioCupom : RepositorioBase<Cupom>, IRepositorioCupom
    {
        public RepositorioCupom(ContextoDados contextoDb) : base(contextoDb)
        {
            
        }

        public RepositorioCupom()
        {
            
        }
        public override bool Existe(Cupom cupomParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(cupomParaVerificar);

            return Registros.ToList().Any(c => string.Equals(c.Nome.RemoverAcento(), cupomParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != cupomParaVerificar.ID);
        }
    }
}
