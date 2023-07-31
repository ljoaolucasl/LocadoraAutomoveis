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
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            //arrange
            CategoriaAutomoveis categoria = new("Ca");

            //action
            ValidationResult resultado = new ValidadorCategoriaAutomoveis().Validate(categoria);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            //arrange
            CategoriaAutomoveis categoria = new("Caminhonete@");

            //action
            ValidationResult resultado = new ValidadorCategoriaAutomoveis().Validate(categoria);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            //arrange
            CategoriaAutomoveis categoria = new("");

            //action
            ValidationResult resultado = new ValidadorCategoriaAutomoveis().Validate(categoria);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_categoria_repetida()
        {
            //arrange
            CategoriaAutomoveis categoria1 = new("Caminhonete");
            CategoriaAutomoveis categoria2 = new("Caminhonete");
            _repositorioCategoriaAutomoveis.Inserir(categoria1);

            //action
            bool resultado = new ValidadorCategoriaAutomoveis().ValidarCategoriaExistente(categoria2, _repositorioCategoriaAutomoveis.SelecionarTodos());

            //assert
            resultado.Should().BeTrue();
        }
    }
}
