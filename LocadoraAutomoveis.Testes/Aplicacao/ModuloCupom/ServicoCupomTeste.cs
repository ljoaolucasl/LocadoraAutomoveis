using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloCupom
{
    [TestClass]
    public class ServicoCupomTeste
    {
        private Mock<IRepositorioCupom> _repositorioMoq;
        private Mock<IValidadorCupom> _validadorMoq;
        private Mock<IContextoPersistencia> _contexto;
        private ServicoCupom _servico;
        private Cupom _cupom;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioCupom>();
            _validadorMoq = new Mock<IValidadorCupom>();
            _servico = new ServicoCupom(_repositorioMoq.Object, _validadorMoq.Object, _contexto.Object);
            _cupom = new Cupom();
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_cupom_quando_valida()
        {
            var cupom = Builder<Cupom>.CreateNew().Build();

            var resultado = _servico.Inserir(cupom);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_Cupom_quando_invalida()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Cupom>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Inserir(_cupom);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_cupom), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_cupom_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cupom>(), false)).Returns(true);

            var resultado = _servico.Inserir(_cupom);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse cupom já existe");
            _repositorioMoq.Verify(x => x.Inserir(_cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_cupom()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Cupom>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Inserir(_cupom);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir cupom");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_cupom_quando_valida()
        {
            var cupom = Builder<Cupom>.CreateNew().Build();

            var resultado = _servico.Editar(cupom);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_cupom_quando_invalida()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Cupom>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Editar(_cupom);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_cupom), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_cupom_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cupom>(), false)).Returns(true);

            var resultado = _servico.Editar(_cupom);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse cupom já existe");
            _repositorioMoq.Verify(x => x.Editar(_cupom), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_cupom()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Cupom>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Editar(_cupom);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar cupom");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_cupom_quando_valida()
        {
            var cupom = Builder<Cupom>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cupom>(), true)).Returns(true);

            var resultado = _servico.Excluir(cupom);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(cupom), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_cupom_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cupom>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<Cupom>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_cupom), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Cupom não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_cupom_quando_relacionado_ao_aluguel()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBAluguel_TBCupom");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cupom>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Cupom>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Cupom>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Cupom está relacionado a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_cupom_quando_falha_na_exclusao()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Cupom>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Cupom>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Cupom>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir o cupom");
        }
        #endregion
    }
}
