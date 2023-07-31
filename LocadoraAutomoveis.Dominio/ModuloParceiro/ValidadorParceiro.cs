using FluentValidation;
using LocadoraAutomoveis.Dominio.Extensions;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
    public class ValidadorParceiro : AbstractValidator<Parceiro>
    {
        public ValidadorParceiro()
        {
            RuleFor(x => x.Nome)
                .MinimumLength(3).WithMessage("'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();
        }

        public bool ValidarParceiroExistente(Parceiro parceiro, List<Parceiro> listaParceiros)
        {
            return listaParceiros.Any(p => string.Equals(p.Nome.RemoverAcento(), parceiro.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && p.ID != parceiro.ID);
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Parceiro> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }
    }
}
