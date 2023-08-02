using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloTaxaEServico
{
    [TestClass]
    public class TaxaEServicoTeste
    {
        private ValidadorTaxaEServico _validador;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorTaxaEServico();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            //arrange
            TaxaEServico taxa = new("te", 100, Tipo.CalculoFixo);

            //action
            ValidationResult resultado = _validador.Validate(taxa);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            //arrange
            TaxaEServico taxa = new("teste@", 100, Tipo.CalculoFixo);

            //action
            ValidationResult resultado = _validador.Validate(taxa);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_nome_vazio()
        {
            //arrange
            TaxaEServico taxa = new("", 100, Tipo.CalculoFixo);

            //action
            ValidationResult resultado = _validador.Validate(taxa);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_valor_igual_zero()
        {
            //arrange
            TaxaEServico taxa = new("", 0, Tipo.CalculoFixo);

            //action
            ValidationResult resultado = _validador.Validate(taxa);

            //assert
            resultado.IsValid.Should().BeFalse();
        }
    }
}
