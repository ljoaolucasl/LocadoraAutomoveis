using FluentResults;

namespace LocadoraAutomoveis.Dominio.ModuloTaxaEServico
{
    public interface IServicoTaxaEServico : IServicoBase<TaxaEServico>
    {
        Result VerificarDisponibilidade(TaxaEServico taxa);
    }
}
