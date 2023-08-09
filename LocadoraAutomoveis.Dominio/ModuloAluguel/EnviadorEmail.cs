using MailKit.Net.Smtp;
using MimeKit;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class EnviadorEmail : IEnviadorEmail
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

        public void EnviarEmailAluguel(Aluguel aluguel, byte[] pdfBytes)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("Locadora de Automóveis", _emailRemetente));
            mensagem.To.Add(new MailboxAddress(aluguel.Cliente.Nome, aluguel.Cliente.Email));
            mensagem.Subject = "Detalhes da Locação";

            var corpoMensagem = new TextPart("html")
            {
                Text = $@"
            <html>
            <body>
                <p>Olá, {aluguel.Cliente.Nome}!</p>
                <p>Segue em anexo o PDF com os detalhes da sua locação:</p>
                <p>Obrigado por escolher nossos serviços!</p>
                <p>Atenciosamente,</p>
                <p>A Equipe da Locadora de Veículos</p>
            </body>
            </html>"
            };

            var anexo = new MimePart("application", "pdf")
            {
                Content = new MimeContent(new MemoryStream(pdfBytes)),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = "DetalhesLocacao.pdf"
            };

            var corpoMultiparte = new Multipart("mixed");
            corpoMultiparte.Add(corpoMensagem);
            corpoMultiparte.Add(anexo);

            mensagem.Body = corpoMultiparte;

            using var clienteSmtp = new SmtpClient();
            clienteSmtp.Connect(_servidorSmtp, _portaSmtp, true);
            clienteSmtp.Authenticate(_emailRemetente, _senhaRemetente);
            clienteSmtp.Send(mensagem);
            clienteSmtp.Disconnect(true);
        }
    }
}
