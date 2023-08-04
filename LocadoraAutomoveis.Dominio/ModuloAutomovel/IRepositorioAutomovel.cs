using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public interface IRepositorioAutomovel : IRepositorioBase<Automovel>
    {
        List<Automovel> SelecionarPorCategoria(CategoriaAutomoveis categoria);
    }
}
