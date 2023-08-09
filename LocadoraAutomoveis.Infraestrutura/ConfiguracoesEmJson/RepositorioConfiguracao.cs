using LocadoraAutomoveis.Dominio.Configuracoes;
using Newtonsoft.Json;

namespace LocadoraAutomoveis.Infraestrutura.ConfiguracoesEmJson
{
    public class RepositorioConfiguracao : IRepositorioConfiguracao
    {
        private const string FilePath = "configuracao_precos.json";

        public PrecoCombustivel ObterConfiguracaoPrecos()
        {
            if (File.Exists(FilePath))
            {
                string json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<PrecoCombustivel>(json);
            }
            return new PrecoCombustivel();
        }

        public void SalvarConfiguracaoPrecos(PrecoCombustivel configuracao)
        {
            string json = JsonConvert.SerializeObject(configuracao);
            File.WriteAllText(FilePath, json);
        }

        public void SalvarConfiguracoesPrecos(PrecoCombustivel configuracao)
        {
            throw new NotImplementedException();
        }
    }
}
