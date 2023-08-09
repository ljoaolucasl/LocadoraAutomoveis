using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using LocadoraAutomoveis.Dominio.Extensions;
using LocadoraAutomoveis.Dominio.ModuloPlanosCobrancas;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public class GeradorPDF : IGeradorPDF
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
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Cliente: {aluguel.Cliente.Nome}"));
            document.Add(new Paragraph());

            switch (aluguel.Cliente.TipoCliente)
            {
                case ModuloCliente.TipoDocumento.CPF:
                    document.Add(new Paragraph($"Cliente CPF: {aluguel.Cliente.Documento}"));
                    break;
                case ModuloCliente.TipoDocumento.CNPJ:
                    document.Add(new Paragraph($"Cliente CNPJ: {aluguel.Cliente.Documento}"));
                    break;
            }

            document.Add(new Paragraph($"Condutor: {aluguel.Condutor.Nome}"));
            document.Add(new Paragraph($"Condutor CNH: {aluguel.Condutor.CNH}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Automóvel: {aluguel.Automovel.Modelo} - {aluguel.Automovel.Placa}"));
            document.Add(new Paragraph($"Capacidade Combustível: {aluguel.Automovel.CapacidadeCombustivel}"));
            document.Add(new Paragraph($"Categoria: {aluguel.CategoriaAutomoveis.Nome}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Plano de Cobrança: {aluguel.Plano.ToDescriptionString()}"));

            switch (aluguel.Plano)
            {
                case TipoPlano.Diario:
                    document.Add(new Paragraph($"                   Valor Diária: {aluguel.PlanoCobranca.PlanoDiario_ValorDiario:C}"));
                    document.Add(new Paragraph($"                   Valor por KM: {aluguel.PlanoCobranca.PlanoDiario_ValorKm:C}"));
                    break;
                case TipoPlano.Controlador:
                    document.Add(new Paragraph($"                   Valor Diária: {aluguel.PlanoCobranca.PlanoControlador_ValorDiario:C}"));
                    document.Add(new Paragraph($"                   Valor por KM(Extrapolado): {aluguel.PlanoCobranca.PlanoControlador_ValorKm:C}"));
                    document.Add(new Paragraph($"                   Limite KM: {aluguel.PlanoCobranca.PlanoControlador_LimiteKm}km"));
                    break;
                case TipoPlano.Livre:
                    document.Add(new Paragraph($"                   Valor Diária: {aluguel.PlanoCobranca.PlanoLivre_ValorDiario:C}"));
                    break;
            }

            document.Add(new Paragraph());
            document.Add(new Paragraph($"Taxas:"));

            foreach (var item in aluguel.ListaTaxasEServicos)
            {
                document.Add(new Paragraph($"       {item.Nome} - {item.Valor:C}"));
            }

            document.Add(new Paragraph());
            document.Add(new Paragraph($"Locação feita em: {aluguel.DataLocacao:d}"));
            document.Add(new Paragraph($"Data para devolução: {aluguel.DataPrevistaRetorno:d}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Desconto: {(aluguel.Cupom == null ? "" : aluguel.Cupom.Valor.ToString("C"))}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Valor Total: {aluguel.ValorTotal:C}"));

            document.Close();
            return stream.ToArray();
        }

        public byte[] GerarPDFDevolucao(Aluguel aluguel)
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
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Cliente: {aluguel.Cliente.Nome}"));
            document.Add(new Paragraph());

            switch (aluguel.Cliente.TipoCliente)
            {
                case ModuloCliente.TipoDocumento.CPF:
                    document.Add(new Paragraph($"Cliente CPF: {aluguel.Cliente.Documento}"));
                    break;
                case ModuloCliente.TipoDocumento.CNPJ:
                    document.Add(new Paragraph($"Cliente CNPJ: {aluguel.Cliente.Documento}"));
                    break;
            }

            document.Add(new Paragraph($"Condutor: {aluguel.Condutor.Nome}"));
            document.Add(new Paragraph($"Condutor CNH: {aluguel.Condutor.CNH}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Automóvel: {aluguel.Automovel.Modelo} - {aluguel.Automovel.Placa}"));
            document.Add(new Paragraph($"Capacidade Combustível: {aluguel.Automovel.CapacidadeCombustivel}"));
            document.Add(new Paragraph($"Categoria: {aluguel.CategoriaAutomoveis.Nome}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Plano de Cobrança: {aluguel.Plano.ToDescriptionString()}"));

            switch (aluguel.Plano)
            {
                case TipoPlano.Diario:
                    document.Add(new Paragraph($"                   Valor Diária: {aluguel.PlanoCobranca.PlanoDiario_ValorDiario:C}"));
                    document.Add(new Paragraph($"                   Valor por KM: {aluguel.PlanoCobranca.PlanoDiario_ValorKm:C}"));
                    break;
                case TipoPlano.Controlador:
                    document.Add(new Paragraph($"                   Valor Diária: {aluguel.PlanoCobranca.PlanoControlador_ValorDiario:C}"));
                    document.Add(new Paragraph($"                   Valor por KM(Extrapolado): {aluguel.PlanoCobranca.PlanoControlador_ValorKm:C}"));
                    document.Add(new Paragraph($"                   Limite KM: {aluguel.PlanoCobranca.PlanoControlador_LimiteKm}km"));
                    break;
                case TipoPlano.Livre:
                    document.Add(new Paragraph($"                   Valor Diária: {aluguel.PlanoCobranca.PlanoLivre_ValorDiario:C}"));
                    break;
            }

            document.Add(new Paragraph());
            document.Add(new Paragraph($"Taxas:"));

            foreach (var item in aluguel.ListaTaxasEServicos)
            {
                document.Add(new Paragraph($"       {item.Nome} - {item.Valor:C}"));
            }

            document.Add(new Paragraph());
            document.Add(new Paragraph($"Locação feita em: {aluguel.DataLocacao:d}"));
            document.Add(new Paragraph($"Data para devolução: {aluguel.DataPrevistaRetorno:d}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Data da devolução: {aluguel.DataDevolucao:d}"));
            document.Add(new Paragraph($"Quilometros Rodados: {aluguel.QuilometrosRodados}"));
            document.Add(new Paragraph($"Combustível Restante: {aluguel.CombustivelRestante}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Desconto: {(aluguel.Cupom == null ? "" : aluguel.Cupom.Valor.ToString("C"))}"));
            document.Add(new Paragraph());
            document.Add(new Paragraph($"Valor Total: {aluguel.ValorTotal:C}"));

            document.Close();
            return stream.ToArray();
        }
    }
}
