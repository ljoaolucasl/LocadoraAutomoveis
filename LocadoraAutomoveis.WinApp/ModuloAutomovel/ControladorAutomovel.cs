using FluentResults;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.WinApp.ModuloAutomovel
{
    public class ControladorAutomovel : ControladorBase<Automovel, IRepositorioAutomovel, IServicoAutomovel, TabelaAutomovelControl, TelaAutomovelForm, IServicoCategoriaAutomoveis, NoService>
    {
        public ControladorAutomovel(IRepositorioAutomovel _repositorio, IServicoAutomovel _servico, TabelaAutomovelControl _tabela, IServicoCategoriaAutomoveis _repositorio2) : base(_repositorio, _servico, _tabela, _repositorio2)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
            OnVerificar += ObterDisponibilidade;
        }
        protected override string TipoCadastro => "Automóveis";

        public Result ObterDisponibilidade(Automovel automovel)
        {
            return _servico.VerificarDisponibilidade(automovel);
        }

        public void Filtrar()
        {
            var categorias = _servico2.SelecionarTodosOsRegistros();

            TelaFiltroAutomovelForm tela = new(categorias);

            TelaPrincipalForm.AtualizarStatus($"Filtrando Automóveis");

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarAutomoveisComFiltro(tela.CategoriaSelecionada);
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
