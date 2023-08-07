namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public interface IValidadorAutomovel : IValidador<Automovel>
    {
        bool VerificarSeAlugado(Automovel automovelParaValidar);
    }
}
