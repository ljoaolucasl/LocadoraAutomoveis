using FluentValidation;
using LocadoraAutomoveis.Dominio.Extensions;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis
{
    public class ValidadorCategoriaAutomoveis : AbstractValidator<CategoriaAutomoveis>
    {
        public ValidadorCategoriaAutomoveis()
        {
            RuleFor(c => c.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();
        }

        public bool ValidarCategoriaExistente(CategoriaAutomoveis categoria, List<CategoriaAutomoveis> listaCategorias)
        {
            return listaCategorias.Any(c => string.Equals(c.Nome.RemoverAcento(), categoria.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && c.ID != categoria.ID);
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<CategoriaAutomoveis> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }
    }
}
