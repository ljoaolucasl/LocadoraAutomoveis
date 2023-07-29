using FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloCategoriaAutomoveis
{
    [TestClass]
    public class CategoriaAutomoveisTeste
    {
        private RepositorioCategoriaAutomoveis _repositorioCategoriaAutomoveis;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioCategoriaAutomoveis = new RepositorioCategoriaAutomoveis(_contexto);

            _contexto.RemoveRange(_repositorioCategoriaAutomoveis.Registros);
        }

        [TestMethod]
        public void Deve_ter_no_minimo_3_caracteres()
        {
            CategoriaAutomoveis categoria = new("Ca");

            ValidationResult resultado = new ValidadorCategoriaAutomoveis().Validate(categoria);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            CategoriaAutomoveis categoria = new("Caminhonete@");

            ValidationResult resultado = new ValidadorCategoriaAutomoveis().Validate(categoria);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            CategoriaAutomoveis categoria = new("");

            ValidationResult resultado = new ValidadorCategoriaAutomoveis().Validate(categoria);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_categoria_repetida()
        {
            CategoriaAutomoveis categoria1 = new("Caminhonete");
            CategoriaAutomoveis categoria2 = new("Caminhonete");

            _repositorioCategoriaAutomoveis.Adicionar(categoria1);

            bool resultado = new ValidadorCategoriaAutomoveis().ValidarCategoriaExistente(categoria2, _repositorioCategoriaAutomoveis.SelecionarTodos());

            resultado.Should().BeTrue();
        }
    }
}
