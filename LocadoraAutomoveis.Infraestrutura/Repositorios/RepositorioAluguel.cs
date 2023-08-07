using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioAluguel : RepositorioBase<Aluguel>, IRepositorioAluguel
    {
        public RepositorioAluguel(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioAluguel()
        {
        }

        public override bool Existe(Aluguel aluguelParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(aluguelParaVerificar);

            return Registros.ToList().Any(a => a.Igual(aluguelParaVerificar) && a.ID != aluguelParaVerificar.ID);
        }

        public override List<Aluguel> SelecionarTodos()
        {
            return Registros.Include(a => a.Automovel).Include(a => a.CategoriaAutomoveis).Include(a => a.Cliente).Include(a => a.Condutor)
                .Include(a => a.Cupom).Include(a => a.ListaTaxasEServicos).Include(a => a.Funcionario).Include(a => a.PlanoCobranca).ToList();
        }

        public bool CupomNaoExiste(Aluguel aluguelParaValidar, List<Cupom> cupons)
        {
            return !cupons.Contains(aluguelParaValidar.Cupom);
        }
    }
}
