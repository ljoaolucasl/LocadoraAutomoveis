using FizzWare.NBuilder;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Infra.ModuloParceiro
{
    [TestClass]
    public class RepositorioParceiroTeste
    {
        private RepositorioParceiro _repositorioParceiro;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioParceiro = new RepositorioParceiro(_contexto);

            _contexto.RemoveRange(_repositorioParceiro.Registros);

            BuilderSetup.SetCreatePersistenceMethod<Parceiro>(_repositorioParceiro.Inserir);

            BuilderSetup.DisablePropertyNamingFor<Parceiro, int>(x => x.ID);
        }
    }
}
