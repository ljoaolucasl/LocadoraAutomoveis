namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public interface IRepositorioBase<T> where T : EntidadeBase
    {
        List<T> SelecionarTodos();
        T? SelecionarPorID(Guid id);
        void Inserir(T registroParaAdicionar);
        void Editar(T registroParaEditar);
        void Excluir(T registroParaDeletar);
        bool Existe(T registroParaVerificar, bool exclusao = false);
    }
}
