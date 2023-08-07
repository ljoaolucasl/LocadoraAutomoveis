using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorioBase<Aluguel>
    {
        bool CupomNaoExiste(Aluguel aluguelParaValidar, List<Cupom> cupons);
    }
}
