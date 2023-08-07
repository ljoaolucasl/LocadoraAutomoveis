using LocadoraAutomoveis.Dominio.Compartilhado;
using LocadoraAutomoveis.Dominio.ModuloCliente;
using System.ComponentModel;

namespace LocadoraAutomoveis.Dominio.ModuloCondutores
{
    public class Condutor : EntidadeBase
    {
        public Cliente Cliente {  get; set; }
        public bool TipoCondutor { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; }
        public string CNH { get; set; }
        public DateTime Validade { get; set; }

        public Condutor(Cliente cliente, bool tipoCondutor, string nome, string email, string telefone, string cPF, string cNH, DateTime validade)
        {
            this.Cliente = cliente;
            TipoCondutor = tipoCondutor;
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cPF;
            CNH = cNH;
            Validade = validade;
        }

        public Condutor()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is Condutor condutor &&
                   ID.Equals(condutor.ID) &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   TipoCondutor == condutor.TipoCondutor &&
                   Nome == condutor.Nome &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   Validade == condutor.Validade;
        }

        public bool Igual(object? obj)
        {
            return obj is Condutor condutor &&
                   EqualityComparer<Cliente>.Default.Equals(Cliente, condutor.Cliente) &&
                   TipoCondutor == condutor.TipoCondutor &&
                   Nome == condutor.Nome &&
                   Email == condutor.Email &&
                   Telefone == condutor.Telefone &&
                   CPF == condutor.CPF &&
                   CNH == condutor.CNH &&
                   Validade == condutor.Validade;
        }
    }
}
