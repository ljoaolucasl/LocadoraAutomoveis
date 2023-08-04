using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloCondutores
{
    public class ValidadorCondutores : AbstractValidator<Condutores>, IValidadorCondutores
    {
        public ValidadorCondutores()
        {
            RuleFor(c => c.cliente)
                .NotNull().WithMessage("'Cliente' é obrigatório.");

            //RuleFor(c => c.TipoCondutor)
            //.NotEmpty().WithMessage("'TipoCondutor' não pode ser vazio.")
            //.IsInEnum().WithMessage("'TipoCliente' inválido.");

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

            RuleFor(c => c.CPF)
            .NotEmpty().WithMessage("'CPF' não pode ser vazio.")
            .Custom(ValidarCPF);

            RuleFor(c => c.CNH)
            .NotEmpty().WithMessage("'CNH' não pode ser vazio.")
            .Custom(ValidarCNH)
            .Length(11).WithMessage("'Número da CNH' deve ter 11 caracteres.");

            RuleFor(c => c.Validade)
                .Must(ValidarData).WithMessage("A data não é válida.")
                .NotEmpty().WithMessage(@"'Validade' não pode estar vazia.");
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Condutores> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }

        public bool ValidarCondutorExistente(Condutores cliente, List<Condutores> listaClientes)
        {
            return listaClientes.Any(f => f.ID != cliente.ID);
        }

        private bool ValidarFormatoEmail(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            Regex regexEmail = new Regex(padraoEmail);

            return regexEmail.IsMatch(email);
        }

        private bool ValidarTelefone(string telefone)
        {
            return Regex.IsMatch(telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$");
        }

        private void ValidarCPF(string document, ValidationContext<Condutores> contexto)
        {
            if (Regex.IsMatch(document, @"^\d{3}.\d{3}.\d{3}-\d{2}$"))
                return;

            else
                contexto.AddFailure("CPF", "CPF inválido.");
        }

        private void ValidarCNH(string numeroCNH, ValidationContext<Condutores> contexto)
        {
            if (Regex.IsMatch(numeroCNH, @"^[0-9A-Za-z]{11}$"))
                return;

            else
                contexto.AddFailure("CNH", "CNH inválido.");
        }

        private bool ValidarData(DateTime date)
        {
            if (date == null)
                return true;

            return date.Date >= DateTime.Today;
        }
    }
}
