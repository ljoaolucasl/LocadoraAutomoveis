using FluentResults;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorioBase<Aluguel>
    {
        Result ValidarCupom(Aluguel aluguelParaValidar);
    }
}
