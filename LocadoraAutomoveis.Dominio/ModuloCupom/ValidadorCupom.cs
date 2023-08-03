using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class ValidadorCupom : AbstractValidator<Cupom>, IValidadorCupom
    {
        public ValidadorCupom()
        {
            RuleFor(c => c.Nome)
           .NotEmpty().WithMessage("'Nome' não pode estar vazio.")
           .MinimumLength(3).WithMessage("'Nome' deve ter no mínimo 3 caracteres.")
           .Custom(ValidarCaractereInvalido);

            RuleFor(c => c.Valor)
                .GreaterThan(0).WithMessage("'Valor' deve ser maior que zero.");

            RuleFor(c => c.DataValidade)
                .GreaterThan(DateTime.Now).WithMessage("'DataValidade' deve ser uma data futura.");

            RuleFor(c => c.Parceiro)
                .NotNull().WithMessage("'Parceiro' não pode ser nulo.");
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Cupom> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }
    }
}
