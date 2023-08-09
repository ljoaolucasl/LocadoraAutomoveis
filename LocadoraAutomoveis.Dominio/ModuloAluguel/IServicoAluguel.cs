using FluentResults;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IServicoAluguel : IServicoBase<Aluguel>
    {
        IServicoFuncionario servicoFuncionario { get; }
        IServicoCliente servicoCliente { get; }
        IServicoCategoriaAutomoveis servicoCategoriaAutomoveis { get; }
        IServicoPlanoCobranca servicoPlanosCobrancas { get; }
        IServicoCondutor servicoCondutores { get; }
        IServicoAutomovel servicoAutomovel { get; }
        IServicoCupom servicoCupom { get; }
        IServicoTaxaEServico servicoTaxaEServico { get; }
        List<IError> ValidarCupom(Aluguel aluguelParaValidar);
    }
}
