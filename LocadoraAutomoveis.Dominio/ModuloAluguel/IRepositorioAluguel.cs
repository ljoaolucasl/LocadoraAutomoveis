using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IRepositorioAluguel : IRepositorioBase<Aluguel>
    {
        bool CupomExiste(Aluguel aluguelParaValidar, List<Cupom> cupons);
    }
}
