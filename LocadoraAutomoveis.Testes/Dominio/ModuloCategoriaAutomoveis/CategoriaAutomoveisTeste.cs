using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloCategoriaAutomoveis
{
    [TestClass]
    public class CategoriaAutomoveisTeste
    {
        private ValidadorCategoriaAutomoveis _validador;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorCategoriaAutomoveis();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            //arrange
            CategoriaAutomoveis categoria = new("Ca");

            //action
            ValidationResult resultado = _validador.Validate(categoria);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            //arrange
            CategoriaAutomoveis categoria = new("Caminhonete@");

            //action
            ValidationResult resultado = _validador.Validate(categoria);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            //arrange
            CategoriaAutomoveis categoria = new("");

            //action
            ValidationResult resultado = _validador.Validate(categoria);

            //assert
            resultado.IsValid.Should().BeFalse();
        }
    }
}
