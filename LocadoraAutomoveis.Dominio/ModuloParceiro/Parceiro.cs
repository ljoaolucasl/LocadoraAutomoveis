using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase
    {
        public string Nome { get; set; }
        public Cupom Cupom { get; set; }

        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public Parceiro()
        {
            
        }

        public override bool Equals(object? obj)
        {
            return obj is Parceiro parceiro &&
                   ID == parceiro.ID &&
                   Nome == parceiro.Nome;
        }
    }
}
