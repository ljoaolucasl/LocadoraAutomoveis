using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LocadoraAutomoveis.Infraestrutura.Compartilhado
{
    public class LocadoraAutomoveisDesignFactory : IDesignTimeDbContextFactory<ContextoDados>
    {
        public ContextoDados CreateDbContext(string[] args)
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var optionsBuilder = new DbContextOptionsBuilder<ContextoDados>();

            optionsBuilder.UseSqlServer(connectionString);

            return new ContextoDados(optionsBuilder.Options);
        }
    }
}
