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
            _planoCobranca = new(100, 100, 100, 100, 100, 100, _categoria);
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
        public void Nao_deve_aceitar_Plano_Diario_Valor_Diario_zero()
        {
            _planoCobranca.PlanoDiario_ValorDiario = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Plano_Livre_Valor_Diario_zero()
        {
            _planoCobranca.PlanoLivre_ValorDiario = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Plano_Controlador_Valor_Diario_zero()
        {
            _planoCobranca.PlanoControlador_ValorDiario = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Plano_Diario_Valor_por_Km_zero()
        {
            _planoCobranca.PlanoDiario_ValorKm = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Plano_Controlador_Valor_por_Km_zero()
        {
            _planoCobranca.PlanoControlador_ValorKm = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_Km_Disponiveis_zero()
        {
            _planoCobranca.PlanoControlador_LimiteKm = 0;

            ValidationResult resultado = _validador.Validate(_planoCobranca);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
