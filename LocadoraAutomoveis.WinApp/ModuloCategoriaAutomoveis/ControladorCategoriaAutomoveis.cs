using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    public class ControladorCategoriaAutomoveis : ControladorBase<CategoriaAutomoveis, RepositorioCategoriaAutomoveis, ServicoCategoriaAutomoveis, TabelaCategoriaAutomoveisControl, TelaCategoriaAutomoveisForm, NoService, NoService>
    {
        public ControladorCategoriaAutomoveis(RepositorioCategoriaAutomoveis _repositorio, ServicoCategoriaAutomoveis _servico, TabelaCategoriaAutomoveisControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }

        protected override string TipoCadastro => "Categorias de Automóveis";
    }
}
