using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>
    {
        public RepositorioFuncionario(ContextoDados contextoDb) : base(contextoDb)
        {
        }
    }
}
