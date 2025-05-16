using InvoiceGenerator.Generators.QuestPDF.Invoices.InvoiceComponents;
using InvoiceGenerator.Models;

namespace InvoiceGenerator.Generators.QuestPDF.Invoices
{
    public interface IInvoiceService
    {
        Task<InvoiceDocument> CreateInvoice(InvoiceDto invoiceData);
    }

    public class InvoiceService : IInvoiceService
    {

        public InvoiceService()
        {

        }
        /// <summary>
        /// Creates pdf invoice using QuestPDF
        /// </summary>
        public async Task<InvoiceDocument> CreateInvoice(InvoiceDto invoiceData)
        {
            return new InvoiceDocument(invoiceData);
        }

        //private string GetDocumentTemplateFilePath(string fileName)
        //{
        //    string rootPath = hostEnvironment.ContentRootPath;
        //    return Path.Combine(rootPath, "Files", "DocumentTemplates", fileName);
        //}
        //private string GetDocumentsFilePath(string fileName)
        //{
        //    string rootPath = hostEnvironment.ContentRootPath;
        //    return Path.Combine(rootPath, "Files", "Documents", fileName);
        //}
    }
}
