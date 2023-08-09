using FluentValidation;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using System.Text.RegularExpressions;

namespace LocadoraAutomoveis.Dominio.ModuloTaxaEServico
{
    public class ValidadorTaxaEServico : AbstractValidator<TaxaEServico>, IValidadorTaxaEServico
    {
        public ValidadorTaxaEServico()
        {
            RuleFor(t => t.Nome)
                .MinimumLength(3).WithMessage(@"'Nome' deve ser maior ou igual a 3 caracteres.")
                .Custom(ValidarCaractereInvalido)
                .NotEmpty();

            RuleFor(t => t.Valor)
                .NotEqual(0)
                .NotEmpty();
        }

        public bool VerificarSeRelacionadoComAluguelAberto(TaxaEServico taxaParaValidar, List<Aluguel> alugueis)
        {
            return alugueis.Any(a => a.ListaTaxasEServicos.Contains(taxaParaValidar) && a.Concluido == false);
        }

        private void ValidarCaractereInvalido(string nome, ValidationContext<TaxaEServico> contexto)
        {
            if (string.IsNullOrWhiteSpace(nome))
                return;

            if (!Regex.IsMatch(nome, @"^[\p{L}\p{M}'\s-\d]+$"))
                contexto.AddFailure("Caractere Inválido");
        }
    }
}
