using FizzWare.NBuilder;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using Microsoft.Data.SqlClient;
using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using Microsoft.Data.SqlClient;
using Moq;
using System.Reflection;
using System.Runtime.Serialization;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloFuncionario
{
    [TestClass]
    public class ServicoFuncionarioTeste
    {
        private Mock<IRepositorioFuncionario> _repositorioMoq;
        private Mock<IValidadorFuncionario> _validadorMoq;
        private ServicoFuncionario _servico;
        private Funcionario _funcionario;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioFuncionario>();
            _validadorMoq = new Mock<IValidadorFuncionario>();
            _servico = new ServicoFuncionario(_repositorioMoq.Object, _validadorMoq.Object);
            _funcionario = new Funcionario("Mateus", Convert.ToDateTime("08/08/2023"), 1350);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_funcionario_quando_valido()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Build();

            //action
            var resultado = _servico.Inserir(funcionario);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_funcionario_quando_invalido()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Inserir(_funcionario);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_funcionario_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), false)).Returns(true);

            //action
            var resultado = _servico.Inserir(_funcionario);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Funcionário já existe");
            _repositorioMoq.Verify(x => x.Inserir(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_funcionario()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Inserir(_funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir Funcionário ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_funcionario_quando_valido()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Build();

            //action
            var resultado = _servico.Editar(funcionario);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_funcionario_quando_invalido()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Editar(_funcionario);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_funcionario_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), false)).Returns(true);

            //action
            var resultado = _servico.Editar(_funcionario);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Funcionário já existe");
            _repositorioMoq.Verify(x => x.Editar(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_funcionario()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Editar(_funcionario);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar Funcionário ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_funcionario_quando_valido()
        {
            //arrange
            var funcionario = Builder<Funcionario>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), true)).Returns(true);

            //action
            var resultado = _servico.Excluir(funcionario);

            //assert
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_funcionario_quando_nao_existente()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), false)).Returns(false);

            //action
            var resultado = _servico.Excluir(Builder<Funcionario>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_funcionario), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Funcionário não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_funcionario_quando_relacionado_ao_aluguel_em_aberto()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), true)).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBFuncionario_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Funcionario>())).Throws(exception);

            //action
            var resultado = _servico.Excluir(Builder<Funcionario>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Funcionário está relacionado à um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_funcionario_quando_falha_na_exclusao()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), true)).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Funcionario>())).Throws(exception);

            //action
            var resultado = _servico.Excluir(Builder<Funcionario>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir Funcionário");
        }
        #endregion
    }
}
