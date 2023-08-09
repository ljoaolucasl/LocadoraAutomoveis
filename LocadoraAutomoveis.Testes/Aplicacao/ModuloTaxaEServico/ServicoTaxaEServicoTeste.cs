using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloTaxaEServico
{
    [TestClass]
    public class ServicoTaxaEServicoTeste
    {
        private Mock<IRepositorioTaxaEServico> _repositorioMoq;
        private Mock<IValidadorTaxaEServico> _validadorMoq;
        private Mock<IContextoPersistencia> _contextoMoq;
        private Mock<IRepositorioAluguel> _repositorioAluguelMoq;
        private ServicoTaxaEServico _servico;
        private TaxaEServico _taxa;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioTaxaEServico>();
            _validadorMoq = new Mock<IValidadorTaxaEServico>();
            _contextoMoq = new Mock<IContextoPersistencia>();
            _repositorioAluguelMoq = new Mock<IRepositorioAluguel>();
            _servico = new ServicoTaxaEServico(_repositorioMoq.Object, _validadorMoq.Object, _repositorioAluguelMoq.Object, _contextoMoq.Object);
            _taxa = new TaxaEServico("Teste", 100, Tipo.Diario);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_taxa_e_servico_quando_valida()
        {
            //arrange
            var taxa = Builder<TaxaEServico>.CreateNew().Build();

            //action
            var resultado = _servico.Inserir(taxa);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(taxa), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_taxa_e_servico_quando_invalida()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<TaxaEServico>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Inserir(_taxa);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_taxa), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_taxa_e_servico_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<TaxaEServico>(), false)).Returns(true);

            //action
            var resultado = _servico.Inserir(_taxa);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Taxa e Serviço já existe");
            _repositorioMoq.Verify(x => x.Inserir(_taxa), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_taxa_e_servico()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<TaxaEServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Inserir(_taxa);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir Taxa e Serviço ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_taxa_e_servico_quando_valida()
        {
            //arrange
            var taxa = Builder<TaxaEServico>.CreateNew().Build();

            //action
            var resultado = _servico.Editar(taxa);

            //assent
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(taxa), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_taxa_e_servico_quando_invalida()
        {
            //arrange
            _validadorMoq.Setup(x => x.Validate(It.IsAny<TaxaEServico>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            //action
            var resultado = _servico.Editar(_taxa);

            //assent
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_taxa), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_taxa_e_servico_quando_ja_existe()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<TaxaEServico>(), false)).Returns(true);

            //action
            var resultado = _servico.Editar(_taxa);

            //assent
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Taxa e Serviço já existe");
            _repositorioMoq.Verify(x => x.Editar(_taxa), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_taxa_e_servico()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<TaxaEServico>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            //action
            Result resultado = _servico.Editar(_taxa);

            //assert 
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar Taxa e Serviço ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_taxa_e_servico_quando_valida()
        {
            //arrange
            var taxa = Builder<TaxaEServico>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<TaxaEServico>(), true)).Returns(true);

            //action
            var resultado = _servico.Excluir(taxa);

            //assert
            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(taxa), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_taxa_e_servico_quando_nao_existente()
        {
            //arrange
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<TaxaEServico>(), false)).Returns(false);

            //action
            var resultado = _servico.Excluir(Builder<TaxaEServico>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_taxa), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Taxa e Serviço não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_taxa_e_servico_quando_relacionada_ao_aluguel()
        {
            //arrange
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBAluguel_TBTaxaEServicos");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<TaxaEServico>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<TaxaEServico>())).Throws(dbUpdateException);

            //action
            var resultado = _servico.Excluir(Builder<TaxaEServico>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Essa Taxa e Serviço está relacionada a um Aluguel." +
                " Primeiro exclua o Aluguel relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_taxa_e_servico_quando_falha_na_exclusao()
        {
            //arrange
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<TaxaEServico>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<TaxaEServico>())).Throws(dbUpdateException);

            //action
            var resultado = _servico.Excluir(Builder<TaxaEServico>.CreateNew().Build());

            //assert
            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir a Taxa e Serviço");
        }
        #endregion
    }
}
