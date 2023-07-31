using FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloParceiro
{
    [TestClass]
    public class ParceiroTeste
    {
        private RepositorioParceiro _repositorioParceiro;

        private ContextoDados _contexto;

        [TestInitialize]
        public void Setup()
        {
            _contexto = new LocadoraAutomoveisDesignFactory().CreateDbContext(null);

            _repositorioParceiro = new RepositorioParceiro(_contexto);

            _contexto.RemoveRange(_repositorioParceiro.Registros);
        }

        [TestMethod]
        public void Deve_ter_no_minimo_3_caracteres()
        {
            Parceiro parceiro = new("Ra");

            ValidationResult resultado = new ValidadorParceiro().Validate(parceiro);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            Parceiro parceiro = new("Rafael@");

            ValidationResult resultado = new ValidadorParceiro().Validate(parceiro);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            Parceiro parceiro = new("");

            ValidationResult resultado = new ValidadorParceiro().Validate(parceiro);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_categoria_repetida()
        {
            Parceiro parceiro1 = new("Rafael");
            Parceiro parceiro2 = new("Rafael");

            _repositorioParceiro.Inserir(parceiro1);

            bool resultado = new ValidadorParceiro().ValidarParceiroExistente(parceiro2, _repositorioParceiro.SelecionarTodos());

            resultado.Should().BeTrue();
        }
    }
}
