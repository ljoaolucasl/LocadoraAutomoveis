using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class CalculoAluguel : ICalculoAluguel
    {
        public decimal CalcularValorTotalInicial(Aluguel aluguel)
        {
            decimal valorTotal = 0;

            TimeSpan intervalo = aluguel.DataPrevistaRetorno - aluguel.DataLocacao;

            int diasLocados = (int)intervalo.TotalDays;

            valorTotal = CalcularValorPlanoCobranca(valorTotal, aluguel.PlanoCobranca, aluguel.Plano, diasLocados);
            valorTotal = CalcularValorTaxasEServicos(valorTotal, aluguel.ListaTaxasEServicos);
            valorTotal = AplicarDescontoCupom(valorTotal, aluguel.Cupom);

            return valorTotal;
        }

        public decimal CalcularValorTotalDevolucao(Aluguel aluguelParaCalcular)
        {
            throw new NotImplementedException();
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

        private decimal AplicarDescontoCupom(decimal valorTotal, Cupom cupom)
        {
            if (cupom != null)
                valorTotal -= cupom.Valor;

            return valorTotal;
        }
    }
}
