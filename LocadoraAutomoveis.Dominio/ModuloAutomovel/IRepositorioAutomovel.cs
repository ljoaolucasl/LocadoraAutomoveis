using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomovel
{
    public interface IRepositorioAutomovel : IRepositorioBase<Automovel>
    {
        List<Automovel> SelecionarPorCategoria(CategoriaAutomoveis categoria);
    }
}
