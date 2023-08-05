using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public class ControladorPlanosCobrancas : ControladorBase<PlanoCobranca, RepositorioPlanosCobrancas,
        ServicoPlanosCobrancas, TabelaPlanosCobrancasControl, TelaPlanosCobrancasForm, ServicoCategoriaAutomoveis, NoService>
    {
        public ControladorPlanosCobrancas(RepositorioPlanosCobrancas repositorioPlanosCobrancas, ServicoPlanosCobrancas servicoPlanosCobrancas, TabelaPlanosCobrancasControl tabelaPlanosCobrancas, ServicoCategoriaAutomoveis servicoCategoriaAutomoveis) : base(repositorioPlanosCobrancas, servicoPlanosCobrancas, tabelaPlanosCobrancas, servicoCategoriaAutomoveis)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        private void ObterDependencias(TelaPlanosCobrancasForm tela, PlanoCobranca planoCobranca)
        {
            var categorias = _servico2.SelecionarTodosOsRegistros();

            var planos = Enum.GetValues(typeof(TipoPlano)).Cast<TipoPlano>().ToList()
                .ConvertAll(x => x.ToDescriptionString());

            tela.CarregarCategorias(categorias);
            tela.CarregarPlanos(planos);
        }

        protected override string TipoCadastro => "Planos de Cobranças";
    }
}
