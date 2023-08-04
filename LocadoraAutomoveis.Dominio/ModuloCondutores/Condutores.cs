using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloCondutores
{
    public class Condutores : EntidadeBase
    {
        public Cliente cliente {  get; set; }
        public bool TipoCondutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime Validade { get; set; }

        public Condutores(Cliente cliente, bool tipoCondutor, string nome, string email, string telefone, string cPF, string cNH, DateTime validade)
        {
            this.cliente = cliente;
            TipoCondutor = tipoCondutor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            CNH = cNH;
            Validade = validade;
        }

        public Condutores()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutores condutores &&
                   EqualityComparer<Cliente>.Default.Equals(cliente, condutores.cliente) &&
                   TipoCondutor == condutores.TipoCondutor &&
                   Nome == condutores.Nome &&
                   Email == condutores.Email &&
                   Telefone == condutores.Telefone &&
                   CPF == condutores.CPF &&
                   CNH == condutores.CNH &&
                   Validade == condutores.Validade;
        }
    }
}
