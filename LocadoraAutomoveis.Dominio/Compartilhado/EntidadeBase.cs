using SequentialGuid;

namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public class EntidadeBase
    {
        public Guid ID { get; set; }

        public EntidadeBase()
        {
            ID = SequentialGuidGenerator.Instance.NewGuid();
        }
    }
}
