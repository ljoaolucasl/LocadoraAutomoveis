using LocadoraAutomoveis.Dominio.ModuloConfiguracao;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface ICalculoAluguel
    {
        decimal CalcularValorTotalDevolucao(Aluguel aluguelParaCalcular, PrecoCombustivel precoCombustivel);
        decimal CalcularValorTotalInicial(Aluguel aluguelParaCalcular);
    }
}
