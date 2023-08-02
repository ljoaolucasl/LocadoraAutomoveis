using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloParceiro
{
    public class ValidadorParceiro : AbstractValidator<Parceiro>, IValidadorParceiro
    {
        public ValidadorParceiro()
        {
            RuleFor(p => p.Nome)
                .MinimumLength(3).WithMessage("'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();
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
