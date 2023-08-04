using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public class Automovel : EntidadeBase
    {
        public CategoriaAutomoveis Categoria { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Modelo { get; set; }
        public byte[] Imagem { get; set; }
        public TipoCombustível TipoCombustivel { get; set; }
        public decimal CapacidadeCombustivel { get; set; }
        public int Ano { get; set; }
        public decimal Quilometragem { get; set; }

        public Automovel(CategoriaAutomoveis categoria, string placa, string marca, string cor, string modelo, byte[] imagem,
            TipoCombustível tipoCombustivel, decimal capacidadeCombustivel, int ano, decimal quilometragem)
        {
            Categoria = categoria;
            Placa = placa;
            Marca = marca;
            Cor = cor;
            Modelo = modelo;
            Imagem = imagem;
            TipoCombustivel = tipoCombustivel;
            CapacidadeCombustivel = capacidadeCombustivel;
            Ano = ano;
            Quilometragem = quilometragem;
        }

        public Automovel()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Automovel automoveis &&
                   EqualityComparer<CategoriaAutomoveis>.Default.Equals(Categoria, automoveis.Categoria) &&
                   Placa == automoveis.Placa &&
                   Marca == automoveis.Marca &&
                   Cor == automoveis.Cor &&
                   Modelo == automoveis.Modelo &&
                   TipoCombustivel == automoveis.TipoCombustivel &&
                   CapacidadeCombustivel == automoveis.CapacidadeCombustivel &&
                   Ano == automoveis.Ano &&
                   Quilometragem == automoveis.Quilometragem;
        }
    }

    public enum TipoCombustível
    {
        [Description("Gasolina")]
        Gasolina,

        [Description("Etanol")]
        Etanol,

        [Description("Diesel")]
        Diesel
    }
}
