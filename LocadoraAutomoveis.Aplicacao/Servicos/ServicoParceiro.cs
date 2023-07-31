using FluentResults;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloParceiro;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoParceiro : IServicoBase<Parceiro>
    {
        public Result Inserir(Parceiro padraoParaAdicionar)
        {
            throw new NotImplementedException();
        }

        public Result Editar(Parceiro padraoParaEditar)
        {
            throw new NotImplementedException();
        }

        public Result Excluir(Parceiro padraoParaExcluir)
        {
            throw new NotImplementedException();
        }

        public Parceiro SelecionarRegistroPorID(int padraoID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Parceiro> SelecionarTodosOsRegistros()
        {
            throw new NotImplementedException();
        }

        public Result ValidarRegistro(Parceiro padraoParaValidar)
        {
            throw new NotImplementedException();
        }
    }
}
