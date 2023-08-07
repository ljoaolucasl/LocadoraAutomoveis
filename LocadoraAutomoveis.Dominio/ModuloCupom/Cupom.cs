using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class Cupom : EntidadeBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataValidade { get; set; }
        public Parceiro Parceiro { get; set; }
        public int QtdUsos { get; set; }

        public Cupom(string nome, decimal valor, DateTime dataValidade, Parceiro parceiro)
        {
            Nome = nome;
            Valor = valor;
            DataValidade = dataValidade;
            Parceiro = parceiro;
            QtdUsos = 0;
        }

        public Cupom()
        {
            
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Cupom cupom &&
                   ID.Equals(cupom.ID) &&
                   Nome == cupom.Nome &&
                   Valor == cupom.Valor &&
                   DataValidade == cupom.DataValidade &&
                   EqualityComparer<Parceiro>.Default.Equals(Parceiro, cupom.Parceiro) &&
                   QtdUsos == cupom.QtdUsos;
        }
    }
}
