using LocadoraAutomoveis.Dominio.ModuloCliente;

namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase<Cliente, IRepositorioCliente, IServicoCliente, TabelaClienteControl, TelaClienteForm, NoService, NoService>
    {
        public ControladorCliente(IRepositorioCliente _repositorio, IServicoCliente _servico, TabelaClienteControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Cliente";
    }
}
