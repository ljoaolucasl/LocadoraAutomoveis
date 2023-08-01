using FluentResults;
using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCupom;

namespace LocadoraAutomoveis.Aplicacao.Servicos
{
    public class ServicoCupom : IServicoBase<Cupom>
    {
        public Result Inserir(Cupom padraoParaAdicionar)
        {
            throw new NotImplementedException();
        }

        public Result Editar(Cupom padraoParaEditar)
        {
            throw new NotImplementedException();
        }

        public Result Excluir(Cupom padraoParaExcluir)
        {
            throw new NotImplementedException();
        }

        public Cupom SelecionarRegistroPorID(int padraoID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cupom> SelecionarTodosOsRegistros()
        {
            throw new NotImplementedException();
        }

        public Result ValidarRegistro(Cupom padraoParaValidar)
        {
            throw new NotImplementedException();
        }
    }
}
