using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorioBase<Aluguel>
    {
        Cupom? ObterCupomCompleto(Aluguel aluguelParaValidar, List<Cupom> cupoms);
    }
}
