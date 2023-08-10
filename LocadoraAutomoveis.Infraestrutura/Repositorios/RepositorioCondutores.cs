using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using Microsoft.EntityFrameworkCore;

namespace LocadoraAutomoveis.Infraestrutura.Repositorios
{
    public class RepositorioCondutores : RepositorioBase<Condutor>, IRepositorioCondutores
    {
        public RepositorioCondutores(ContextoDados contextoDb) : base(contextoDb)
        {
        }

        public RepositorioCondutores()
        {
        }

        public override bool Existe(Condutor condutorParaVerificar, bool exclusao = false)
        {
            if (exclusao)
                return Registros.Contains(condutorParaVerificar);

            return Registros.ToList().Any(c => c.Igual(condutorParaVerificar) && c.ID != condutorParaVerificar.ID || c.CNH == condutorParaVerificar.CNH);
        }

        public override List<Condutor> SelecionarTodos()
        {
            return Registros.Include(c => c.Cliente).ToList();
        }
    }
}
