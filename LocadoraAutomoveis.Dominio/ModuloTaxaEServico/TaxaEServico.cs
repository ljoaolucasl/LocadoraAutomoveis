using LocadoraAutomoveis.Dominio.Compartilhado;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloTaxaEServico
{
    public class TaxaEServico : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public Tipo Tipo { get; set; }

        public TaxaEServico(string nome, decimal valor, Tipo tipo)
        {
            Nome = nome;
            Valor = valor;
            Tipo = tipo;
        }

        public TaxaEServico()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is TaxaEServico servico &&
                   ID.Equals(servico.ID) &&
                   Nome == servico.Nome &&
                   Valor == servico.Valor &&
                   Tipo == servico.Tipo;
        }
    }

    public enum Tipo
    {
        [Description("Fixo")]
        CalculoFixo = 1,

        [Description("Diário")]
        Diario = 2
    }
}
