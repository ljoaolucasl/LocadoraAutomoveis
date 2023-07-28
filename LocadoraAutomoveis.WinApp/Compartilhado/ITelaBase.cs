using FluentResults;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public interface ITelaBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        TEntidade? Entidade { get; set; }

        event Func<TEntidade, Result> OnGravarRegistro;

        DialogResult ShowDialog();
    }
}
