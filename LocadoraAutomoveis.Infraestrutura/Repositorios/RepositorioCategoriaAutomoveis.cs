using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioCategoriaAutomoveis : RepositorioBase<CategoriaAutomoveis>
    {
        public RepositorioCategoriaAutomoveis(ContextoDados contextoDb) : base(contextoDb)
        {
        }
    }
}
