using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioCategoriaAutomoveis : RepositorioBase<CategoriaAutomoveis>, IRepositorioCategoria
    {
        public RepositorioCategoriaAutomoveis(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioCategoriaAutomoveis()
        {
        }

        public override bool Existe(CategoriaAutomoveis categoriaParaVerificar)
        {
            return Registros.ToList().Any(c => string.Equals(c.Nome.RemoverAcento(), categoriaParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != categoriaParaVerificar.ID);
        }
    }
}
