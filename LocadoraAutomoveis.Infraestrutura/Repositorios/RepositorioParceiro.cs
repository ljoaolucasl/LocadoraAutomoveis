using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioParceiro : RepositorioBase<Parceiro>, IRepositorioParceiro
    {
        public RepositorioParceiro(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioParceiro()
        {            
        }

        public override bool Existe(Parceiro parceiroParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(parceiroParaVerificar);

            return Registros.ToList().Any(p => string.Equals(p.Nome.RemoverAcento(), parceiroParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && p.ID != parceiroParaVerificar.ID);
        }
    }
}
