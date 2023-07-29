using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LocadoraAutomoveis.Infraestrutura.Compartilhado
{
    public class ContextoDados : DbContext
    {
        public ContextoDados(DbContextOptions<ContextoDados> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(Log.Logger);
            });

            optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoDados).Assembly);
        }
    }
}