using LocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloFuncionario
{
    [TestClass]
    public class FuncionarioTeste
    {
        private ValidadorFuncionario _validador;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorFuncionario();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            //arrange
            Funcionario funcionario = new("Ma", Convert.ToDateTime("04/08/2023"), 1200);

            //action
            ValidationResult resultado = _validador.Validate(funcionario);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            //arrange
            Funcionario funcionario = new("Felipe@", Convert.ToDateTime("03/08/2023"), 1100);

            //action
            ValidationResult resultado = _validador.Validate(funcionario);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_nome_vazio()
        {
            //arrange
            Funcionario funcionario = new("", Convert.ToDateTime("04/08/2023"), 1200);

            //action
            ValidationResult resultado = _validador.Validate(funcionario);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_data_menor_que_a_data_atual()
        {
            //arrange
            Funcionario funcionario = new("João", Convert.ToDateTime("01/08/2023"), 1200);

            //action
            ValidationResult resultado = _validador.Validate(funcionario);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_salario_vazio_ou_igual_a_zero()
        {
            //arrange
            Funcionario funcionario = new("Rafael", Convert.ToDateTime("04/08/2023"), 0);

            //action
            ValidationResult resultado = _validador.Validate(funcionario);

            //assert
            resultado.IsValid.Should().BeFalse();
        }
    }
}
