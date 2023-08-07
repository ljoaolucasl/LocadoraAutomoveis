using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class Aluguel : EntidadeBase
    {
        public Funcionario Funcionario { get; set; }
        public Cliente Cliente { get; set; }
        public CategoriaAutomoveis CategoriaAutomoveis { get; set; }
        public PlanoCobranca PlanoCobranca { get; set; }
        public Condutor Condutor { get; set; }
        public Automovel Automovel { get; set; }
        public Cupom? Cupom { get; set; }
        public List<TaxaEServico> ListaTaxasEServicos { get; set; }
        public DateTime DataLocacao { get; set; }
        public DateTime DataPrevistaRetorno { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public decimal? QuilometrosRodados { get; set; }
        public NivelTanque? CombustivelRestante { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Concluido { get; set; }

        public Aluguel(Funcionario funcionario, Cliente cliente, CategoriaAutomoveis categoriaAutomoveis, PlanoCobranca planoCobranca,
            Condutor condutor, Automovel automovel, Cupom? cupom, List<TaxaEServico> listaTaxasEServicos, DateTime dataLocacao,
            DateTime dataPrevistaRetorno, DateTime? dataDevolucao, decimal? quilometrosRodados, NivelTanque? combustivelRestante,
            decimal valorTotal, bool concluido)
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
            DataDevolucao = dataDevolucao;
            QuilometrosRodados = quilometrosRodados;
            CombustivelRestante = combustivelRestante;
            ValorTotal = valorTotal;
            Concluido = concluido;
        }

        public Aluguel()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Aluguel aluguel &&
                   ID.Equals(aluguel.ID) &&
                   EqualityComparer<Funcionario>.Default.Equals(Funcionario, aluguel.Funcionario) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, aluguel.Cliente) &&
                   EqualityComparer<CategoriaAutomoveis>.Default.Equals(CategoriaAutomoveis, aluguel.CategoriaAutomoveis) &&
                   EqualityComparer<PlanoCobranca>.Default.Equals(PlanoCobranca, aluguel.PlanoCobranca) &&
                   EqualityComparer<Condutor>.Default.Equals(Condutor, aluguel.Condutor) &&
                   EqualityComparer<Automovel>.Default.Equals(Automovel, aluguel.Automovel) &&
                   EqualityComparer<Cupom?>.Default.Equals(Cupom, aluguel.Cupom) &&
                   EqualityComparer<List<TaxaEServico>>.Default.Equals(ListaTaxasEServicos, aluguel.ListaTaxasEServicos) &&
                   DataLocacao == aluguel.DataLocacao &&
                   DataPrevistaRetorno == aluguel.DataPrevistaRetorno &&
                   DataDevolucao == aluguel.DataDevolucao &&
                   QuilometrosRodados == aluguel.QuilometrosRodados &&
                   CombustivelRestante == aluguel.CombustivelRestante &&
                   ValorTotal == aluguel.ValorTotal &&
                   Concluido == aluguel.Concluido;
        }
    }

    public enum NivelTanque
    {
        [Description("Vazio")]
        Vazio,

        [Description("1/4")]
        UmQuarto,

        [Description("1/2")]
        MeioTanque,

        [Description("3/4")]
        TresQuartos,

        [Description("Cheio")]
        Cheio
    }
}
