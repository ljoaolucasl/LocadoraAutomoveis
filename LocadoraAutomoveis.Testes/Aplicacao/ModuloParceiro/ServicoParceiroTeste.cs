using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using Microsoft.Data.SqlClient;
using Moq;
using System.Reflection;
using System.Runtime.Serialization;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloParceiro
{
    [TestClass]
    public class ServicoParceiroTeste
    {
        private Mock<IRepositorioParceiro> _repositorioMoq;
        private Mock<IValidadorParceiro> _validadorMoq;
        private ServicoParceiro _servico;
        private Parceiro _parceiro;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioParceiro>();
            _validadorMoq = new Mock<IValidadorParceiro>();
            _servico = new ServicoParceiro(_repositorioMoq.Object, _validadorMoq.Object);
            _parceiro = new Parceiro("Academia do Programador");
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_parceiro_quando_valida()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Build();

            var resultado = _servico.Inserir(parceiro);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_parceiro_quando_invalida()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Parceiro>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Inserir(_parceiro);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_parceiro), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_parceiro_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), false)).Returns(true);

            var resultado = _servico.Inserir(_parceiro);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse parceiro já existe");
            _repositorioMoq.Verify(x => x.Inserir(_parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_parceiro()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Inserir(_parceiro);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir parceiro");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_parceiro_quando_valida()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Build();

            var resultado = _servico.Editar(parceiro);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_parceiro_quando_invalida()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Parceiro>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Editar(_parceiro);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_parceiro), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_parceiro_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), false)).Returns(true);

            var resultado = _servico.Editar(_parceiro);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse parceiro já existe");
            _repositorioMoq.Verify(x => x.Editar(_parceiro), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_parceiro()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Parceiro>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Editar(_parceiro);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar parceiro");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_parceiro_quando_valida()
        {
            var parceiro = Builder<Parceiro>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), true)).Returns(true);

            var resultado = _servico.Excluir(parceiro);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(parceiro), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_parceiro_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<Parceiro>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_parceiro), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Parceiro não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_parceiro_quando_relacionado_ao_cupom()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), true)).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBParceiro_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Parceiro>())).Throws(exception);

            var resultado = _servico.Excluir(Builder<Parceiro>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Parceiro está relacionada a um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_parceiro_quando_relacionada_ao_aluguel_em_aberto()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), true)).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBParceiro_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Parceiro>())).Throws(exception);

            var resultado = _servico.Excluir(Builder<Parceiro>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Parceiro está relacionada a um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_parceiro_quando_falha_na_exclusao()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Parceiro>(), true)).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Parceiro>())).Throws(exception);

            var resultado = _servico.Excluir(Builder<Parceiro>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir parceiro");
        }
        #endregion
    }
}
