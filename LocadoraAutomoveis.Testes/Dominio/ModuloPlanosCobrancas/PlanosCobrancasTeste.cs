using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloPlanosCobrancas
{
    [TestClass]
    public class PlanosCobrancasTeste
    {
        private ValidadorPlanosCobrancas _validador;
        private PlanoCobranca _planoCobranca;
        private CategoriaAutomoveis _categoria;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorPlanosCobrancas();

            _categoria = new CategoriaAutomoveis("Esportivo");
            _planoCobranca = new(100, 100, 100, TipoPlano.Diario, _categoria);
        }

        [TestMethod]
        public void Deve_aceitar_PlanoCobranca_valido()
        {
            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Categoria_nula()
        {
            _planoCobranca.CategoriaAutomoveis = null;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_TipoPlano_Invalido()
        {
            _planoCobranca.Plano = (TipoPlano)100;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Valor_Diario_zero()
        {
            _planoCobranca.ValorDia = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Valor_Km_Rodado_zero_Caso_TipoPlano_Diario()
        {
            _planoCobranca.ValorKmRodado = 0;
            _planoCobranca.Plano = TipoPlano.Diario;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Valor_Km_Rodado_zero_Caso_TipoPlano_Controlador()
        {
            _planoCobranca.ValorKmRodado = 0;
            _planoCobranca.Plano = TipoPlano.Controlador;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Km_Disponiveis_zero_Caso_TipoPlano_Controlador()
        {
            _planoCobranca.KmLivre = 0;
            _planoCobranca.Plano = TipoPlano.Controlador;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
