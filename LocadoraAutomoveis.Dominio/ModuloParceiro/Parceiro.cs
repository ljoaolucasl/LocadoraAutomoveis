using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
    public class Parceiro : EntidadeBase
    {
        public string Nome { get; set; }

        public Parceiro(string nome)
        {
            Nome = nome;
        }

        public Parceiro()
        {
            
        }

        public override string ToString()
        {
            return Nome;
        }

        public override bool Equals(object? obj)
        {
            return obj is Parceiro parceiro &&
                   ID == parceiro.ID &&
                   Nome == parceiro.Nome;
        }
    }
}
