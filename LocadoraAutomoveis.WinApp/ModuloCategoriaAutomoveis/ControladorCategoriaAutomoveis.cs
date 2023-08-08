using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    public class ControladorCategoriaAutomoveis : ControladorBase<CategoriaAutomoveis, IRepositorioCategoria, IServicoCategoriaAutomoveis, TabelaCategoriaAutomoveisControl, TelaCategoriaAutomoveisForm, NoService, NoService>
    {
        public ControladorCategoriaAutomoveis(IRepositorioCategoria _repositorio, IServicoCategoriaAutomoveis _servico, TabelaCategoriaAutomoveisControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Categorias de Automóveis";
    }
}
