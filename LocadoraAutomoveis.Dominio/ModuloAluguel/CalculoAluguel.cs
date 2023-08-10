using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class CalculoAluguel : ICalculoAluguel
    {
        public decimal CalcularValorTotalInicial(Aluguel aluguelParaCalcular)
        {
            decimal valorTotal = 0;

            TimeSpan intervalo = aluguelParaCalcular.DataPrevistaRetorno - aluguelParaCalcular.DataLocacao;

            int diasLocados = (int)intervalo.TotalDays;

            valorTotal = CalcularValorPlanoCobranca(valorTotal, aluguelParaCalcular.PlanoCobranca, aluguelParaCalcular.Plano, diasLocados);
            valorTotal = CalcularValorTaxasEServicos(valorTotal, aluguelParaCalcular.ListaTaxasEServicos);
            valorTotal = AplicarDescontoCupom(valorTotal, aluguelParaCalcular.Cupom);
            return valorTotal;
        }

        public decimal CalcularValorTotalDevolucao(Aluguel aluguelParaCalcular, PrecoCombustivel precoCombustivel)
        {
            decimal valorTotal = 0;

            TimeSpan intervalo = aluguelParaCalcular.DataPrevistaRetorno - aluguelParaCalcular.DataLocacao;

            TimeSpan diasAtraso = new(1);

            if (aluguelParaCalcular.DataDevolucao.HasValue)
                diasAtraso = aluguelParaCalcular.DataPrevistaRetorno - aluguelParaCalcular.DataDevolucao.Value;

            int diasLocados = (int)intervalo.TotalDays;

            valorTotal = CalcularPlanoCobrancaFinal(valorTotal, aluguelParaCalcular.PlanoCobranca, aluguelParaCalcular.Plano, aluguelParaCalcular.QuilometrosRodados.Value, diasLocados);
            valorTotal = CalcularValorTaxasEServicos(valorTotal, aluguelParaCalcular.ListaTaxasEServicos);
            valorTotal = CalcularValorCombustivel(valorTotal, aluguelParaCalcular.Automovel.CapacidadeCombustivel, aluguelParaCalcular.CombustivelRestante.Value, aluguelParaCalcular.Automovel.TipoCombustivel, precoCombustivel);
            valorTotal = AplicarDescontoCupom(valorTotal, aluguelParaCalcular.Cupom);
            valorTotal = AplicarMultaAtraso(valorTotal, Convert.ToInt32(diasAtraso));

            return valorTotal;
        }

        private decimal CalcularPlanoCobrancaFinal(decimal valorTotal, PlanoCobranca planoCobranca, TipoPlano tipoPlano, decimal quilometrosRodados, int diasLocacao)
        {
            switch (tipoPlano)
            {
                case TipoPlano.Diario:
                    valorTotal += planoCobranca.PlanoDiario_ValorDiario * diasLocacao;
                    decimal valorPorKmRodado = planoCobranca.PlanoDiario_ValorKm;
                    valorTotal += valorPorKmRodado * quilometrosRodados;
                    break;

                case TipoPlano.Livre:
                    valorTotal += planoCobranca.PlanoLivre_ValorDiario * diasLocacao;
                    break;

                case TipoPlano.Controlador:
                    valorTotal += planoCobranca.PlanoControlador_ValorDiario * diasLocacao;
                    decimal kmFranquiaDiaria = planoCobranca.PlanoControlador_ValorKm;
                    if (quilometrosRodados > kmFranquiaDiaria)
                    {
                        decimal kmExcedente = quilometrosRodados - kmFranquiaDiaria;
                        decimal valorPorKmExcedente = planoCobranca.PlanoControlador_LimiteKm;
                        valorTotal += valorPorKmExcedente * kmExcedente;
                    }
                    break;
            }

            return valorTotal;
        }

        private decimal CalcularValorPlanoCobranca(decimal valorTotal, PlanoCobranca planoCobranca, TipoPlano tipoPlano, int diasLocados)
        {
            decimal valorBaseDoPlano;
            switch (tipoPlano)
            {
                case TipoPlano.Diario:
                    valorBaseDoPlano = planoCobranca.PlanoDiario_ValorDiario;
                    valorTotal += valorBaseDoPlano * diasLocados;
                    break;

                case TipoPlano.Livre:
                    valorBaseDoPlano = planoCobranca.PlanoLivre_ValorDiario;
                    valorTotal += valorBaseDoPlano * diasLocados;
                    break;

                case TipoPlano.Controlador:
                    valorBaseDoPlano = planoCobranca.PlanoControlador_ValorDiario;
                    valorTotal += valorBaseDoPlano * diasLocados;
                    break;
            }

            return valorTotal;
        }

        private decimal CalcularValorTaxasEServicos(decimal valorTotal, List<TaxaEServico> taxasEServicos)
        {
            if (taxasEServicos != null)
                valorTotal += taxasEServicos.Sum(taxa => taxa.Valor);

            return valorTotal;
        }

        private decimal CalcularValorCombustivel(decimal valorTotal, decimal capacidadeCombustivel, NivelTanque nivelTanque, TipoCombustível tipoCombustivel, PrecoCombustivel precoCombustivel)
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

            valorTotal += quantidadeCombustivel * valorCombustivel;

            return valorTotal;
        }

        private decimal AplicarDescontoCupom(decimal valorTotal, Cupom cupom)
        {
            if (cupom != null)
                valorTotal -= cupom.Valor;

            return valorTotal;
        }

        private decimal AplicarMultaAtraso(decimal valorTotal, int diasAtraso)
        {
            decimal multa = valorTotal * 0.1m;
            decimal taxaAtraso = 50 * diasAtraso;

            return multa + taxaAtraso;
        }
    }
}
