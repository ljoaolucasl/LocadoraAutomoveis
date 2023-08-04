using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

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

        public override bool Existe(CategoriaAutomoveis categoriaParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(categoriaParaVerificar);

            return Registros.ToList().Any(c => string.Equals(c.Nome.RemoverAcento(), categoriaParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != categoriaParaVerificar.ID);
        }
    }
}
