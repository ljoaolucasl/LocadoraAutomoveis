namespace LocadoraAutomoveis.Dominio.Configuracoes
{
    public interface IRepositorioConfiguracao
    {
        void SalvarConfiguracoesPrecos(PrecoCombustivel configuracao);
        PrecoCombustivel ObterConfiguracaoPrecos();
    }
}
