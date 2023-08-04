using LocadoraAutomoveis.Dominio.ModuloCliente;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloCliente
{
    [TestClass]
    public class ClienteTeste
    {
        private ValidadorCliente _validador;
        private Cliente cliente;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorCliente();
            cliente = new("Mateus", "mateuszancheta@gmail.com", "(49) 92323-4423", Tipo.CPF,
                "234.423.563-45", "Santa Catarina", "Lages", "São Cristovão", "Rio de Janeiro", 12);
        }

        [TestMethod]
        public void Deve_validar_cliente()
        {
            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            cliente.Nome = "Ma";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            cliente.Nome = "Joa@";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_nome_vazio()
        {
            cliente.Nome = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_email_vazio()
        {
            cliente.Email = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_email_fora_do_formato_adequado()
        {
            cliente.Email = "mateuszancheta@";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_telefone_vazio()
        {
            cliente.Telefone = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_telefone_fora_do_formato_adequado()
        {
            cliente.Telefone = "490 923-4423";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cpf_e_cnpj_vazio()
        {
            cliente.Documento = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cpf_fora_do_formato_adequado()
        {
            cliente.Documento = "24.423.563-45";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cnpj_fora_do_formato_adequado()
        {
            cliente.Documento = "99.999.999/99-99";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_estado_vazio()
        {
            cliente.Estado = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cidade_vazio()
        {
            cliente.Cidade = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_bairro_vazio()
        {
            cliente.Bairro = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_rua_vazio()
        {
            cliente.Rua = "";

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_numero_vazio_ou_igual_a_zero()
        {
            cliente.Numero = 0;

            ValidationResult resultado = _validador.Validate(cliente);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
