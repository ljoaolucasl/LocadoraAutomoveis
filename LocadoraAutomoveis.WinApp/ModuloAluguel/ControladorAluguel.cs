using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase<Aluguel, IRepositorioAluguel, IServicoAluguel, TabelaAluguelControl, TelaAluguelForm, NoService, NoService>
    {
        public ControladorAluguel(IRepositorioAluguel _repositorio, IServicoAluguel _servico, TabelaAluguelControl _tabela) : base(_repositorio, _servico, _tabela)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
        }

        protected override string TipoCadastro => "Aluguéis";

        private Result ValidarCupom(Aluguel aluguel)
        {
            List<IError> erros = _servico.ValidarCupom(aluguel);

            if (erros.Count > 0)
                return Result.Fail(erros);

            return Result.Ok();
        }

        private decimal CalcularValorTotalPrevisto(Aluguel aluguel)
        {
            return _servico.CalcularValorPrevisto(aluguel);
        }

        private decimal CalcularValorTotalFinal(Aluguel aluguel)
        {
            return _servico.CalcularValorDevolucao(aluguel);
        }

        public void Devolver()
        {
            var aluguel = _tabela.ObterRegistroSelecionado();

            TelaAluguelDevolucaoForm tela = new();

            tela.Entidade = aluguel;
            tela.OnGravarRegistro+= _servico.Editar;

            ObterDependencias(tela);

            TelaPrincipalForm.AtualizarStatus($"Devolução Aluguel");

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarRegistros();
        }

        private void ObterDependencias(ITelaAluguel tela)
        {
            var funcionarios = _servico.servicoFuncionario.SelecionarTodosOsRegistros();
            var clientes = _servico.servicoCliente.SelecionarTodosOsRegistros();
            var categorias = _servico.servicoCategoriaAutomoveis.SelecionarTodosOsRegistros();
            var planos = _servico.servicoPlanosCobrancas.SelecionarTodosOsRegistros();
            var condutores = _servico.servicoCondutores.SelecionarTodosOsRegistros();
            var automoveis = _servico.servicoAutomovel.SelecionarTodosOsRegistros();
            var taxas = _servico.servicoTaxaEServico.SelecionarTodosOsRegistros();

            tela.CarregarDependencias(funcionarios, clientes, categorias, planos, condutores, automoveis, taxas);

            tela.OnValidarEObterCupom += ValidarCupom;

            tela.OnCalcularAluguelPrevisto += CalcularValorTotalPrevisto;

            tela.OnCalcularAluguelFinal += CalcularValorTotalFinal;
        }
    }
}
