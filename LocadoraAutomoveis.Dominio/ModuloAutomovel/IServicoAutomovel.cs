using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public interface IServicoAutomovel : IServicoBase<Automovel>
    {
        List<Automovel> FiltrarAutomoveisPorCategoria(CategoriaAutomoveis categoria);
        Result VerificarDisponibilidade(Automovel automovelParaValidar);
    }
}
