using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioTaxaEServico : RepositorioBase<TaxaEServico>, IRepositorioTaxaEServico
    {
        public RepositorioTaxaEServico(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioTaxaEServico()
        {
        }

        public override bool Existe(TaxaEServico taxaParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(taxaParaVerificar);

            return Registros.ToList().Any(c => string.Equals(c.Nome.RemoverAcento(), taxaParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != taxaParaVerificar.ID);
        }
    }
}