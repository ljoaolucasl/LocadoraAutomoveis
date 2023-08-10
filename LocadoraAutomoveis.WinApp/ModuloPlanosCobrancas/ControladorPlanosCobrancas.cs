using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using System.Linq;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public class ControladorPlanosCobrancas : ControladorBase<PlanoCobranca, IRepositorioPlanoCobranca,
        IServicoPlanoCobranca, TabelaPlanosCobrancasControl, TelaPlanosCobrancasForm, IServicoCategoriaAutomoveis, NoService>
    {
        public ControladorPlanosCobrancas(IRepositorioPlanoCobranca repositorioPlanosCobrancas, IServicoPlanoCobranca servicoPlanosCobrancas, TabelaPlanosCobrancasControl tabelaPlanosCobrancas, IServicoCategoriaAutomoveis servicoCategoriaAutomoveis) : base(repositorioPlanosCobrancas, servicoPlanosCobrancas, tabelaPlanosCobrancas, servicoCategoriaAutomoveis)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        private void ObterDependencias(TelaPlanosCobrancasForm tela)
        {
            var categorias = _servico2.SelecionarTodosOsRegistros();
            var taxas = _servico.SelecionarTodosOsRegistros();

            List<CategoriaAutomoveis> categoriasFiltradas = categorias
                .Where(categoria => taxas
                .All(taxa => taxa.CategoriaAutomoveis != categoria)).ToList();

            tela.CarregarCategorias(categoriasFiltradas);
        }

        protected override string TipoCadastro => "Planos de Cobranças";
    }
}
