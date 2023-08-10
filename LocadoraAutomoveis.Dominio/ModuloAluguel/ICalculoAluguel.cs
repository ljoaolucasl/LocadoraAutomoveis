namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface ICalculoAluguel
    {
        decimal CalcularValorTotalDevolucao(Aluguel aluguelParaCalcular);
        decimal CalcularValorTotalInicial(Aluguel aluguelParaCalcular);
    }
}
