using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;

namespace LocadoraAutomoveis.WinApp.Compartilhado
{
    public abstract class ControladorBase<TEntidade, TRepositorio, TServico, TTabela, TTela, TServico2, TServico3> : IControladorBase
        where TEntidade : EntidadeBase
        where TRepositorio : IRepositorioBase<TEntidade>
        where TServico : IServicoBase<TEntidade>
        where TTabela : ITabelaBase<TEntidade>
        where TTela : ITelaBase<TEntidade>, new()
    {
        protected TServico _servico;
        protected TRepositorio _repositorio;
        protected TServico2 _servico2;
        protected TServico3 _servico3;
        protected TTabela _tabela;

        protected abstract string TipoCadastro { get; }

        protected event Action<TTela, TEntidade> OnComandosAdicionaisAddAndEdit;

        protected event Func<TEntidade, Result> OnVerificar;

        public ControladorBase()
        {

        }

        public ControladorBase(TRepositorio _repositorio, TServico _servico, TTabela _tabela)
        {
            this._repositorio = _repositorio;
            this._servico = _servico;
            this._tabela = _tabela;
        }

        public ControladorBase(TRepositorio _repositorio, TServico _servico, TTabela _tabela, TServico2 _repositorio2)
        {
            this._repositorio = _repositorio;
            this._servico = _servico;
            this._tabela = _tabela;
            this._servico2 = _repositorio2;
        }

        public ControladorBase(TRepositorio _repositorio, TServico _servico, TTabela _tabela, TServico2 _repositorio2, TServico3 _repositorio3)
        {
            this._repositorio = _repositorio;
            this._servico = _servico;
            this._tabela = _tabela;
            this._servico2 = _repositorio2;
            this._servico3 = _repositorio3;
        }

        public virtual string ToolTipAdicionar => $"Adicionar {typeof(TEntidade).Name}";
        public virtual string ToolTipEditar => $"Editar {typeof(TEntidade).Name} existente";
        public virtual string ToolTipExcluir => $"Excluir {typeof(TEntidade).Name} existente";

        public virtual void Inserir()
        {
            TTela tela = new();

            OnComandosAdicionaisAddAndEdit?.Invoke(tela, tela.Entidade);

            tela.OnGravarRegistro += _servico.Inserir;

            TelaPrincipalForm.AtualizarStatus($"Cadastrando {typeof(TEntidade).Name}");

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarRegistros();
        }

        public virtual void Editar()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TTela tela = new();

            OnComandosAdicionaisAddAndEdit?.Invoke(tela, entidade);

            tela.Entidade = entidade;

            Result? resultado = OnVerificar?.Invoke(entidade);

            if (resultado != null && resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage,
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                tela.OnGravarRegistro += _servico.Editar;

                TelaPrincipalForm.AtualizarStatus($"Editando {typeof(TEntidade).Name}");

                if (tela.ShowDialog() == DialogResult.OK)
                    CarregarRegistros();
            }
        }

        public virtual void Excluir()
        {
            TEntidade? entidade = _tabela.ObterRegistroSelecionado();

            TelaPrincipalForm.AtualizarStatus($"Excluindo {typeof(TEntidade).Name}");

            if (MessageBox.Show($"Deseja mesmo excluir?", $"Exclusão de {typeof(TEntidade).Name}",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Result resultado = _servico.Excluir(entidade);

                if (resultado.IsFailed)
                {
                    MessageBox.Show(resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage,
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
                else
                    CarregarRegistros();
            }
        }

        public virtual void CarregarRegistros()
        {
            _tabela.AtualizarLista(_repositorio.SelecionarTodos());
        }

        public virtual string ObterTipoCadastro()
        {
            string nomeEntidade = typeof(TEntidade).Name;

            return $"Cadastro de {TipoCadastro}";
        }

        public virtual DataGridView ObterGrid()
        {
            return _tabela.ObterGrid();
        }
    }
}
