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

        [TestMethod]
        public void Nao_deve_aceitar_valor_menor_ou_igual_a_zero()
        {
            Cupom cupom1 = new("Cupom", 0, DateTime.Now, new Parceiro("Teste"));
            Cupom cupom2 = new("Cupom", -1, DateTime.Now, new Parceiro("Teste"));

            ValidationResult resultado1 = _validador.Validate(cupom1);
            ValidationResult resultado2 = _validador.Validate(cupom2);

            resultado1.IsValid.Should().BeFalse();
            resultado2.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_data_passada()
        {
            Cupom cupom = new("Cupom", 1, new DateTime(13/11/1999), new Parceiro("Teste"));

            ValidationResult resultado = _validador.Validate(cupom);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_parceiro_nulo()
        {
            Cupom cupom = new("Cupom", 1, DateTime.Now, null);

            ValidationResult resultado = _validador.Validate(cupom);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
