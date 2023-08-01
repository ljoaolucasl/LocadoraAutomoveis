using Microsoft.EntityFrameworkCore;
using LocadoraAutomoveis.Dominio.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Compartilhado
{
    public abstract class RepositorioBase<TEntidade> : IRepositorioBase<TEntidade>
        where TEntidade : EntidadeBase
    {
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
            ContextoDb.SaveChanges();
        }

        public void Editar(TEntidade objetoParaEditar)
        {
            ContextoDb.Update(objetoParaEditar);
            ContextoDb.SaveChanges();
        }

        public void Excluir(TEntidade objetoParaDeletar)
        {
            ContextoDb.Remove(objetoParaDeletar);
            ContextoDb.SaveChanges();
        }

        public TEntidade? SelecionarPorID(int id)
        {
            return Registros.Where(r => r.ID == id).FirstOrDefault();
        }

        public List<TEntidade> SelecionarTodos()
        {
            return Registros.ToList();
        }
    }
}
