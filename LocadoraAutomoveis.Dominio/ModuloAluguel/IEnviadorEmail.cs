namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IEnviadorEmail
    {
        void EnviarEmailAluguel(Aluguel aluguel, byte[] pdfBytes);
    }
}
