using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LocadoraAutomoveis.Dominio.Extensions;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class GeradorPDF
    {
        public byte[] GerarPDF(Aluguel aluguel)
        {
            using MemoryStream stream = new();
            PdfWriter writer = new(stream);
            PdfDocument pdf = new(writer);
            Document document = new(pdf);

            Paragraph titulo = new Paragraph("Detalhes da Locação")
                .SetTextAlignment(TextAlignment.CENTER)
                .SetFontSize(18)
                .SetBold();

            document.Add(titulo);

            document.Add(new Paragraph($"Funcionário: {aluguel.Funcionario.Nome}"));
            document.Add(new Paragraph($"Cliente: {aluguel.Cliente.Nome}"));

            switch (aluguel.Cliente.TipoCliente)
            {
                case ModuloCliente.TipoDocumento.CPF:
                    document.Add(new Paragraph($"CPF: {aluguel.Cliente.Documento}"));
                    break;
                case ModuloCliente.TipoDocumento.CNPJ:
                    document.Add(new Paragraph($"CNPJ: {aluguel.Cliente.Documento}"));
                    break;
            }

            document.Add(new Paragraph($"Condutor: {aluguel.Condutor.Nome}"));
            document.Add(new Paragraph($"Condutor CNH: {aluguel.Condutor.CNH}"));

            document.Add(new Paragraph($"Automóvel: {aluguel.Automovel.Modelo} - {aluguel.Automovel.Placa}"));
            document.Add(new Paragraph($"Categoria: {aluguel.CategoriaAutomoveis.Nome}"));
            document.Add(new Paragraph($"Plano de Cobrança: {aluguel.Plano.ToDescriptionString()}"));

            document.Add(new Paragraph($"Locação feita em: {aluguel.DataLocacao:d}"));
            document.Add(new Paragraph($"Data para devolução: {aluguel.DataPrevistaRetorno:d}"));

            document.Add(new Paragraph($"Valor Total: {aluguel.ValorTotal:C}"));


            document.Close();
            return stream.ToArray();
        }
    }
}
