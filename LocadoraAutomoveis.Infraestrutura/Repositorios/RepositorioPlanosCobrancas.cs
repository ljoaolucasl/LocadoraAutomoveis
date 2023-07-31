using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioPlanosCobrancas : RepositorioBase<PlanoCobranca>
    {
        public RepositorioPlanosCobrancas(ContextoDados contextoDb) : base(contextoDb)
        {
        }
    }
}
