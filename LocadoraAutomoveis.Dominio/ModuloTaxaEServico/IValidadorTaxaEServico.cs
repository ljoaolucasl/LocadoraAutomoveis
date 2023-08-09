using LocadoraAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraAutomoveis.Dominio.ModuloTaxaEServico
{
    public interface IValidadorTaxaEServico : IValidador<TaxaEServico>
    {
        bool VerificarSeRelacionadoComAluguelAberto(TaxaEServico taxaParaValidar, List<Aluguel> aluguels);
    }
}
