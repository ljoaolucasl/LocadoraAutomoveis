using LocadoraAutomoveis.Aplicacao.Servicos;
using LocadoraAutomoveis.Dominio.ModuloAluguel;
using LocadoraAutomoveis.Dominio.ModuloAutomovel;
using LocadoraAutomoveis.Dominio.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using LocadoraAutomoveis.Dominio.ModuloCondutores;
using LocadoraAutomoveis.Dominio.ModuloConfiguracao;
using LocadoraAutomoveis.Dominio.ModuloCupom;
using LocadoraAutomoveis.Dominio.ModuloFuncionario;
using LocadoraAutomoveis.Dominio.ModuloParceiro;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;
using LocadoraAutomoveis.Dominio.ModuloTaxaEServico;
using LocadoraAutomoveis.Infraestrutura.Compartilhado;
using LocadoraAutomoveis.Infraestrutura.ModuloConfiguracao;
using LocadoraAutomoveis.Infraestrutura.Repositorios;
using LocadoraAutomoveis.WinApp.ModuloAluguel;
using LocadoraAutomoveis.WinApp.ModuloAutomovel;
using LocadoraAutomoveis.WinApp.ModuloCategoriaAutomoveis;
using LocadoraAutomoveis.WinApp.ModuloCliente;
using LocadoraAutomoveis.WinApp.ModuloCondutores;
using LocadoraAutomoveis.WinApp.ModuloConfiguracao;
using LocadoraAutomoveis.WinApp.ModuloCupom;
using LocadoraAutomoveis.WinApp.ModuloFuncionario;
using LocadoraAutomoveis.WinApp.ModuloParceiro;
using LocadoraAutomoveis.WinApp.ModuloPlanosCobrancas;
using LocadoraAutomoveis.WinApp.ModuloTaxaEServico;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LocadoraAutomoveis.WinApp.Compartilhado.Injection
{
    public class IoC_DependencyInjection : IoC
    {
        private ServiceProvider container;

        public IoC_DependencyInjection()
        {
            var configuracao = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

            var connectionString = configuracao.GetConnectionString("SqlServer");

            var servicos = new ServiceCollection();

            servicos.AddDbContext<IContextoPersistencia, ContextoDados>(optionsBuilder =>
            {
                optionsBuilder.UseSqlServer(connectionString);
            });

            servicos.AddTransient<ControladorCategoriaAutomoveis>();
            servicos.AddTransient<IServicoCategoriaAutomoveis, ServicoCategoriaAutomoveis>();
            servicos.AddTransient<IValidadorCategoria, ValidadorCategoriaAutomoveis>();
            servicos.AddScoped<IRepositorioCategoria, RepositorioCategoriaAutomoveis>();
            servicos.AddScoped<TabelaCategoriaAutomoveisControl>();

            servicos.AddTransient<ControladorFuncionario>();
            servicos.AddTransient<IServicoFuncionario, ServicoFuncionario>();
            servicos.AddTransient<IValidadorFuncionario, ValidadorFuncionario>();
            servicos.AddScoped<IRepositorioFuncionario, RepositorioFuncionario>();
            servicos.AddScoped<TabelaFuncionarioControl>();

            servicos.AddTransient<ControladorTaxaEServico>();
            servicos.AddTransient<IServicoTaxaEServico, ServicoTaxaEServico>();
            servicos.AddTransient<IValidadorTaxaEServico, ValidadorTaxaEServico>();
            servicos.AddScoped<IRepositorioTaxaEServico, RepositorioTaxaEServico>();
            servicos.AddScoped<TabelaTaxaEServicoControl>();

            servicos.AddTransient<ControladorParceiro>();
            servicos.AddTransient<IServicoParceiro, ServicoParceiro>();
            servicos.AddTransient<IValidadorParceiro, ValidadorParceiro>();
            servicos.AddScoped<IRepositorioParceiro, RepositorioParceiro>();
            servicos.AddScoped<TabelaParceiroControl>();

            servicos.AddTransient<ControladorAutomovel>();
            servicos.AddTransient<IServicoAutomovel, ServicoAutomovel>();
            servicos.AddTransient<IValidadorAutomovel, ValidadorAutomovel>();
            servicos.AddScoped<IRepositorioAutomovel, RepositorioAutomovel>();
            servicos.AddScoped<TabelaAutomovelControl>();

            servicos.AddTransient<ControladorCliente>();
            servicos.AddTransient<IServicoCliente, ServicoCliente>();
            servicos.AddTransient<IValidadorCliente, ValidadorCliente>();
            servicos.AddScoped<IRepositorioCliente, RepositorioCliente>();
            servicos.AddScoped<TabelaClienteControl>();

            servicos.AddTransient<ControladorCupom>();
            servicos.AddTransient<IServicoCupom, ServicoCupom>();
            servicos.AddTransient<IValidadorCupom, ValidadorCupom>();
            servicos.AddScoped<IRepositorioCupom, RepositorioCupom>();
            servicos.AddScoped<TabelaCupomControl>();

            servicos.AddTransient<ControladorCondutores>();
            servicos.AddTransient<IServicoCondutor, ServicoCondutores>();
            servicos.AddTransient<IValidadorCondutores, ValidadorCondutores>();
            servicos.AddScoped<IRepositorioCondutores, RepositorioCondutores>();
            servicos.AddScoped<TabelaCondutoresControl>();

            servicos.AddTransient<ControladorPlanosCobrancas>();
            servicos.AddTransient<IServicoPlanoCobranca, ServicoPlanosCobrancas>();
            servicos.AddTransient<IValidadorPlanoCobranca, ValidadorPlanosCobrancas>();
            servicos.AddScoped<IRepositorioPlanoCobranca, RepositorioPlanosCobrancas>();
            servicos.AddScoped<TabelaPlanosCobrancasControl>();

            servicos.AddTransient<ControladorAluguel>();
            servicos.AddTransient<IServicoAluguel, ServicoAluguel>();
            servicos.AddTransient<IValidadorAluguel, ValidadorAluguel>();
            servicos.AddScoped<IRepositorioAluguel, RepositorioAluguel>();
            servicos.AddScoped<TabelaAluguelControl>();

            servicos.AddTransient<ControladorConfiguracao>();
            servicos.AddScoped<IRepositorioConfiguracao, RepositorioConfiguracao>();

            container = servicos.BuildServiceProvider();
        }

        public T Get<T>()
        {
            return container.GetService<T>();
        }
    }
}
