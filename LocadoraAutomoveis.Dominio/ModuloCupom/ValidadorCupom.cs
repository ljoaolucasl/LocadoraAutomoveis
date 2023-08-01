using FluentValidation;
using LocadoraAutomoveis.Dominio.Extensions;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloCupom
{
    public class ValidadorCupom : AbstractValidator<Cupom>
    {
        public ValidadorCupom()
        {
            RuleFor(c => c.Nome)
                .MinimumLength(3).WithMessage("'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();
        }

        public bool ValidarCupomExistente(Cupom cupom, List<Cupom> listaCupons)
        {
            return listaCupons.Any(c => string.Equals(c.Nome.RemoverAcento(), cupom.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != cupom.ID);
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
