using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase<Automovel, RepositorioAutomovel, ServicoAutomovel, TabelaAutomovelControl, TelaAutomovelForm, ServicoCategoriaAutomoveis, NoService>
    {
        public ControladorAutomovel(RepositorioAutomovel _repositorio, ServicoAutomovel _servico, TabelaAutomovelControl _tabela, ServicoCategoriaAutomoveis _repositorio2) : base(_repositorio, _servico, _tabela, _repositorio2)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        protected override string TipoCadastro => "Automóveis";

        public void Filtrar()
        {
            var categorias = _servico2.SelecionarTodosOsRegistros();

            TelaFiltroAutomovelForm tela = new(categorias);

            TelaPrincipalForm.AtualizarStatus($"Filtrando Automóveis");

            if (tela.ShowDialog() == DialogResult.OK)
            {
                CarregarAutomoveisComFiltro(tela.CategoriaSelecionada);
            }
        }

        private void CarregarAutomoveisComFiltro(CategoriaAutomoveis? categoriaSelecionada)
        {
            var listaAutomoveisFiltrados = _servico.FiltrarAutomoveisPorCategoria(categoriaSelecionada);

            _tabela.AtualizarLista(listaAutomoveisFiltrados);
        }

        private void ObterDependencias(TelaAutomovelForm tela, Automovel automovel)
        {
            var categorias = _servico2.SelecionarTodosOsRegistros();

            var combustiveis = Enum.GetValues(typeof(TipoCombustível)).Cast<TipoCombustível>().ToList()
                .ConvertAll(x => x.ToDescriptionString());

            tela.CarregarCategorias(categorias, combustiveis);
        }
    }
}
