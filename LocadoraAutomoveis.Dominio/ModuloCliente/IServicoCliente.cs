using FluentResults;

namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public interface IServicoCliente : IServicoBase<Cliente>
    {
        Result VerificarSeClienteTemCondutor(Cliente cliente);
    }
}
