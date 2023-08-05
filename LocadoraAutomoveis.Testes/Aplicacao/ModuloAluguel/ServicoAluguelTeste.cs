using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloAluguel
{
    [TestClass]
    public class ServicoAluguelTeste
    {
        private Mock<IRepositorioAluguel> _repositorioMoq;
        private Mock<IValidadorAluguel> _validadorMoq;
        private ServicoAluguel _servico;

        private Aluguel _aluguel;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioAluguel>();
            _validadorMoq = new Mock<IValidadorAluguel>();
            _servico = new ServicoAluguel(_repositorioMoq.Object, _validadorMoq.Object);

            Funcionario funcionario = new();
            Cliente cliente = new();
            CategoriaAutomoveis categoria = new();
            PlanoCobranca plano = new();
            Condutores condutor = new();
            Automovel automovel = new();
            Cupom cupom = new();
            List<TaxaEServico> listTaxa = new();
            DateTime dataLocacao = DateTime.Now;
            DateTime dataPrevista = dataLocacao.AddDays(1);
            DateTime dataDevolucao = dataLocacao.AddDays(2);
            decimal quilometrosRodados = 100;
            NivelTanque nivelTanque = NivelTanque.MeioTanque;
            decimal valorTotal = 1000;

            _aluguel = new Aluguel(funcionario, cliente, categoria, plano, condutor, automovel, cupom, listTaxa, dataLocacao, dataPrevista, dataDevolucao, quilometrosRodados, nivelTanque, valorTotal, true);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_Aluguel_quando_valida()
        {
            //arrange
            var aluguel = Builder<Aluguel>.CreateNew().Build();

            //action
            var resultado = _servico.Inserir(aluguel);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(aluguel), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_Aluguel_quando_invalido()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Aluguel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Inserir(_aluguel);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_aluguel), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_Aluguel_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Aluguel>(), false)).Returns(true);

            //action
            var resultado = _servico.Inserir(_aluguel);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Aluguel já existe");
            _repositorioMoq.Verify(x => x.Inserir(_aluguel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_Aluguel()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Aluguel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Inserir(_aluguel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir o Aluguel ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_Aluguel_quando_valido()
        {
            //arrange
            var Aluguel = Builder<Aluguel>.CreateNew().Build();

            //action
            var resultado = _servico.Editar(Aluguel);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(Aluguel), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_Aluguel_quando_invalido()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Aluguel>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Editar(_aluguel);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_aluguel), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_Aluguel_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Aluguel>(), false)).Returns(true);

            //action
            var resultado = _servico.Editar(_aluguel);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Aluguel já existe");
            _repositorioMoq.Verify(x => x.Editar(_aluguel), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_Aluguel()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Aluguel>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Editar(_aluguel);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar o Aluguel ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_Aluguel_quando_valido()
        {
            //arrange
            var Aluguel = Builder<Aluguel>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Aluguel>(), true)).Returns(true);
            _validadorMoq.Setup(x => x.ValidarSeAluguelConcluido(It.IsAny<Aluguel>())).Returns(true);

            //action
            var resultado = _servico.Excluir(Aluguel);

            //assert
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(Aluguel), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_Aluguel_quando_nao_existente()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Aluguel>(), false)).Returns(false);

            //action
            var resultado = _servico.Excluir(Builder<Aluguel>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_aluguel), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Aluguel não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_Aluguel_ainda_nao_concluido()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Aluguel>(), true)).Returns(true);
            _validadorMoq.Setup(x => x.ValidarSeAluguelConcluido(It.IsAny<Aluguel>())).Returns(false);

            //action
            var resultado = _servico.Excluir(Builder<Aluguel>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Aluguel está em aberto. Finalize o Aluguel antes de excluí-lo");
        }

        [TestMethod]
        public void Nao_Deve_excluir_Aluguel_quando_falha_na_exclusao()
        {
            //arrange
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Aluguel>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Aluguel>())).Throws(dbUpdateException);

            //action
            var resultado = _servico.Excluir(Builder<Aluguel>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir o Aluguel");
        }
        #endregion
    }
}
