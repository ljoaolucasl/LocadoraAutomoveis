using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloPlanosCobrancas
{
    [TestClass]
    public class ServicoPlanosCobrancasTeste
    {
        private Mock<IRepositorioPlanoCobranca> _repositorioMoq;
        private Mock<IValidadorPlanoCobranca> _validadorMoq;
        private Mock<IContextoPersistencia> _contexto;
        private ServicoPlanosCobrancas _servico;

        private PlanoCobranca _planoCobranca;
        private CategoriaAutomoveis _categoria;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioPlanoCobranca>();
            _validadorMoq = new Mock<IValidadorPlanoCobranca>();
            _servico = new ServicoPlanosCobrancas(_repositorioMoq.Object, _validadorMoq.Object, _contexto.Object);

            _categoria = new CategoriaAutomoveis("Esportivo");
            _planoCobranca = new(100, 100, 100, 100, 100, 100, _categoria);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_planoCobranca_quando_valida()
        {
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();

            var resultado = _servico.Inserir(planoCobranca);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(planoCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_planoCobranca_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Inserir(_planoCobranca);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_planoCobranca_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>(), false)).Returns(true);

            var resultado = _servico.Inserir(_planoCobranca);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse plano de cobrança já existe");
            _repositorioMoq.Verify(x => x.Inserir(_planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_planoCobranca()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Inserir(_planoCobranca);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir Plano de Cobrança");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_planoCobranca_quando_valido()
        {
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();

            var resultado = _servico.Editar(planoCobranca);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(planoCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_planoCobranca_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<PlanoCobranca>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Editar(_planoCobranca);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_planoCobranca_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>(), false)).Returns(true);

            var resultado = _servico.Editar(_planoCobranca);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse plano de cobrança já existe");
            _repositorioMoq.Verify(x => x.Editar(_planoCobranca), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_planoCobranca()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<PlanoCobranca>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Editar(_planoCobranca);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar plano de cobrança");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_planoCobranca_quando_valida()
        {
            var planoCobranca = Builder<PlanoCobranca>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>(), true)).Returns(true);

            var resultado = _servico.Excluir(planoCobranca);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(planoCobranca), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_planoCobranca_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<PlanoCobranca>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_planoCobranca), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Plano de Cobrança não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_planoCobranca_quando_relacionado_ao_aluguel()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBAluguel_TBPlanoCobranca");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<PlanoCobranca>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<PlanoCobranca>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Plano de Cobrança está relacionado a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_planoCobranca_quando_falha_na_exclusao()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<PlanoCobranca>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<PlanoCobranca>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<PlanoCobranca>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir o plano de cobrança");
        }
        #endregion
    }
}
