using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioPlanosCobrancas : RepositorioBase<PlanoCobranca>, IRepositorioPlanoCobranca
    {
        public RepositorioPlanosCobrancas(ContextoDados contextoDb) : base(contextoDb)
        {

        }

        public RepositorioPlanosCobrancas()
        {
            
        }

        public override bool Existe(PlanoCobranca planoCobrancaParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(planoCobrancaParaVerificar);

            return Registros.ToList().Any(p => p.Equals(planoCobrancaParaVerificar) && p.ID != planoCobrancaParaVerificar.ID);
        }

        public override List<PlanoCobranca> SelecionarTodos()
        {
            return Registros.Include(p => p.CategoriaAutomoveis).ToList();
        }
    }
}
