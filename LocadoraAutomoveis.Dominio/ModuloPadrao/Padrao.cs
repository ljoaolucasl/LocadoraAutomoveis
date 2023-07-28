using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Dominio.ModuloPadrao
{
    public class Padrao : EntidadeBase
    {
        public string Nome { get; set; }

        public Padrao(string nome)
        {
            Nome = nome;
        }
    }
}
