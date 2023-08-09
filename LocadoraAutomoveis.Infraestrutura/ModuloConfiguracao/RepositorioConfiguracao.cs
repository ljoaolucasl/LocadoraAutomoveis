using LocadoraAutomoveis.Dominio.ModuloConfiguracao;
using Newtonsoft.Json;

namespace LocadoraAutomoveis.Infraestrutura.ModuloConfiguracao
{
    public class RepositorioConfiguracao : IRepositorioConfiguracao
    {
        private readonly string FilePath = @"C:\temp\configuracao_precos.json";

        public PrecoCombustivel ObterConfiguracaoPrecos()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<PrecoCombustivel>(json);
            }
            return new PrecoCombustivel();
        }

        public void SalvarConfiguracoesPrecos(PrecoCombustivel configuracao)
        {
            string json = JsonConvert.SerializeObject(configuracao);
            File.WriteAllText(FilePath, json);
        }
    }
}
