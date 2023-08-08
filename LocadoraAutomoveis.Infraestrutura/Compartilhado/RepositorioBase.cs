using LocadoraAutomoveis.Dominio.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infraestrutura.Compartilhado
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        public RepositorioBase()
        {
        }

        public ContextoDados ContextoDb { get; }

        public DbSet<TEntidade> Registros { get; }

        public RepositorioBase(ContextoDados contextoDb)
        {
            ContextoDb = contextoDb;
            Registros = contextoDb.Set<TEntidade>();
        }

        public void Inserir(TEntidade objetoParaAdicionar)
        {
            ContextoDb.Add(objetoParaAdicionar);
        }

        public void Editar(TEntidade objetoParaEditar)
        {
            ContextoDb.Update(objetoParaEditar);
        }

        public void Excluir(TEntidade objetoParaDeletar)
        {
            ContextoDb.Remove(objetoParaDeletar);
        }

        public abstract bool Existe(TEntidade objetoParaVerificar, bool exclusao = false);

        public TEntidade? SelecionarPorID(Guid id)
        {
            return Registros.Where(r => r.ID == id).FirstOrDefault();
        }

        public virtual List<TEntidade> SelecionarTodos()
        {
            return Registros.ToList();
        }
    }
}
