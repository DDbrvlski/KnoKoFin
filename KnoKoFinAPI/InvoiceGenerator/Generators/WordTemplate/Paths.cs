using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Generators.WordTemplate
{
    public static class Paths
    {
        private static readonly string ProjectRoot =
        Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\.."));

        //Trzeba przerzucić pliki do aplikacji rozruchowej
        public static string TemplateFolder => Path.Combine(ProjectRoot, "Files\\Templates");
        public static string OutputInvoicesFolder => Path.Combine(ProjectRoot, "Files\\Invoices");
        public static string OutputCorrectiveInvoicesFolder => Path.Combine(ProjectRoot, "Files\\CorrectiveInvoices");

        public static string GetDocumentTemplateFilePath(string fileName)
        {
            return Path.Combine(TemplateFolder, fileName);
        }
        public static string GetDocumentInvoicesFilePath(string fileName)
        {
            return Path.Combine(OutputInvoicesFolder, fileName);
        }
    }

}
