using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.Compartilhado;

namespace LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis
{
    public class ControladorCategoriaAutomoveis : ControladorBase<CategoriaAutomoveis, RepositorioCategoriaAutomoveis, ServicoCategoriaAutomoveis, TabelaCategoriaAutomoveisControl, TelaCategoriaAutomoveisForm, NoRepository, NoRepository>
    {
        public ControladorCategoriaAutomoveis(RepositorioCategoriaAutomoveis _repositorio, ServicoCategoriaAutomoveis _servico, TabelaCategoriaAutomoveisControl _tabela) : base(_repositorio, _servico, _tabela)
        {
        }
    }
}
