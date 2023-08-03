using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

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
            Funcionario funcionario = new("Ma", Convert.ToDateTime("04/08/2023"), 1200);

            ValidationResult resultado = _validador.Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            Funcionario funcionario = new("Felipe@", Convert.ToDateTime("03/08/2023"), 1100);

            ValidationResult resultado = _validador.Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_nome_vazio()
        {
            Funcionario funcionario = new("", Convert.ToDateTime("04/08/2023"), 1200);

            ValidationResult resultado = _validador.Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_data_menor_que_a_data_atual()
        {
            Funcionario funcionario = new("João", Convert.ToDateTime("01/08/2023"), 1200);

            ValidationResult resultado = _validador.Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_salario_vazio_ou_igual_a_zero()
        {
            Funcionario funcionario = new("Rafael", Convert.ToDateTime("04/08/2023"), 0);

            ValidationResult resultado = _validador.Validate(funcionario);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
