using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface ITelaAluguel : ITelaBase<Aluguel>
    {
        void CarregarDependencias(List<Funcionario> funcionarios, List<Cliente> clientes, List<CategoriaAutomoveis> categorias,
            List<PlanoCobranca> planos, List<Condutor> condutores, List<Automovel> automoveis, List<TaxaEServico> taxaEServicos);

        event Func<Aluguel, Result> OnValidarEObterCupom;
    }
}
