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
            .NotEmpty()
            .Must(ValidarFormatoEmail).WithMessage("'Email' inválido.");

            RuleFor(c => c.Telefone)
            .NotEmpty().WithMessage("'Telefone' não pode ser vazio.")
            .Must(ValidarTelefone).WithMessage("'Telefone' inválido!");

            RuleFor(c => c.TipoCliente)
            .NotEmpty().WithMessage("'TipoCliente' não pode ser vazio.")
            .IsInEnum().WithMessage("'TipoCliente' inválido.");

            RuleFor(c => c.Documento)
            .NotEmpty().WithMessage("'CPF' não pode ser vazio.")
            .Custom(ValidarCPF)
            .When(c => c.TipoCliente == TipoDocumento.CPF);

            RuleFor(c => c.Documento)
            .NotEmpty().WithMessage("'CNPJ' não pode ser vazio.")
            .Custom(ValidarCNPJ)
            .When(c => c.TipoCliente == TipoDocumento.CNPJ);

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

        private void ValidarCPF(string document, ValidationContext<Cliente> contexto)
        {
            if (Regex.IsMatch(document, @"^\d{3}.\d{3}.\d{3}-\d{2}$"))
                return;

            else
                contexto.AddFailure("CPF" ,"CPF inválido.");
        }

        private void ValidarCNPJ(string document, ValidationContext<Cliente> contexto)
        {
            if (Regex.IsMatch(document, @"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$"))
                return;

            else
                contexto.AddFailure("CNPJ", "CNPJ inválido!");
        }

        private bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$");
        }
    }
}
