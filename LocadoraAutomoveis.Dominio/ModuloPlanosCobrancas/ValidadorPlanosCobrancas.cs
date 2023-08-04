using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public class ValidadorPlanosCobrancas : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanosCobrancas()
        {
            RuleFor(a => a.ValorDia)
            .GreaterThan(0).WithMessage("'ValorDia' deve ser maior que zero.");

            RuleFor(a => a.ValorKmRodado)
                .GreaterThanOrEqualTo(0).WithMessage("'ValorKmRodado' deve ser maior ou igual a zero.");

            RuleFor(a => a.KmLivre)
                .GreaterThan(0).WithMessage("'KmLivre' deve ser maior que zero.");

            RuleFor(a => a.Plano)
                .NotNull().WithMessage("'Plano' não pode ser nulo.");

            RuleFor(a => a.CategoriaAutomoveis)
                .NotNull().WithMessage("'CategoriaAutomoveis' não pode ser nula.");
        }
    }
}
