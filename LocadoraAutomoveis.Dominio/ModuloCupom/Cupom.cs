using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public string Parceiro { get; set; }

        public Cupom(string nome, decimal valor, DateTime dataValidade, string parceiro)
        {
            Nome = nome;
            Valor = valor;
            DataValidade = dataValidade;
            Parceiro = parceiro;
        }

        public Cupom()
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Cupom cupom &&
                   ID == cupom.ID &&
                   Nome == cupom.Nome &&
                   Valor == cupom.Valor &&
                   DataValidade == cupom.DataValidade &&
                   Parceiro == cupom.Parceiro;
        }
    }
}
