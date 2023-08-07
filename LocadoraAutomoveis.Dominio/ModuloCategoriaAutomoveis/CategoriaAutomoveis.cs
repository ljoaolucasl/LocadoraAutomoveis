namespace LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis
{
    public class CategoriaAutomoveis : EntidadeBase
    {
        public string Nome { get; set; }

        public CategoriaAutomoveis(string nome)
        {
            Nome = nome;
        }

        public CategoriaAutomoveis()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is CategoriaAutomoveis automoveis &&
                   ID.Equals(automoveis.ID) &&
                   Nome == automoveis.Nome;
        }
    }
}
