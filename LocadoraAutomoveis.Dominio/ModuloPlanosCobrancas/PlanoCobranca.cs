using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public class PlanoCobranca : EntidadeBase
    {
        public decimal ValorDia { get; set; }
        public decimal ValorKmRodado { get; set; }
        public int KmLivre { get; set; }
        public TipoPlano Plano { get; set; }
        public CategoriaAutomoveis CategoriaAutomoveis { get; set; }

        public PlanoCobranca(decimal valorDia, decimal valorKmRodado, int kmLivre, TipoPlano plano, CategoriaAutomoveis categoriaAutomoveis)
        {
            ValorDia = valorDia;
            ValorKmRodado = valorKmRodado;
            KmLivre = kmLivre;
            Plano = plano;
            CategoriaAutomoveis = categoriaAutomoveis;
        }

        public PlanoCobranca()
        {
            
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoCobranca cobranca &&
                   ID == cobranca.ID &&
                   Nome == cobranca.Nome &&
                   ValorDia == cobranca.ValorDia &&
                   ValorKmRodado == cobranca.ValorKmRodado &&
                   KmLivre == cobranca.KmLivre &&
                   Plano == cobranca.Plano;
        }
    }
}
