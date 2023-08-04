using LocadoraAutomoveis.Dominio.ModuloFuncionario;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioFuncionario : RepositorioBase<Funcionario>, IRepositorioFuncionario
    {
        public RepositorioFuncionario(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioFuncionario()
        {
        }

        public override bool Existe(Funcionario funcionarioParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(funcionarioParaVerificar);

            return Registros.ToList().Any(f => string.Equals(f.Nome.RemoverAcento(), funcionarioParaVerificar.Nome.RemoverAcento(), StringComparison.OrdinalIgnoreCase) && f.ID != funcionarioParaVerificar.ID);
        }
    }
}
