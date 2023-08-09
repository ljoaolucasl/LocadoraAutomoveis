using FluentValidation;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class ValidadorAluguel : AbstractValidator<Aluguel>, IValidadorAluguel
    {
        public ValidadorAluguel()
        {
            RuleFor(a => a.Funcionario)
                .NotNull().WithMessage("'Funcionário' é obrigatório.");

            RuleFor(a => a.Cliente)
                .NotNull().WithMessage("'Cliente' é obrigatório.");

            RuleFor(a => a.CategoriaAutomoveis)
                .NotNull().WithMessage("'Categoria de Automóveis' é obrigatória.");

            RuleFor(a => a.PlanoCobranca)
                .NotNull().WithMessage("'Plano de Cobrança' é obrigatório.");

            RuleFor(p => p.Plano)
                .IsInEnum().WithMessage("'Plano' inválido.");

            RuleFor(a => a.Condutor)
                .NotNull().WithMessage("'Condutor' é obrigatório.")
                .Must(c => c == null || c.Validade > DateTime.Now).WithMessage("CNH do 'Condutor' está fora da validade.");

            RuleFor(a => a.Automovel)
                .NotNull().WithMessage("'Automóvel' é obrigatório.")
                .Must(a => a == null || a.Alugado == false).WithMessage("'Automóvel' já está alugado.");

            RuleFor(a => a.ListaTaxasEServicos)
                .Must(lista => lista != null && lista.Count > 0).WithMessage("'Lista de Taxas e Serviços' não pode ser vazia.");

            RuleFor(a => a.DataLocacao)
                .LessThan(a => a.DataPrevistaRetorno).WithMessage("'Data de Locação' deve ser menor que a 'Data Prevista de Retorno'.");

            RuleFor(a => a.ValorTotal)
                .GreaterThanOrEqualTo(0).WithMessage("'Valor Total' não pode ser menor que zero.");

            RuleFor(a => a.DataDevolucao)
                .GreaterThan(a => a.DataLocacao).WithMessage("'Data de Devolução' deve ser maior que a 'Data de Locação'.");

            RuleFor(a => a.QuilometrosRodados)
                .GreaterThanOrEqualTo(0).WithMessage("'Quilometros Rodados' não pode ser menor que zero.");

            RuleFor(a => a.CombustivelRestante)
                .IsInEnum().WithMessage("'Combustível Restante' inválido.");
        }

        public bool CupomValido(Aluguel aluguelParaValidar)
        {
            return aluguelParaValidar.Cupom.DataValidade > DateTime.Now;
        }

        public bool ValidarSeAluguelConcluido(Aluguel aluguelParaValidar)
        {
            return aluguelParaValidar.Concluido;
        }
    }
}
