using FluentResults;

namespace LocadoraAutomoveis.Dominio.Compartilhado
{
    public interface IServicoBase<T> where T : EntidadeBase
    {
        Result ValidarRegistro(T padraoParaValidar);
        IEnumerable<T> SelecionarTodosOsRegistros();
        Result Inserir(T padraoParaAdicionar);
        Result Editar(T padraoParaEditar);
        Result Excluir(T padraoParaExcluir);
        T SelecionarRegistroPorID(int padraoID);
    }
}
