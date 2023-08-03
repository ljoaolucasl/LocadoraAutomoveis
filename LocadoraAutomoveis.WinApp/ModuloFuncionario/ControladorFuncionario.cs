using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase<Funcionario, RepositorioFuncionario, ServicoFuncionario, TabelaFuncionarioControl, TelaFuncionarioForm, NoService, NoService>
    {
        public ControladorFuncionario(RepositorioFuncionario _repositorio, ServicoFuncionario _servico, TabelaFuncionarioControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Funcionários";
    }
}
