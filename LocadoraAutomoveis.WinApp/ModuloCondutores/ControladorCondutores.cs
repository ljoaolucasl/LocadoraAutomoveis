using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloCondutores
{
    public class ControladorCondutores : ControladorBase<Condutores, RepositorioCondutores, ServicoCondutores, TabelaCondutoresControl, TelaCondutoresForm, NoService, NoService>
    {
        public ControladorCondutores(RepositorioCondutores _repositorio, ServicoCondutores _servico, TabelaCondutoresControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Funcionários";
    }
}
