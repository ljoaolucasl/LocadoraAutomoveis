using FizzWare.NBuilder;
using FluentResults;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using Microsoft.Data.SqlClient;
using FizzWare.NBuilder;
using FluentResults;
using FluentResults.Extensions.FluentAssertions;
using LocadoraAutomoveis.Aplicacao.Compartilhado;
using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using Microsoft.Data.SqlClient;
using Moq;
using System.Reflection;
using System.Runtime.Serialization;
using LocadoraAutomoveis.Testes.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Testes.Aplicacao.ModuloFuncionario
{
    [TestClass]
    public class ServicoFuncionarioTeste
    {
        private Mock<IRepositorioFuncionario> _repositorioMoq;
        private Mock<IValidadorFuncionario> _validadorMoq;
        private ServicoFuncionario _servico;
        private Funcionario _funcionario;

        [TestInitialize]
        public void Setup()
        {
            _repositorioMoq = new Mock<IRepositorioFuncionario>();
            _validadorMoq = new Mock<IValidadorFuncionario>();
            _servico = new ServicoFuncionario(_repositorioMoq.Object, _validadorMoq.Object);
            _funcionario = new Funcionario("Mateus", Convert.ToDateTime("08/08/2023"), 1350);
        }

        #region Testes Inserir
        [TestMethod]
        public void Deve_inserir_funcionario_quando_valido()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Build();

            var resultado = _servico.Inserir(funcionario);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Inserir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_inserir_funcionario_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Inserir(_funcionario);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Inserir(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_inserir_funcionario_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), false)).Returns(true);

            var resultado = _servico.Inserir(_funcionario);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Funcionário já existe");
            _repositorioMoq.Verify(x => x.Inserir(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_inserir_funcionario()
        {
            _repositorioMoq.Setup(x => x.Inserir(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Inserir(_funcionario);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar inserir Funcionário ");
        }
        #endregion

        #region Testes Editar
        [TestMethod]
        public void Deve_editar_funcionario_quando_valido()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Build();

            var resultado = _servico.Editar(funcionario);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Editar(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_editar_funcionario_quando_invalido()
        {
            _validadorMoq.Setup(x => x.Validate(It.IsAny<Funcionario>())).Returns(() =>
            {
                var resultado = new ValidationResult();
                resultado.Errors.Add(new ValidationFailure("erro", "erro"));
                return resultado;
            });

            var resultado = _servico.Editar(_funcionario);

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Editar(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Nao_Deve_editar_funcionario_quando_ja_existe()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), false)).Returns(true);

            var resultado = _servico.Editar(_funcionario);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Funcionário já existe");
            _repositorioMoq.Verify(x => x.Editar(_funcionario), Times.Never());
        }

        [TestMethod]
        public void Deve_tratar_erro_quando_falha_ao_tentar_editar_funcionario()
        {
            _repositorioMoq.Setup(x => x.Editar(It.IsAny<Funcionario>()))
                .Throws(() =>
                {
                    return new Exception();
                });

            Result resultado = _servico.Editar(_funcionario);

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar editar Funcionário ");
        }
        #endregion

        #region Testes Excluir
        [TestMethod]
        public void Deve_excluir_funcionario_quando_valido()
        {
            var funcionario = Builder<Funcionario>.CreateNew().Build();
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), true)).Returns(true);

            var resultado = _servico.Excluir(funcionario);

            resultado.Should().BeSuccess();
            _repositorioMoq.Verify(x => x.Excluir(funcionario), Times.Once());
        }

        [TestMethod]
        public void Nao_Deve_excluir_funcionario_quando_nao_existente()
        {
            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), false)).Returns(false);

            var resultado = _servico.Excluir(Builder<Funcionario>.CreateNew().Build());

            resultado.Should().BeFailure();
            _repositorioMoq.Verify(x => x.Excluir(_funcionario), Times.Never());
            resultado.Reasons[0].Message.Should().Be("Funcionário não encontrado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_funcionario_quando_relacionado_ao_aluguel()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("FK_TBAluguel_TBFuncionario");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Funcionario>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Funcionario>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Esse Funcionário está relacionado a um Aluguel." +
                        " Primeiro exclua o Aluguel relacionado");
        }

        [TestMethod]
        public void Nao_Deve_excluir_funcionario_quando_falha_na_exclusao()
        {
            DbUpdateException dbUpdateException = TesteBase.CriarDbUpdateException("");

            _repositorioMoq.Setup(x => x.Existe(It.IsAny<Funcionario>(), true)).Returns(true);
            _repositorioMoq.Setup(x => x.Excluir(It.IsAny<Funcionario>())).Throws(dbUpdateException);

            var resultado = _servico.Excluir(Builder<Funcionario>.CreateNew().Build());

            resultado.Should().BeFailure();
            resultado.Errors.OfType<CustomError>().FirstOrDefault().ErrorMessage.Should().Be("Falha ao tentar excluir Funcionário");
        }
        #endregion
    }
}
