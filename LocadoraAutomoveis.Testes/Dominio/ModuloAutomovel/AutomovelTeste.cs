using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloAutomovel
{
    [TestClass]
    public class AutomovelTeste
    {
        private ValidadorAutomovel _validador;
        private CategoriaAutomoveis _categoria;
        private Automovel _automovel;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorAutomovel();

            _categoria = new CategoriaAutomoveis("Esportivo");
            _automovel = new Automovel(_categoria, "REW-4512", "Honda", "Azul", "Super", new byte[12], TipoCombustível.Eletrico, 20, 2022, 245);
        }

        [TestMethod]
        public void Deve_aceitar_Categoria_valida()
        {
            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Categoria_nula()
        {
            //arrange
            _automovel.Categoria = null;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Placa_vazia()
        {
            //arrange
            _automovel.Placa = "";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Placa_com_formato_invalido()
        {
            //arrange
            _automovel.Placa = "47e-2eaw";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Placa_sem_ter_8_caracteres()
        {
            //arrange
            _automovel.Placa = "ERTE-0000";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Marca_vazia()
        {
            //arrange
            _automovel.Marca = "";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Cor_com_caractere_invalido()
        {
            //arrange
            _automovel.Cor = "azul@#";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Cor_vazia()
        {
            //arrange
            _automovel.Cor = "";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Modelo_vazio()
        {
            //arrange
            _automovel.Modelo = "";

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Imagem_nula()
        {
            //arrange
            _automovel.Imagem = null;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Imagem_maior_que_2mb()
        {
            //arrange
            int tamanhoBytes = 2 * 1024 * 1024 + 1;
            byte[] tamanho = new byte[tamanhoBytes];
            new Random().NextBytes(tamanho);

            _automovel.Imagem = tamanho;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_TipoCombustivel_invalido()
        {
            //arrange
            _automovel.TipoCombustivel = (TipoCombustível)10;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_CapacidadeCombustivel_igual_a_zero()
        {
            //arrange
            _automovel.CapacidadeCombustivel = 0;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Ano_invalido()
        {
            //arrange
            _automovel.Ano = 1990;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Quilometragem_menor_que_zero()
        {
            //arrange
            _automovel.Quilometragem = -1;

            //action
            ValidationResult resultado = _validador.Validate(_automovel);

            //assert
            resultado.IsValid.Should().BeFalse();
        }
    }
}
