using FluentAssertions;
using FluentValidation.Results;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Testes.Dominio.ModuloParceiro
{
    [TestClass]
    public class ParceiroTeste
    {
        private ValidadorParceiro _validador;

        [TestInitialize]
        public void Setup()
        {
            _validador = new ValidadorParceiro();
        }

        [TestMethod]
        public void Deve_ter_no_minimo_3_caracteres()
        {
            Parceiro parceiro = new("Ac");

            ValidationResult resultado = _validador.Validate(parceiro);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_caracteres_especiais()
        {
            Parceiro parceiro = new("Academia do Programador@");

            ValidationResult resultado = _validador.Validate(parceiro);

            resultado.IsValid.Should().BeFalse();
        }

        [TestMethod]
        public void Nao_deve_aceitar_campo_vazio()
        {
            Parceiro parceiro = new("");

            ValidationResult resultado = _validador.Validate(parceiro);

            resultado.IsValid.Should().BeFalse();
        }
    }
}
