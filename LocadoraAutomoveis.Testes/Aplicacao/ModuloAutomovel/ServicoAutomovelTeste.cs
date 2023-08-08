using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloAutomovel
{
    [TestClass]
    public class ServicoAutomovelTeste
    {
        private Mock<IRepositorioAutomovel> _repositorioMoq;
        private Mock<IValidadorAutomovel> _validadorMoq;
        private Mock<IContextoPersistencia> _contexto;
        private ServicoAutomovel _servico;

        private Automovel _automovel;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioAutomovel>();
            _validadorMoq = new Mock<IValidadorAutomovel>();
            _servico = new ServicoAutomovel(_repositorioMoq.Object, _validadorMoq.Object, _contexto.Object);

            CategoriaAutomoveis categoria = new CategoriaAutomoveis("Esportivo");
            _automovel = new Automovel(categoria, "REW-4512", "Honda","Azul", "Super", new byte[12], TipoCombustível.Gasolina, 20, 2022, 245, false);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_automovel_quando_valida()
        {
            //arrange
            var automovel = Builder<Automovel>.CreateNew().Build();

            //action
            var resultado = _servico.Inserir(automovel);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_automovel_quando_invalido()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Automovel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Inserir(_automovel);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_automovel), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_automovel_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Automovel>(), false)).Returns(true);

            //action
            var resultado = _servico.Inserir(_automovel);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Automóvel já existe");
            _repositorioMoq.Verify(x => x.Inserir(_automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_automovel()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Inserir(_automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir o Automóvel ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_automovel_quando_valida()
        {
            //arrange
            var automovel = Builder<Automovel>.CreateNew().Build();

            //action
            var resultado = _servico.Editar(automovel);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_automovel_quando_invalida()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Automovel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Editar(_automovel);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_automovel), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_automovel_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Automovel>(), false)).Returns(true);

            //action
            var resultado = _servico.Editar(_automovel);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Automóvel já existe");
            _repositorioMoq.Verify(x => x.Editar(_automovel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_automovel()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Automovel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Editar(_automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar o Automóvel ");
        }

        [TestMethod]
        public void Deve_verificar_a_disponibilidade_do_automovel()
        {
            //arrange
            _validadorMoq.Setup(x => x.VerificarSeAlugado(It.IsAny<Automovel>())).Returns(true);

            //action
            Result resultado = _servico.VerificarDisponibilidade(_automovel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Automóvel está relacionado a um Aluguel em Aberto." +
                        " Primeiro conclua o Aluguel relacionado");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_automovel_quando_valida()
        {
            //arrange
            var automovel = Builder<Automovel>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Automovel>(), true)).Returns(true);

            //action
            var resultado = _servico.Excluir(automovel);

            //assert
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(automovel), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_automovel_quando_nao_existente()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Automovel>(), false)).Returns(false);

            //action
            var resultado = _servico.Excluir(Builder<Automovel>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_automovel), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Automóvel não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_automovel_quando_relacionado_ao_aluguel()
        {
            //arrange
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBAluguel_TBAutomovel");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Automovel>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Automovel>())).Throws(dbUpdateException);

            //action
            var resultado = _servico.Excluir(Builder<Automovel>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Automóvel está relacionado a um Aluguel. Primeiro exclua o Aluguel relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_automovel_quando_falha_na_exclusao()
        {
            //arrange
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Automovel>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Automovel>())).Throws(dbUpdateException);

            //action
            var resultado = _servico.Excluir(Builder<Automovel>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir o Automóvel");
        }
        #endregion
    }
}
