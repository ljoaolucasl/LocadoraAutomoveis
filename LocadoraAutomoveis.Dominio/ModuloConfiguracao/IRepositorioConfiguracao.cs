namespace LocadoraAutomoveis.Dominio.ModuloConfiguracao
{
    public interface IRepositorioConfiguracao
    {
        void SalvarConfiguracoesPrecos(PrecoCombustivel configuracao);
        PrecoCombustivel ObterConfiguracaoPrecos();
    }
}
