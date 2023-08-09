using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public class PlanoCobranca : EntidadeBase
    {
        public decimal PlanoDiario_ValorDiario { get; set; }
        public decimal PlanoDiario_ValorKm { get; set; }
        public decimal PlanoLivre_ValorDiario { get; set; }
        public decimal PlanoControlador_ValorDiario { get; set; }
        public decimal PlanoControlador_ValorKm { get; set; }
        public int PlanoControlador_LimiteKm { get; set; }
        public CategoriaAutomoveis CategoriaAutomoveis { get; set; }

        public PlanoCobranca(decimal planoDiario_ValorDiario, decimal planoDiario_ValorKm, decimal planoLivre_ValorDiario, decimal planoControlador_ValorDiario, decimal planoControlador_ValorKm, int planoControlador_LimiteKm, CategoriaAutomoveis categoriaAutomoveis)
        {
            PlanoDiario_ValorDiario = planoDiario_ValorDiario;
            PlanoDiario_ValorKm = planoDiario_ValorKm;
            PlanoLivre_ValorDiario = planoLivre_ValorDiario;
            PlanoControlador_ValorDiario = planoControlador_ValorDiario;
            PlanoControlador_ValorKm = planoControlador_ValorKm;
            PlanoControlador_LimiteKm = planoControlador_LimiteKm;
            CategoriaAutomoveis = categoriaAutomoveis;
        }

        public PlanoCobranca()
        {
            
        }

        public static decimal CalcularPlanoCobranca(decimal valorTotal, PlanoCobranca planoCobranca, TipoPlano tipoPlano, decimal? quilometrosRodados)
        {
            decimal valorBaseDoPlano;
            switch (tipoPlano)
            {
                case TipoPlano.Diario:
                    valorBaseDoPlano = planoCobranca.PlanoDiario_ValorDiario;
                    valorTotal += valorBaseDoPlano;
                    break;

                case TipoPlano.Livre:
                    valorBaseDoPlano = planoCobranca.PlanoLivre_ValorDiario;
                    valorTotal += valorBaseDoPlano;
                    break;

                case TipoPlano.Controlador:
                    valorBaseDoPlano = planoCobranca.PlanoControlador_ValorDiario;
                    valorTotal += valorBaseDoPlano;
                    break;
            }

            return valorTotal;
        }

        public override bool Equals(object? obj)
        {
            return obj is PlanoCobranca cobranca &&
                   ID.Equals(cobranca.ID) &&
                   PlanoDiario_ValorDiario == cobranca.PlanoDiario_ValorDiario &&
                   PlanoDiario_ValorKm == cobranca.PlanoDiario_ValorKm &&
                   PlanoLivre_ValorDiario == cobranca.PlanoLivre_ValorDiario &&
                   PlanoControlador_ValorDiario == cobranca.PlanoControlador_ValorDiario &&
                   PlanoControlador_ValorKm == cobranca.PlanoControlador_ValorKm &&
                   PlanoControlador_LimiteKm == cobranca.PlanoControlador_LimiteKm &&
                   EqualityComparer<CategoriaAutomoveis>.Default.Equals(CategoriaAutomoveis, cobranca.CategoriaAutomoveis);
        }
    }
}
