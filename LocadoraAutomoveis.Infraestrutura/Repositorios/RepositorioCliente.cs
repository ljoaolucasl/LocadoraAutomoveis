using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioCliente : RepositorioBase<Cliente>, IRepositorioCliente
    {
        public RepositorioCliente(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioCliente()
        {
        }

        public override bool Existe(Cliente clienteParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(clienteParaVerificar);

            return Registros.ToList().Any(c => string.Equals(c.Nome.RemoverAcento(), clienteParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != clienteParaVerificar.ID);
        }
    }
}
