using FluentResults;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Infraestrutura.Repositorios;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoParceiro : IServicoBase<Parceiro>
    {
        private readonly RepositorioParceiro _repositorioParceiro;

        public ServicoParceiro(RepositorioParceiro repositorioParceiro)
        {
            _repositorioParceiro = repositorioParceiro;
        }

        public Result Inserir(Parceiro parceiroParaAdicionar)
        {
            throw new NotImplementedException();
        }

        public Result Editar(Parceiro parceiroParaEditar)
        {
            throw new NotImplementedException();
        }

        public Result Excluir(Parceiro parceiroParaExcluir)
        {
            throw new NotImplementedException();
        }

        public Parceiro SelecionarRegistroPorID(int parceiroID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parceiro> SelecionarTodosOsRegistros()
        {
            throw new NotImplementedException();
        }

        public Result ValidarRegistro(Parceiro parceiroParaValidar)
        {
            throw new NotImplementedException();
        }
    }
}
