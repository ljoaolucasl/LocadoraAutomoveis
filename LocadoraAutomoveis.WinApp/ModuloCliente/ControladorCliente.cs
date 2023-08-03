using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;


namespace LocadoraAutomoveis.WinApp.ModuloCliente
{
    public class ControladorCliente : ControladorBase<Cliente, RepositorioCliente, ServicoCliente, TabelaClienteControl, TelaClienteForm, NoService, NoService>
    {
        public ControladorCliente(RepositorioCliente _repositorio, ServicoCliente _servico, TabelaClienteControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Cliente";
    }
}
