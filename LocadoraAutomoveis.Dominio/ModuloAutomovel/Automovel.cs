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
        public bool Alugado { get; set; }

        public Automovel(CategoriaAutomoveis categoria, string placa, string marca, string cor, string modelo, byte[] imagem,
            TipoCombustível tipoCombustivel, decimal capacidadeCombustivel, int ano, decimal quilometragem, bool alugado)
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
            Alugado = alugado;
        }

        public Automovel()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Automovel automovel &&
                   ID.Equals(automovel.ID) &&
                   EqualityComparer<CategoriaAutomoveis>.Default.Equals(Categoria, automovel.Categoria) &&
                   Placa == automovel.Placa &&
                   Marca == automovel.Marca &&
                   Cor == automovel.Cor &&
                   Modelo == automovel.Modelo &&
                   EqualityComparer<byte[]>.Default.Equals(Imagem, automovel.Imagem) &&
                   TipoCombustivel == automovel.TipoCombustivel &&
                   CapacidadeCombustivel == automovel.CapacidadeCombustivel &&
                   Ano == automovel.Ano &&
                   Quilometragem == automovel.Quilometragem &&
                   Alugado == automovel.Alugado;
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
