using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloPlanosCobrancas
{
    public class PlanosCobrancasTeste
    {
        private ValidadorPlanosCobrancas _validador;
        private PlanoCobranca _planoCobranca;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorPlanosCobrancas();

            //_planoCobranca = new PlanoCobranca("");
        }
    }
}
