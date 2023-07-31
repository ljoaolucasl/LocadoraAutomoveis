using FizzWare.NBuilder;
using FluentAssertions;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using Microsoft.Data.SqlClient;
using Moq;
using System.Reflection;
using System.Runtime.Serialization;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloCategoriaAutomoveis
{
    [TestClass]
    public class ServicoCategoriaAutomoveisTeste
    {
        private Mock<IRepositorioCategoria> _repositorioMoq;
        private Mock<IValidadorCategoria> _validadorMoq;
        private ServicoCategoriaAutomoveis _servico;
        private CategoriaAutomoveis _categoria;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioCategoria>();
            _validadorMoq = new Mock<IValidadorCategoria>();
            _servico = new ServicoCategoriaAutomoveis(_repositorioMoq.Object, _validadorMoq.Object);
            _categoria = new CategoriaAutomoveis("Esportivo");
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_categoria_quando_valida()
        {
            //arrange
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();

            //action
            var resultado = _servico.Inserir(categoria);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(categoria), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_categoria_quando_invalida()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<CategoriaAutomoveis>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Inserir(_categoria);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_categoria), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_categoria_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);

            //action
            var resultado = _servico.Inserir(_categoria);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Categoria já existe");
            _repositorioMoq.Verify(x => x.Inserir(_categoria), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_categoria()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<CategoriaAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Inserir(_categoria);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir categoria ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_categoria_quando_valida()
        {
            //arrange
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();

            //action
            var resultado = _servico.Editar(categoria);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(categoria), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_categoria_quando_invalida()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<CategoriaAutomoveis>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Editar(_categoria);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_categoria), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_categoria_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);

            //action
            var resultado = _servico.Editar(_categoria);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Categoria já existe");
            _repositorioMoq.Verify(x => x.Editar(_categoria), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_categoria()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<CategoriaAutomoveis>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Editar(_categoria);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar categoria ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_categoria_quando_valida()
        {
            //arrange
            var categoria = Builder<CategoriaAutomoveis>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);

            //action
            var resultado = _servico.Excluir(categoria);

            //assert
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(categoria), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_categoria_quando_nao_existente()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(false);

            //action
            var resultado = _servico.Excluir(Builder<CategoriaAutomoveis>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_categoria), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Categoria não encontrada");
        }

        [TestMethod]
        public void Nao_Deve_adicionar_categoria_quando_relacionada_ao_automovel()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBCategoriaAutomoveis_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<CategoriaAutomoveis>())).Throws(exception);

            //action
            var resultado = _servico.Excluir(Builder<CategoriaAutomoveis>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Categoria está relacionada à um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_adicionar_categoria_quando_relacionada_ao_plano_de_cobranca()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBCategoriaAutomoveis_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<CategoriaAutomoveis>())).Throws(exception);

            //action
            var resultado = _servico.Excluir(Builder<CategoriaAutomoveis>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Categoria está relacionada à um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_adicionar_categoria_quando_relacionada_ao_aluguel_em_aberto()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "FK_TBCategoriaAutomoveis_TBOBJETORELACAO");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<CategoriaAutomoveis>())).Throws(exception);

            //action
            var resultado = _servico.Excluir(Builder<CategoriaAutomoveis>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Categoria está relacionada à um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_adicionar_categoria_quando_falha_na_exclusao()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<CategoriaAutomoveis>())).Returns(true);
            var exception = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));
            FieldInfo messageField = typeof(SqlException).GetField("_message", BindingFlags.Instance | BindingFlags.NonPublic)!;

            messageField?.SetValue(exception, "");

            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<CategoriaAutomoveis>())).Throws(exception);

            //action
            var resultado = _servico.Excluir(Builder<CategoriaAutomoveis>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir categoria");
        }
        #endregion
    }
}
