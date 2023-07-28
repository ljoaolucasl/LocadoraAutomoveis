namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public interface ITabelaBase<TEntidade>
        where TEntidade : EntidadeBase
    {
        public void AtualizarLista(List<TEntidade> registros);

        public TEntidade ObterRegistroSelecionado();
    }
}
