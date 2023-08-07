using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioAutomovel : RepositorioBase<Automovel>, IRepositorioAutomovel
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

            return Registros.ToList().Any(c => c.Igual(automovelParaVerificar) && c.ID != automovelParaVerificar.ID);
        }

        public override List<Automovel> SelecionarTodos()
        {
            return Registros.Include(c => c.Categoria).ToList();
        }

        public List<Automovel> SelecionarPorCategoria(CategoriaAutomoveis? categoriaSelecionada)
        {
            if (categoriaSelecionada.ID == Guid.Empty)
                return SelecionarTodos();

            return Registros.ToList().FindAll(c => c.Categoria.Equals(categoriaSelecionada));
        }
    }
}
