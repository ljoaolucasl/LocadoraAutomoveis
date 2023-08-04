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

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloCondutores
{
    [TestClass]
    public class ServicoCondutoresTeste
    {
        private Mock<IRepositorioCondutores> _repositorioMoq;
        private Mock<IValidadorCondutores> _validadorMoq;
        private ServicoCondutores _servico;

        private Condutores _condutor;
        private Cliente _cliente1;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioCondutores>();
            _validadorMoq = new Mock<IValidadorCondutores>();
            _servico = new ServicoCondutores(_repositorioMoq.Object, _validadorMoq.Object);

            _cliente1 = new Cliente("Rafael", "rafael@gmail.com", "(49) 92332-4324", TipoDocumento.CPF,
                "234.323.563-45", "Santa Catarina", "Lages", "São Cristovão", "Rio de Janeiro", 12);

            _condutor = new Condutores(_cliente1, true, "João", "joao@gmail.com", "(49) 95532-4374", "254.663.565-45",
                "3134567677782", DateTime.Now);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_condutor_quando_valida()
        {
            var condutor = Builder<Condutores>.CreateNew().Build();

            var resultado = _servico.Inserir(condutor);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_condutor_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Condutores>())).Returns(() =>
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
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutores>(), false)).Returns(true);

            var resultado = _servico.Inserir(_condutor);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Condutor já existe");
            _repositorioMoq.Verify(x => x.Inserir(_condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_condutor()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Condutores>()))
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
            var condutor = Builder<Condutores>.CreateNew().Build();

            var resultado = _servico.Editar(condutor);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_condutor_quando_invalida()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Condutores>())).Returns(() =>
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
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutores>(), false)).Returns(true);

            var resultado = _servico.Editar(_condutor);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Condutor já existe");
            _repositorioMoq.Verify(x => x.Editar(_condutor), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_condutor()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Condutores>()))
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
            var condutor = Builder<Condutores>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutores>(), true)).Returns(true);

            var resultado = _servico.Excluir(condutor);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(condutor), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_condutor_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutores>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<Condutores>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_condutor), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Condutor não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_condutor_quando_relacionado_ao_aluguel_em_aberto()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBOBJETORELACAO_TBCondutor");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutores>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Condutores>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Condutores>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Condutor está relacionada à um ObjetoRelacao." +
                " Primeiro exclua o ObjetoRelacao relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_condutor_quando_falha_na_exclusao()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Condutores>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Condutores>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Condutores>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir o Condutor");
        }
        #endregion
    }
}
