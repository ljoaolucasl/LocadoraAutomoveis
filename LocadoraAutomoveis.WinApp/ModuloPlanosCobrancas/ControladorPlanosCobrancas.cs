using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;

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

            tela.CarregarCategorias(categorias);
        }

        protected override string TipoCadastro => "Planos de Cobranças";
    }
}
