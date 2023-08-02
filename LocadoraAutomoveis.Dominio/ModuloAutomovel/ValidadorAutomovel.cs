using FluentValidation;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloAutomoveis
{
    public class ValidadorAutomovel : AbstractValidator<Automovel>
    {
        public ValidadorAutomovel()
        {
            RuleFor(a => a.Categoria)
                .NotNull().WithMessage("'Categoria' é obrigatória.");

            RuleFor(a => a.Placa)
                .NotEmpty().WithMessage("'Placa' não pode ser vazia.")
                .Custom(ValidarPlaca)
                .Length(7).WithMessage("'Placa' deve ter exatamente 7 caracteres.");

            RuleFor(a => a.Marca)
                .NotEmpty().WithMessage("'Marca' não pode ser vazia.");

            RuleFor(a => a.Cor)
                .Custom(ValidarCaractereInvalido)
                .NotEmpty().WithMessage("'Cor' não pode ser vazia.");

            RuleFor(a => a.Modelo)
                .NotEmpty().WithMessage("'Modelo' não pode ser vazio.");

            RuleFor(a => a.Imagem)
                .NotNull().WithMessage("'Imagem' é obrigatória.")
                .Custom(ValidarTamanho);

            RuleFor(a => a.TipoCombustivel)
                .IsInEnum().WithMessage("'Tipo de Combustível' inválido.");

            RuleFor(a => a.CapacidadeCombustivel)
                .GreaterThan(0).WithMessage("'Capacidade de Combustível' deve ser maior que zero.");

            RuleFor(a => a.Ano)
                .GreaterThanOrEqualTo(DateTime.Now.Year - 30).WithMessage("'Ano' inválido.");

            RuleFor(a => a.Quilometragem)
                .GreaterThanOrEqualTo(0).WithMessage("'Quilometragem' não pode ser zero.");
        }

        private void ValidarTamanho(byte[] imagem, ValidationContext<Automovel> contexto)
        {
            if (imagem == null || imagem.Length == 0)
                return;

            const int max2Mb = 2 * 1024 * 1024;

            if (imagem.Length <= max2Mb)
                contexto.AddFailure("'Imagem' deve ter no máximo 2 MB.");
        }

        private void ValidarPlaca(string placa, ValidationContext<Automovel> contexto)
        {
            if (string.IsNullOrWhiteSpace(placa))
                return;

            if (!Regex.IsMatch(placa, @"^[A-Z]{3}-\d{4}$|^[A-Z]{3}-\d[A-Z]\d{2}$"))
                contexto.AddFailure("'Placa' deve possuir o padrão (AAA-0000) ou (AAA-0A00).");
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<Automovel> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }
    }
}
