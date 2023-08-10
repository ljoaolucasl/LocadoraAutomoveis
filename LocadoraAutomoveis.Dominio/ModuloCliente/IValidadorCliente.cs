using LocadoraAutomoveis.Dominio.ModuloCondutores;

namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public interface IValidadorCliente : IValidador<Cliente>
    {
        bool VerificarSeClienteTemCondutor(Cliente cliente, List<Condutor> condutores);
    }
}
