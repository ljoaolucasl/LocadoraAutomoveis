using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public class ValidadorPlanosCobrancas : AbstractValidator<PlanoCobranca>, IValidadorPlanoCobranca
    {
        public ValidadorPlanosCobrancas()
        {
            RuleFor(p => p.PlanoDiario_ValorDiario)
                .GreaterThan(0).WithMessage("'Valor diário' deve ser maior que zero.");

            RuleFor(p => p.PlanoDiario_ValorKm)
                .GreaterThan(0).WithMessage("'Valor por Km' deve ser maior que zero.");

            RuleFor(p => p.PlanoLivre_ValorDiario)
                .GreaterThan(0).WithMessage("'Valor diário' deve ser maior que zero.");

            RuleFor(p => p.PlanoControlador_ValorDiario)
                .GreaterThan(0).WithMessage("'Valor diário' deve ser maior que zero.");

            RuleFor(p => p.PlanoControlador_ValorKm)
                .GreaterThan(0).WithMessage("'Valor por Km' deve ser maior que zero.");

            RuleFor(p => p.PlanoControlador_LimiteKm)
                .GreaterThan(0).WithMessage("'Km disponiveis' deve ser maior que zero.");

            RuleFor(p => p.CategoriaAutomoveis)
                .NotNull().WithMessage("'CategoriaAutomoveis' não pode ser nula.");
        }
    }
}
