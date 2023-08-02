namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public interface ITabelaBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        DataGridView ObterGrid();

        void AtualizarLista(List<TEntidade> registros);

        TEntidade ObterRegistroSelecionado();
    }
}
