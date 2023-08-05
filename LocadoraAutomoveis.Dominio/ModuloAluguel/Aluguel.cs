using LocadoraAutomoveis.Dominio.ModuloAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public CategoriaAutomoveis CategoriaAutomoveis { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        public Condutores Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public Cupom Cupom { get; set; }
        public List<TaxaEServico> ListaTaxasEServicos { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataPrevistaRetorno { get; set; }
        public decimal ValorTotal { get; set; }

        public Aluguel(Funcionario funcionario, Cliente cliente, CategoriaAutomoveis categoriaAutomoveis, PlanoCobranca planoCobranca, Condutores condutor,
            Automovel automovel, Cupom cupom, List<TaxaEServico> listaTaxasEServicos, DateTime dataLocacao, DateTime dataPrevistaRetorno, decimal valorTotal)
        {
            Funcionario = funcionario;
            Cliente = cliente;
            CategoriaAutomoveis = categoriaAutomoveis;
            PlanoCobranca = planoCobranca;
            Condutor = condutor;
            Automovel = automovel;
            Cupom = cupom;
            ListaTaxasEServicos = listaTaxasEServicos;
            DataLocacao = dataLocacao;
            DataPrevistaRetorno = dataPrevistaRetorno;
            ValorTotal = valorTotal;
        }

        public Aluguel()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Aluguel aluguel &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, aluguel.Funcionario) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, aluguel.Cliente) &&
                   EqualityComparer<CategoriaAutomoveis>.Default.Equals(CategoriaAutomoveis, aluguel.CategoriaAutomoveis) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, aluguel.PlanoCobranca) &&
                   EqualityComparer<Condutores>.Default.Equals(Condutor, aluguel.Condutor) &&
                   EqualityComparer<Automovel>.Default.Equals(Automovel, aluguel.Automovel) &&
                   EqualityComparer<Cupom>.Default.Equals(Cupom, aluguel.Cupom) &&
                   EqualityComparer<List<TaxaEServico>>.Default.Equals(ListaTaxasEServicos, aluguel.ListaTaxasEServicos) &&
                   DataLocacao == aluguel.DataLocacao &&
                   DataPrevistaRetorno == aluguel.DataPrevistaRetorno &&
                   ValorTotal == aluguel.ValorTotal;
        }
    }
}
