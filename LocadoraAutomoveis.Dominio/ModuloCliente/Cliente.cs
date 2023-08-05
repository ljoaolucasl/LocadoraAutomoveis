using LocadoraAutomoveis.Dominio.Compartilhado;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public TipoDocumento TipoCliente { get; set; }
        public string Documento { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public Cliente(string nome, string email, string telefone, TipoDocumento tipoCliente, string documento, string estado, string cidade, string bairro, string rua, int numero)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoCliente = tipoCliente;
            Documento = documento;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
        }

        public Cliente()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Cliente cliente &&
                   Nome == cliente.Nome &&
                   Email == cliente.Email &&
                   Telefone == cliente.Telefone &&
                   TipoCliente == cliente.TipoCliente &&
                   Documento == cliente.Documento &&
                   Estado == cliente.Estado &&
                   Cidade == cliente.Cidade &&
                   Bairro == cliente.Bairro &&
                   Rua == cliente.Rua &&
                   Numero == cliente.Numero;
        }
    }

    public enum TipoDocumento
    {
        [Description("CPF")]
        CPF = 1,

        [Description("CNPJ")]
        CNPJ = 2
    }
}
