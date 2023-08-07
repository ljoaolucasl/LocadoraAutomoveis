using FluentResults;

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public interface IServicoAutomovel : IServicoBase<Automovel>
    {
        Result VerificarDisponibilidade(Automovel automovelParaValidar);
    }
}
