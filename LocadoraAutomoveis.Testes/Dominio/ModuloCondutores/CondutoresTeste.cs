using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloCondutores
{
    [TestClass]
    public class CondutoresTeste
    {
        private ValidadorCondutores _validador;
        private Cliente _cliente1;
        private Cliente _cliente2;
        private List<Condutor> _lista;
        private Condutor _condutor1;
        private Condutor _condutor2;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorCondutores();

            _cliente1 = new Cliente("Mateus", "mateuszancheta@gmail.com", "(49) 92323-4423", TipoDocumento.CPF,
                "234.423.563-45", "Santa Catarina", "Lages", "São Cristovão", "Rio de Janeiro", 12);

            _condutor1 = new Condutor(_cliente1, true, "João", "joao@gmail.com", "(49) 95532-4374", "254.663.565-45",
                "31345676777", DateTime.Now);

            _cliente2 = new Cliente("Mateus", "mateuszancheta@gmail.com", "(49) 92323-4423", TipoDocumento.CNPJ,
                "234.423.563-45", "Santa Catarina", "Lages", "São Cristovão", "Rio de Janeiro", 12);

            _condutor2 = new Condutor(_cliente2, true, "João", "joao@gmail.com", "(49) 95532-4374", "43.434.134/1341-34",
                "31345676777", DateTime.Now);
        }

        [TestMethod]
        public void Deve_validar_condutor()
        {
            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_menos_que_3_caracteres()
        {
            _condutor1.Nome = "Ma";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            _condutor1.Nome = "Joa@";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_nome_vazio()
        {
            _condutor1.Nome = "";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_email_vazio()
        {
            _condutor1.Email = "";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_email_fora_do_formato_adequado()
        {
            _condutor1.Email = "mateuszancheta@";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_telefone_vazio()
        {
            _condutor1.Telefone = "";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_telefone_fora_do_formato_adequado()
        {
            _condutor1.Telefone = "490 923-4423";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cpf_vazio()
        {
            _condutor1.CPF = "";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cpf_fora_do_formato_adequado()
        {
            _condutor1.CPF = "24.423.563-45";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cnh_vazio()
        {
            _condutor1.CNH = "";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_o_campo_cnh_fora_do_formato_adequado()
        {
            _condutor1.CNH = "316777";

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_data_menor_que_a_data_atual()
        {
            _condutor1.Validade = Convert.ToDateTime("01/08/2023");

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_aceitar_cliente_valido()
        {
            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_cliente_nulo()
        {
            _condutor1.Cliente = null;

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Deve_aceitar_cliente_nao_ser_condutor_valido()
        {
            _condutor1.TipoCondutor = false;

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Deve_aceitar_cliente_ser_condutor_valido()
        {
            _condutor1.TipoCondutor = true;

            ValidationResult resultado = _validador.Validate(_condutor1);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_cliente_ser_condutor_caso_seja_empresa()
        {
            _condutor1.Cliente.TipoCliente = TipoDocumento.CNPJ;
            _condutor1.Cliente.Documento = "43.434.134/1341-34";
            _condutor2.TipoCondutor = false;

            ValidationResult resultado = _validador.Validate(_condutor2);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
