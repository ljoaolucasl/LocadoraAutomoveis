using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;

namespace LocadoraAutomoveis.Dominio.ModuloConfiguracao
{
    public class PrecoCombustivel
    {
        public decimal Gasolina { get; set; }
        public decimal Diesel { get; set; }
        public decimal Etanol { get; set; }
        public decimal Gas { get; set; }

        public static decimal CalcularValorCombustivel(decimal capacidadeCombustivel, NivelTanque nivelTanque, TipoCombustível tipoCombustivel, PrecoCombustivel precoCombustivel)
        {
            decimal quantidadeCombustivel = 0;
            decimal valorCombustivel = 0;

            switch (nivelTanque)
            {
                case NivelTanque.Vazio:
                    quantidadeCombustivel = 0;
                    break;
                case NivelTanque.UmQuarto:
                    quantidadeCombustivel = capacidadeCombustivel * 0.25m;
                    break;
                case NivelTanque.MeioTanque:
                    quantidadeCombustivel = capacidadeCombustivel * 0.5m;
                    break;
                case NivelTanque.TresQuartos:
                    quantidadeCombustivel = capacidadeCombustivel * 0.75m;
                    break;
                case NivelTanque.Cheio:
                    quantidadeCombustivel = capacidadeCombustivel;
                    break;
            }

            switch (tipoCombustivel)
            {
                case TipoCombustível.Gasolina:
                    valorCombustivel = precoCombustivel.Gasolina;
                    break;
                case TipoCombustível.Diesel:
                    valorCombustivel = precoCombustivel.Diesel;
                    break;
                case TipoCombustível.Etanol:
                    valorCombustivel = precoCombustivel.Etanol;
                    break;
                case TipoCombustível.Gas:
                    valorCombustivel = precoCombustivel.Gas;
                    break;
            }

            decimal valorTotal = 0;
            valorTotal += quantidadeCombustivel * valorCombustivel;

            return valorTotal;
        }
    }
}
