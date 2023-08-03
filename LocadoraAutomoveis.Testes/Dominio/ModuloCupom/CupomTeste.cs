using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloCupom
{
    [TestClass]
    public class CupomTeste
    {
        private ValidadorCupom _validador;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorCupom();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            Cupom cupom = new("12", 12, DateTime.Now, new Parceiro("Teste"));

            ValidationResult resultado = _validador.Validate(cupom);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            Cupom cupom = new("Cupom@", 12, DateTime.Now, new Parceiro("Teste"));

            ValidationResult resultado = _validador.Validate(cupom);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            Cupom cupom = new("", 12, DateTime.Now, new Parceiro("Teste"));

            ValidationResult resultado = _validador.Validate(cupom);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
