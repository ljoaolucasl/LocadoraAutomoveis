using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public class ValidadorPlanosCobrancas : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanosCobrancas()
        {
            RuleFor(p => p.ValorDia)
                .GreaterThan(0).WithMessage("'ValorDia' deve ser maior que zero.");

            RuleFor(p => p.ValorKmRodado)
                .Must((plano, valorKmRodado) => plano.Plano == TipoPlano.Livre ? valorKmRodado >= 0 : valorKmRodado > 0)
                .WithMessage("'ValorKmRodado' deve ser maior que zero.");

            RuleFor(p => p.KmLivre)
            .Must((plano, kmLivre) => (plano.Plano == TipoPlano.Diario || plano.Plano == TipoPlano.Livre) ? kmLivre >= 0 : kmLivre > 0)
            .WithMessage("'KmLivre' deve ser maior que zero.");

            RuleFor(p => p.Plano)
                .IsInEnum().WithMessage("'Plano' inválido.");

            RuleFor(p => p.CategoriaAutomoveis)
                .NotNull().WithMessage("'CategoriaAutomoveis' não pode ser nula.");
        }
    }
}
