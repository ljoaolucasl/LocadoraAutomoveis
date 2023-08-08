using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

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

        public ServicoAluguel(IRepositorioAluguel repositorioAluguel, IValidadorAluguel validadorAluguel,
            IContextoPersistencia contextoPersistencia, IServicoFuncionario servicoFuncionario,
            IServicoCliente servicoCliente, IServicoCategoriaAutomoveis servicoCategoriaAutomoveis,
            IServicoPlanoCobranca servicoPlanosCobrancas, IServicoCondutor servicoCondutores,
            IServicoAutomovel servicoAutomovel, IServicoCupom servicoCupom, IServicoTaxaEServico servicoTaxaEServico)
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

            if (aluguelParaValidar.Cupom != null && _repositorioAluguel.CupomNaoExiste(aluguelParaValidar, servicoCupom.SelecionarTodosOsRegistros()))
                erros.Add(new CustomError("Cupom Inválido", "Aluguel"));
            else if (aluguelParaValidar.Cupom != null)
                aluguelParaValidar.Cupom = ObterCupomCompleto(aluguelParaValidar);

            return Result.Fail(erros);
        }

        public Cupom? ObterCupomCompleto(Aluguel aluguelParaObterCupom)
        {
            return servicoCupom.SelecionarTodosOsRegistros().FirstOrDefault(c => c.Nome == aluguelParaObterCupom.Cupom.Nome);
        }
    }
}
