using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public class ValidadorCliente : AbstractValidator<Cliente>, IValidadorCliente
    {
        public ValidadorCliente()
        {
            RuleFor(c => c.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();

            RuleFor(c => c.Email)
            .MinimumLength(3).WithMessage("'Email' deve ser maior ou igual a 3 caracteres.")
            .Custom(ValidarCaractereInvalido)
            .NotEmpty()
            .Must(ValidarFormatoEmail).WithMessage("'Email' inválido.");

            RuleFor(c => c.Telefone)
                .MinimumLength(8).WithMessage(@"'Telefone' deve conter 8 caracteres.")
                .MaximumLength(9).WithMessage(@"'Telefone' não pode ser maior que 9 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();

            RuleFor(c => c.Telefone)
            .NotEmpty().WithMessage("'Telefone' não pode ser vazio.")
            .MinimumLength(10).WithMessage("'Telefone' deve ter pelo menos 10 dígitos.")
            .MaximumLength(11).WithMessage("'Telefone' deve ter no máximo 11 dígitos.")
            .Matches(@"^\d{2}\d{4,5}\d{4}$").WithMessage("'Telefone' deve estar no formato (00) 00000-0000 ou (00) 0000-0000.");

            RuleFor(c => c.TipoCliente)
            .NotEmpty().WithMessage("'TipoCliente' não pode ser vazio.")
            .IsInEnum().WithMessage("'TipoCliente' inválido.");

            RuleFor(c => c.CPF)
            .NotEmpty().WithMessage("'CPF' não pode ser vazio.")
            .Length(11).WithMessage("'CPF' deve conter exatamente 11 dígitos.")
            .Matches(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$").WithMessage("'CPF' inválido.");

            RuleFor(c => c.CNPJ)
            .NotEmpty().WithMessage("'CNPJ' não pode ser vazio.")
            .Length(14).WithMessage("'CNPJ' deve conter exatamente 14 dígitos.")
            .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$").WithMessage("'CNPJ' inválido.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("'Estado' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Estado' deve ser maior ou igual a 3 caracteres.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("'Cidade' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Cidade' deve ser maior ou igual a 3 caracteres.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("'Bairro' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Bairro' deve ser maior ou igual a 3 caracteres.");

            RuleFor(c => c.Rua)
                .NotEmpty().WithMessage("'Rua' não pode ser vazio.")
                .MinimumLength(3).WithMessage("'Rua' deve ser maior ou igual a 3 caracteres.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("'Numero' não pode ser vazio.")
                .GreaterThan(0).WithMessage("'Numero' deve ser maior que zero.");
        }

        public bool ValidarClienteExistente(Cliente cliente, List<Cliente> listaClientes)
        {
            return listaClientes.Any(f => f.ID != cliente.ID);
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Cliente> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }

        private bool ValidarFormatoEmail(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regexEmail = new Regex(padraoEmail);

            return regexEmail.IsMatch(email);
        }
    }
}
