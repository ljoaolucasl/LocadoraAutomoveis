using LocadoraAutomoveis.Dominio.Compartilhado;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloCliente
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Tipo TipoCliente { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }

        public Cliente(string nome, string email, string telefone, Tipo tipoCliente, string cPF, string cNPJ, string estado, string cidade, string bairro, string rua, int numero)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            TipoCliente = tipoCliente;
            CPF = cPF;
            CNPJ = cNPJ;
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
                   CPF == cliente.CPF &&
                   CNPJ == cliente.CNPJ &&
                   Estado == cliente.Estado &&
                   Cidade == cliente.Cidade &&
                   Bairro == cliente.Bairro &&
                   Rua == cliente.Rua &&
                   Numero == cliente.Numero;
        }
    }

    public enum Tipo
    {
        [Description("CPF")]
        CPF = 1,

        [Description("CNPJ")]
        CNPJ = 2
    }
}
