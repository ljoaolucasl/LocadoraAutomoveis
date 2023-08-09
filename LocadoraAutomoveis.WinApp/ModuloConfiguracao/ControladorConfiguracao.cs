using LocadoraAutomoveis.Dominio.ModuloConfiguracao;

namespace LocadoraAutomoveis.WinApp.ModuloConfiguracao
{
    public class ControladorConfiguracao
    {
        private readonly IRepositorioConfiguracao _repositorioConfiguracao;

        public ControladorConfiguracao(IRepositorioConfiguracao repositorioConfiguracao)
        {
            _repositorioConfiguracao = repositorioConfiguracao;
        }

        public void ConfigurarPrecos()
        {
            TelaConfiguracaoPrecosForm tela = new();

            tela.configuracao = _repositorioConfiguracao.ObterConfiguracaoPrecos();

            TelaPrincipalForm.AtualizarStatus($"Configurando Preços");

            if (tela.ShowDialog() == DialogResult.OK)
                _repositorioConfiguracao.SalvarConfiguracoesPrecos(tela.configuracao);
        }
    }
}
