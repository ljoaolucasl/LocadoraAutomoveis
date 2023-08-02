using FluentResults;

namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public interface IServicoBase<T> where T : EntidadeBase
    {
        Result ValidarRegistro(T registroParaValidar);
        IEnumerable<T> SelecionarTodosOsRegistros();
        Result Inserir(T registroParaAdicionar);
        Result Editar(T registroParaEditar);
        Result Excluir(T registroParaExcluir);
        T SelecionarRegistroPorID(Guid registroID);
    }
}
