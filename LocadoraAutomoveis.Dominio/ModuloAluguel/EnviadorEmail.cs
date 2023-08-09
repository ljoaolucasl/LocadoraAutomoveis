using System.Net.Mail;
using System.Net;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class EnviadorEmail
    {
        private readonly string _emailRemetente;
        private readonly string _senhaRemetente;
        private readonly string _servidorSmtp;
        private readonly int _portaSmtp;

        public EnviadorEmail(EmailConfig login)
        {
            _emailRemetente = login.Remetente;
            _senhaRemetente = login.Senha;
            _servidorSmtp = login.ServidorSmtp;
            _portaSmtp = login.PortaSmtp;
        }

        public async Task EnviarEmailAluguel(Aluguel aluguel, byte[] pdfBytes)
        {
            using var clienteSmtp = new SmtpClient(_servidorSmtp)
            {
                Port = _portaSmtp,
                Credentials = new NetworkCredential(_emailRemetente, _senhaRemetente),
                EnableSsl = true
            };

            var mensagem = new MailMessage
            {
                From = new MailAddress(_emailRemetente),
                Subject = "Detalhes da Locação",
                IsBodyHtml = true,
                Body = $@"
                        <html>
                        <body>
                            <p>Olá, {aluguel.Cliente.Nome}!</p>
                            <p>Segue em anexo o PDF com os detalhes da sua locação:</p>
                            <p>Obrigado por escolher nossos serviços!</p>
                            <br>
                            <p>Atenciosamente,</p>
                            <p>A Equipe da Locadora de Veículos</p>
                        </body>
                        </html>"
            };

            mensagem.To.Add(aluguel.Cliente.Email);

            var attachment = new Attachment(new MemoryStream(pdfBytes), "DetalhesLocacao.pdf");
            mensagem.Attachments.Add(attachment);

            await clienteSmtp.SendMailAsync(mensagem);
        }
    }
}
