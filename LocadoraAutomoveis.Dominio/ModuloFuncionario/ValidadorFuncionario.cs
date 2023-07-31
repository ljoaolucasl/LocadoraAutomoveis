using FluentValidation;
using LocadoraAutomoveis.Dominio.Extensions;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>
    {
        public ValidadorFuncionario()
        {
            RuleFor(f => f.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();

            RuleFor(f => f.Admissao)
                .NotEmpty().WithMessage(@"'Admissao' não pode estar vazia.");

            RuleFor(f => f.Salario)
                .NotEmpty().WithMessage(@"'Salario' não pode estar vazio.");
        }

        public bool ValidarFuncionarioExistente(Funcionario funcionario, List<Funcionario> listaFuncionarios)
        {
            return listaFuncionarios.Any(f => f.ID != funcionario.ID);
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Funcionario> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }
    }
}
