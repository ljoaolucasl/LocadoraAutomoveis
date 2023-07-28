using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloPadrao;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloPadrao
{
    public class ControladorPadrao : ControladorBase<Padrao, RepositorioPadrao, ServicoPadrao, TabelaPadraoControl, TelaPadraoForm, NoRepository, NoRepository>
    {
        public ControladorPadrao(RepositorioPadrao _repositorio, ServicoPadrao _servico, TabelaPadraoControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        public override DataGridView ObterTabela()
        {
            return ((DataGridView)_tabela.Controls[0]);
        }
    }
}