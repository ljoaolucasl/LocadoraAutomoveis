using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.Extensions;
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
            return Plano.ToDescriptionString();
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoCobranca cobranca &&
                   ID.Equals(cobranca.ID) &&
                   ValorDia == cobranca.ValorDia &&
                   ValorKmRodado == cobranca.ValorKmRodado &&
                   KmLivre == cobranca.KmLivre &&
                   Plano == cobranca.Plano &&
                   EqualityComparer<CategoriaAutomoveis>.Default.Equals(CategoriaAutomoveis, cobranca.CategoriaAutomoveis);
        }
    }
}
