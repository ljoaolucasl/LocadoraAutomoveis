using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas
{
    public enum TipoPlano
    {
        [Description("Plano Diário")]
        Diario,
        [Description("Plano Controlador")]
        Controlador,
        [Description("Plano Livre")]
        Livre
    }
}
