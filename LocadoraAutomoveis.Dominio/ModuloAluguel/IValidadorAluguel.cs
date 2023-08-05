namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IValidadorAluguel : IValidador<Aluguel>
    {
        bool ValidarSeAluguelConcluido(Aluguel aluguelParaValidar);
    }
}
