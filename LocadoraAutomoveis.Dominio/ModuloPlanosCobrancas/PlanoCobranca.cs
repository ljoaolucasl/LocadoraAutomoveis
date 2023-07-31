using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public class PlanoCobranca : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal ValorDia { get; set; }
        public decimal ValorKmRodado { get; set; }
        public int KmLivre { get; set; }
        public TipoPlano Plano { get; set; }

        public PlanoCobranca(string nome, decimal valorDia, decimal valorKmRodado, int kmLivre, TipoPlano plano)
        {
            Nome = nome;
            ValorDia = valorDia;
            ValorKmRodado = valorKmRodado;
            KmLivre = kmLivre;
            Plano = plano;
        }

        public PlanoCobranca()
        {
            
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
