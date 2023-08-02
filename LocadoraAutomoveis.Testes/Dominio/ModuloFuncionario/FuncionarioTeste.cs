using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTeste
    {
        private RepositorioFuncionario _repositorioFuncionarios;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioFuncionarios = new RepositorioFuncionario(_contexto);

            _contexto.RemoveRange(_repositorioFuncionarios.Registros);
        }

        [TestMethod]
        public void Deve_ter_no_minimo_3_caracteres()
        {
            Funcionario funcionario = new("Ca", DateTime.Parse("23/09/2023"), 1200);

            ValidationResult resultado = new ValidadorFuncionario().Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            Funcionario funcionario = new("Caminhonete@", DateTime.Parse("23/09/2023"), 1200);

            ValidationResult resultado = new ValidadorFuncionario().Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            Funcionario funcionario = new("", DateTime.Parse("23/09/2023"), 1900);

            ValidationResult resultado = new ValidadorFuncionario().Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_funcionario_repetida()
        {
            Funcionario funcionario1 = new("Carlos", DateTime.Parse("23/09/2023"), 1100);
            Funcionario funcionario2 = new("Carlos", DateTime.Parse("21/09/2023"), 1400);

            _repositorioFuncionarios.Inserir(funcionario1);

            bool resultado = new ValidadorFuncionario().ValidarFuncionarioExistente(funcionario2, _repositorioFuncionarios.SelecionarTodos());

            resultado.Should().BeTrue();
        }
    }
}
