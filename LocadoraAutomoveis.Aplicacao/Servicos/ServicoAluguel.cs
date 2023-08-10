using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.ModuloConfiguracao;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoAluguel : IServicoAluguel
    {
        private readonly IRepositorioAluguel _repositorioAluguel;
        private readonly IValidadorAluguel _validadorAluguel;
        private readonly IContextoPersistencia _contextoPersistencia;
        public IServicoFuncionario servicoFuncionario { get; }
        public IServicoCliente servicoCliente { get; }
        public IServicoCategoriaAutomoveis servicoCategoriaAutomoveis { get; }
        public IServicoPlanoCobranca servicoPlanosCobrancas { get; }
        public IServicoCondutor servicoCondutores { get; }
        public IServicoAutomovel servicoAutomovel { get; }
        public IServicoCupom servicoCupom { get; }
        public IServicoTaxaEServico servicoTaxaEServico { get; }
        public IEnviadorEmail enviarEmail { get; }
        public IGeradorPDF gerarPDF { get; }
        public ICalculoAluguel calculoAluguel { get; }
        public IRepositorioConfiguracao repositorioConfiguracao { get; }

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel,
            IContextoPersistencia contextoPersistencia, IServicoFuncionario servicoFuncionario,
            IServicoCliente servicoCliente, IServicoCategoriaAutomoveis servicoCategoriaAutomoveis,
            IServicoPlanoCobranca servicoPlanosCobrancas, IServicoCondutor servicoCondutores,
            IServicoAutomovel servicoAutomovel, IServicoCupom servicoCupom, IServicoTaxaEServico servicoTaxaEServico,
            IEnviadorEmail enviarEmail, IGeradorPDF gerarPDF, ICalculoAluguel calculoAluguel, IRepositorioConfiguracao repositorioConfiguracao)
        {
            _repositorioAluguel = repositorioAluguel;
            _validadorAluguel = validadorAluguel;
            _contextoPersistencia = contextoPersistencia;
            this.servicoFuncionario = servicoFuncionario;
            this.servicoCliente = servicoCliente;
            this.servicoCategoriaAutomoveis = servicoCategoriaAutomoveis;
            this.servicoPlanosCobrancas = servicoPlanosCobrancas;
            this.servicoCondutores = servicoCondutores;
            this.servicoAutomovel = servicoAutomovel;
            this.servicoCupom = servicoCupom;
            this.servicoTaxaEServico = servicoTaxaEServico;
            this.enviarEmail = enviarEmail;
            this.gerarPDF = gerarPDF;
            this.calculoAluguel = calculoAluguel;
            this.repositorioConfiguracao = repositorioConfiguracao;
        }

        #region CRUD
        public Result Inserir(Aluguel aluguelParaAdicionar)
        {
            Log.Debug("Tentando inserir o Aluguel '{CLIENTE}'", aluguelParaAdicionar.Cliente.Nome);

            Result resultado = ValidarRegistro(aluguelParaAdicionar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar inserir o Aluguel '{CLIENTE}'", aluguelParaAdicionar.Cliente.Nome);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioAluguel.Inserir(aluguelParaAdicionar);

                if (aluguelParaAdicionar.DataDevolucao.HasValue)
                {
                    aluguelParaAdicionar.Automovel.Alugado = false;
                    aluguelParaAdicionar.Concluido = true;
                }
                else
                    aluguelParaAdicionar.Automovel.Alugado = true;

                byte[] pdfLocacao = gerarPDF.GerarPDF(aluguelParaAdicionar);

                enviarEmail.EnviarEmailAluguel(aluguelParaAdicionar, pdfLocacao);

                _contextoPersistencia.GravarDados();

                Log.Debug("Inserido o Aluguel '{CLIENTE} #{ID}' com sucesso!", aluguelParaAdicionar.Cliente.Nome, aluguelParaAdicionar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar inserir o Aluguel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", aluguelParaAdicionar);

                return Result.Fail(erro);
            }
        }

        public Result Editar(Aluguel aluguelParaEditar)
        {
            Log.Debug("Tentando editar o Aluguel '{CLIENTE} #{ID}'", aluguelParaEditar.Cliente.Nome, aluguelParaEditar.ID);

            Result resultado = ValidarRegistro(aluguelParaEditar);

            if (resultado.IsFailed)
            {
                Log.Warning("Falha ao tentar editar o Aluguel '{CLIENTE} #{ID}'", aluguelParaEditar.Cliente.Nome, aluguelParaEditar.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return resultado;
            }
            try
            {
                _repositorioAluguel.Editar(aluguelParaEditar);

                if (aluguelParaEditar.DataDevolucao.HasValue)
                {
                    aluguelParaEditar.Automovel.Alugado = false;
                    aluguelParaEditar.Concluido = true;
                    byte[] pdfLocacao = gerarPDF.GerarPDFDevolucao(aluguelParaEditar);
                    enviarEmail.EnviarEmailAluguel(aluguelParaEditar, pdfLocacao);
                }
                else
                {
                    aluguelParaEditar.Automovel.Alugado = true;
                    byte[] pdfLocacao = gerarPDF.GerarPDF(aluguelParaEditar);
                    enviarEmail.EnviarEmailAluguel(aluguelParaEditar, pdfLocacao);
                }

                _contextoPersistencia.GravarDados();

                Log.Debug("Editado o Aluguel '{CLIENTE} #{ID}' com sucesso!", aluguelParaEditar.Cliente.Nome, aluguelParaEditar.ID);

                return Result.Ok();
            }
            catch (Exception ex)
            {
                _contextoPersistencia.DesfazerAlteracoes();

                CustomError erro = new("Falha ao tentar editar o Aluguel ", "Automovel", ex.Message);

                Log.Error(ex, erro.ErrorMessage + "{A}", aluguelParaEditar);

                return Result.Fail(erro);
            }
        }

        public Result Excluir(Aluguel aluguelParaExcluir)
        {
            Log.Debug("Tentando excluir o Aluguel '{CLIENTE} #{ID}'", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID);

            if (_repositorioAluguel.Existe(aluguelParaExcluir, true) == false)
            {
                Log.Warning("Aluguel {ID} não encontrado para excluir", aluguelParaExcluir.ID);

                _contextoPersistencia.DesfazerAlteracoes();

                return Result.Fail("Aluguel não encontrado");
            }
            try
            {
                if (_validadorAluguel.ValidarSeAluguelConcluido(aluguelParaExcluir))
                {
                    _repositorioAluguel.Excluir(aluguelParaExcluir);

                    aluguelParaExcluir.Automovel.Alugado = false;

                    _contextoPersistencia.GravarDados();

                    Log.Debug("Excluído o Aluguel '{CLIENTE} #{ID}' com sucesso!", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID);

                    return Result.Ok();
                }
                else
                {
                    _contextoPersistencia.DesfazerAlteracoes();

                    Log.Warning("Falha ao tentar excluir o Aluguel '{CLIENTE} #{ID}'. Aluguel está em aberto", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID);

                    List<IError> erros = new();

                    erros.Add(new CustomError("Esse Aluguel está em aberto. Finalize o Aluguel antes de excluí-lo", "Aluguel"));

                    return Result.Fail(erros);
                }
            }
            catch (DbUpdateException ex) when (ex.InnerException is SqlException sqlException)
            {
                List<IError> erros = AnalisarErros(aluguelParaExcluir, sqlException);

                return Result.Fail(erros);
            }
            catch (InvalidOperationException ex)
            {
                List<IError> erros = AnalisarErros(aluguelParaExcluir, ex);

                return Result.Fail(erros);
            }
        }

        private List<IError> AnalisarErros(Aluguel aluguelParaExcluir, Exception exception)
        {
            List<IError> erros = new();

            _contextoPersistencia.DesfazerAlteracoes();

            Log.Warning("Falha ao tentar excluir o Aluguel '{CLIENTE} #{ID}'", aluguelParaExcluir.Cliente.Nome, aluguelParaExcluir.ID, exception);

            erros.Add(new CustomError("Falha ao tentar excluir o Aluguel", "Aluguel"));

            return erros;
        }
        #endregion

        public Aluguel SelecionarRegistroPorID(Guid aluguelID)
        {
            return _repositorioAluguel.SelecionarPorID(aluguelID);
        }

        public List<Aluguel> SelecionarTodosOsRegistros()
        {
            return _repositorioAluguel.SelecionarTodos();
        }

        public Result ValidarRegistro(Aluguel aluguelParaValidar)
        {
            List<IError> erros = new();

            ValidationResult validacao = _validadorAluguel.Validate(aluguelParaValidar);

            if (validacao != null)
                erros = validacao.ConverterParaListaDeErros();

            if (_repositorioAluguel.Existe(aluguelParaValidar))
                erros.Add(new CustomError("Esse Aluguel já existe", "Aluguel"));

            erros.AddRange(ValidarCupom(aluguelParaValidar));

            return Result.Fail(erros);
        }

        public List<IError> ValidarCupom(Aluguel aluguelParaValidar)
        {
            List<IError> erros = new();

            if (aluguelParaValidar.Cupom != null)
            {
                aluguelParaValidar.Cupom = _repositorioAluguel.ObterCupomCompleto(aluguelParaValidar, servicoCupom.SelecionarTodosOsRegistros());

                if (_validadorAluguel.CupomValido(aluguelParaValidar) == false)
                    erros.Add(new CustomError("Cupom Inválido", "Cupom"));
            }

            return erros;
        }

        public decimal CalcularValorPrevisto(Aluguel aluguelParaCalcular)
        {
            return calculoAluguel.CalcularValorTotalInicial(aluguelParaCalcular);
        }

        public decimal CalcularValorDevolucao(Aluguel aluguelParaCalcular)
        {
            PrecoCombustivel precoCombustivel = repositorioConfiguracao.ObterConfiguracaoPrecos();

            return calculoAluguel.CalcularValorTotalDevolucao(aluguelParaCalcular, precoCombustivel);
        }

        public Result VerificarSeFechado(Aluguel aluguel)
        {
            if (_validadorAluguel.VerificarSeAlugado(aluguel))
            {
                return new CustomError("Esse Aluguel está concluído", "Aluguel");
            }

            return Result.Ok();
        }
    }
}
