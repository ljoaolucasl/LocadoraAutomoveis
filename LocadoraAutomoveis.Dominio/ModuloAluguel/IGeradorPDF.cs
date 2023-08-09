namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IGeradorPDF
    {
        byte[] GerarPDF(Aluguel aluguel);
    }
}
