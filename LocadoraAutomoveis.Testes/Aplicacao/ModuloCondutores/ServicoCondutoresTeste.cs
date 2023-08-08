using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloCondutores
{
    [TestClass]
    public class ServicoCondutoresTeste
    {
        private Mock<IRepositorioCondutores> _repositorioMoq;
        private Mock<IValidadorCondutores> _validadorMoq;
        private Mock<IContextoPersistencia> _contexto;
        private ServicoCondutores _servico;

        private Condutor _condutor;
        private Cliente _cliente1;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioCondutores>();
            _validadorMoq = new Mock<IValidadorCondutores>();
            _contexto = new Mock<IContextoPersistencia>();
            _servico = new ServicoCondutores(_repositorioMoq.Object, _validadorMoq.Object, _contexto.Object);

            _cliente1 = new Cliente("Rafael", "rafael@gmail.com", "(49) 92332-4324", TipoDocumento.CPF,
                "234.323.563-45", "Santa Catarina", "Lages", "São Cristovão", "Rio de Janeiro", 12);

            _condutor = new Condutor(_cliente1, true, "João", "joao@gmail.com", "(49) 95532-4374", "254.663.565-45",
                "3134567677782", DateTime.Now);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_condutor_quando_valida()
        {
            var condutor = Builder<Condutor>.CreateNew().Build();

            var resultado = _servico.Inserir(condutor);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_condutor_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Condutor>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Inserir(_condutor);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_condutor), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_condutor_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutor>(), false)).Returns(true);

            var resultado = _servico.Inserir(_condutor);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Condutor já existe");
            _repositorioMoq.Verify(x => x.Inserir(_condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_condutor()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Inserir(_condutor);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir o Condutor ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_condutor_quando_valida()
        {
            var condutor = Builder<Condutor>.CreateNew().Build();

            var resultado = _servico.Editar(condutor);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_condutor_quando_invalida()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Condutor>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Editar(_condutor);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_condutor), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_condutor_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutor>(), false)).Returns(true);

            var resultado = _servico.Editar(_condutor);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Condutor já existe");
            _repositorioMoq.Verify(x => x.Editar(_condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_condutor()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Condutor>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Editar(_condutor);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar o Condutor ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_condutor_quando_valida()
        {
            var condutor = Builder<Condutor>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutor>(), true)).Returns(true);

            var resultado = _servico.Excluir(condutor);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_condutor_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutor>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<Condutor>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_condutor), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Condutor não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_condutor_quando_relacionado_ao_aluguel()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBAluguel_TBCondutor");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutor>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Condutor>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Condutor>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Condutor está relacionado a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_condutor_quando_falha_na_exclusao()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutor>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Condutor>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Condutor>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir o Condutor");
        }
        #endregion
    }
}
