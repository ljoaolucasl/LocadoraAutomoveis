namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        List<T> SelecionarTodos();
        T? SelecionarPorID(int id);
        void Inserir(T objetoParaAdicionar);
        void Editar(T objetoParaEditar);
        void Excluir(T objetoParaDeletar);
    }
}
