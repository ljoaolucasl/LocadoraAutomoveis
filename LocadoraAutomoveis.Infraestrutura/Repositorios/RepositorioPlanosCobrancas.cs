using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioPlanosCobrancas : RepositorioBase<PlanoCobranca>
    {
        public RepositorioPlanosCobrancas(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public override bool Existe(PlanoCobranca objetoParaVerificar, bool exclusao = false)
        {
            throw new NotImplementedException();
        }
    }
}
