using FizzWare.NBuilder;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using Microsoft.Data.SqlClient;
using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using Microsoft.Data.SqlClient;
using Moq;
using System.Reflection;
using System.Runtime.Serialization;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloCliente
{
    [TestClass]
    public class ServicoClienteTeste
    {
        private Mock<IRepositorioCliente> _repositorioMoq;
        private Mock<IValidadorCliente> _validadorMoq;
        private ServicoCliente _servico;
        private Cliente _cliente;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioCliente>();
            _validadorMoq = new Mock<IValidadorCliente>();
            _servico = new ServicoCliente(_repositorioMoq.Object, _validadorMoq.Object);
            _cliente = new Cliente("Rafael", "rafael@gmail.com", "(49) 92332-4324", TipoDocumento.CPF,
                "234.323.563-45", "Santa Catarina", "Lages", "São Cristovão", "Rio de Janeiro", 12);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_cliente_quando_valido()
        {
            var cliente = Builder<Cliente>.CreateNew().Build();

            var resultado = _servico.Inserir(cliente);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_cliente_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Cliente>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Inserir(_cliente);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_cliente), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_cliente_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), false)).Returns(true);

            var resultado = _servico.Inserir(_cliente);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Cliente já existe");
            _repositorioMoq.Verify(x => x.Inserir(_cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_cliente()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Inserir(_cliente);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir Cliente ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_cliente_quando_valido()
        {
            var cliente = Builder<Cliente>.CreateNew().Build();

            var resultado = _servico.Editar(cliente);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_cliente_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Cliente>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Editar(_cliente);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_cliente), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_cliente_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), false)).Returns(true);

            var resultado = _servico.Editar(_cliente);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Cliente já existe");
            _repositorioMoq.Verify(x => x.Editar(_cliente), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_cliente()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Cliente>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Editar(_cliente);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar Cliente ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_cliente_quando_valido()
        {
            var cliente = Builder<Cliente>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), true)).Returns(true);

            var resultado = _servico.Excluir(cliente);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(cliente), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_cliente_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<Cliente>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_cliente), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Cliente não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_cliente_quando_relacionado_ao_aluguel_em_aberto()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), true)).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBCliente_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Cliente>())).Throws(exception);

            var resultado = _servico.Excluir(Builder<Cliente>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Cliente está relacionado à um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_cliente_quando_falha_na_exclusao()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cliente>(), true)).Returns(true);

            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Cliente>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Cliente>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir Cliente");
        }
        #endregion
    }
}
