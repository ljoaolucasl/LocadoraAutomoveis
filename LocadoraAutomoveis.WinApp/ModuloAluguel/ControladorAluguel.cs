using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.WinApp.ModuloAluguel
{
    public class ControladorAluguel : ControladorBase<Aluguel, IRepositorioAluguel, IServicoAluguel, TabelaAluguelControl, TelaAluguelForm, NoService, NoService>
    {
        public ControladorAluguel(IRepositorioAluguel _repositorio, IServicoAluguel _servico, TabelaAluguelControl _tabela) : base(_repositorio, _servico, _tabela)
        {
            OnComandosAdicionaisAddAndEdit += ObterDependencias;
            OnVerificar += ObterSeFechado;
        }

        protected override string TipoCadastro => "Aluguéis";

        public Result ObterSeFechado(Aluguel aluguel)
        {
            return _servico.VerificarSeFechado(aluguel);
        }

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

            ObterDependencias(tela);

            tela.Entidade = aluguel;

            Result? resultado = ObterSeFechado(aluguel);

            if (resultado != null && resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage,
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }
            else
            {
                tela.OnGravarRegistro += _servico.Editar;

                TelaPrincipalForm.AtualizarStatus($"Devolução Aluguel");

                if (tela.ShowDialog() == DialogResult.OK)
                    CarregarRegistros();
            }
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

            tela.OnValidarEObterCupom += ValidarCupom;

            tela.OnCalcularAluguelPrevisto += CalcularValorTotalPrevisto;

            tela.OnCalcularAluguelFinal += CalcularValorTotalFinal;

            tela.CarregarDependencias(funcionarios, clientes, categorias, planos, condutores, automoveis, taxas);
        }
    }
}
