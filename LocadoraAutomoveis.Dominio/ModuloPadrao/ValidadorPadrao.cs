using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloPadrao
{
    public class ValidadorPadrao : AbstractValidator<Padrao>
    {
        public ValidadorPadrao()
        {
            RuleFor(p => p.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .NotEmpty();
        }
    }
}