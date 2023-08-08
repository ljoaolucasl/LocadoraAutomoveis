using LocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraAutomoveis.WinApp.ModuloFuncionario
{
    public class ControladorFuncionario : ControladorBase<Funcionario, IRepositorioFuncionario, IServicoFuncionario, TabelaFuncionarioControl, TelaFuncionarioForm, NoService, NoService>
    {
        public ControladorFuncionario(IRepositorioFuncionario _repositorio, IServicoFuncionario _servico, TabelaFuncionarioControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Funcionários";
    }
}
