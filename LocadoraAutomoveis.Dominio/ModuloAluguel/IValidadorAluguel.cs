namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IValidadorAluguel : IValidador<Aluguel>
    {
        bool CupomValido(Aluguel aluguelParaValidar);
        bool ValidarSeAluguelConcluido(Aluguel aluguelParaValidar);
        bool VerificarSeAlugado(Aluguel aluguel);
    }
}
