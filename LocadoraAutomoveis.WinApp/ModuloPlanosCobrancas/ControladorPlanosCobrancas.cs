using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas
{
    public class ControladorPlanosCobrancas : ControladorBase<PlanoCobranca, RepositorioPlanosCobrancas,
        ServicoPlanosCobrancas, TabelaPlanosCobrancasControl, TelaPlanosCobrancasForm, NoRepository, NoRepository>
    {
        public ControladorPlanosCobrancas()
        {
            
        }

        public override DataGridView ObterTabela()
        {
            return (DataGridView)_tabela.Controls[0];
        }
    }
}
