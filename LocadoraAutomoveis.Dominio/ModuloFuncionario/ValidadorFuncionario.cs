using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloFuncionario
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>, IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            RuleFor(f => f.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();

            RuleFor(f => f.Admissao)
                .Must(ValidarData).WithMessage("A data não é válida.")
                .NotEmpty().WithMessage(@"'Admissao' não pode estar vazia.");

            RuleFor(f => f.Salario)
                .NotEmpty().WithMessage(@"'Salario' não pode estar vazio.");
        }

        private bool ValidarData(DateTime date)
        {
            if (date == null)
                return true;

            return date.Date >= DateTime.Today;
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
