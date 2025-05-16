using DocumentFormat.OpenXml.Wordprocessing;
using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Table = DocumentFormat.OpenXml.Wordprocessing.Table;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;

namespace InvoiceGenerator.Generators.WordTemplate
{
    public static class Generator
    {
        public static void SearchAndReplace(string templatePath, string workingCopyPath, Dictionary<string, string> replacePairs, Dictionary<string, Dictionary<string, List<string>>>? replaceTables)
        {
            string rawName = replacePairs.Values.First();
            string safeName = "Faktura " + string.Concat(rawName.Select(c => Path.GetInvalidFileNameChars().Contains(c) ? '_' : c));
            workingCopyPath += $"\\{safeName}.docx";

            workingCopyPath = GetUniqueFileName(workingCopyPath);

            File.Copy(templatePath, workingCopyPath, overwrite: false);

            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(workingCopyPath, true))
            {
                if (wordDoc.MainDocumentPart is null)
                {
                    throw new ArgumentNullException("MainDocumentPart and/or Body is null.");
                }

                SearchAndReplaceParagraphs(wordDoc, replacePairs);
                ReplaceTablePlaceholders(wordDoc, replaceTables);

                wordDoc.MainDocumentPart.Document.Save();
            }
        }

        private static void SearchAndReplaceParagraphs(WordprocessingDocument wordDoc, Dictionary<string, string> replacePairs)
        {
            var paragraphs = wordDoc.MainDocumentPart.Document.Body.Descendants<Paragraph>();

            foreach (var para in paragraphs)
            {
                var texts = para.Descendants<Text>().ToList();
                string combined = string.Concat(texts.Select(t => t.Text));

                bool changed = false;

                foreach (var pair in replacePairs)
                {
                    var placeholder = $"{pair.Key}";
                    if (combined.Contains(placeholder))
                    {
                        combined = combined.Replace(placeholder, pair.Value);
                        changed = true;
                    }
                }

                if (changed)
                {
                    para.RemoveAllChildren<Run>();
                    var run = new Run(
                        new RunProperties(
                            new RunFonts { Ascii = "Arial", HighAnsi = "Arial" },
                            new FontSize { Val = "24" }
                        ),
                        new Text(combined)
                    );
                    para.Append(run);
                }
            }
        }

        private static void ReplaceTablePlaceholders(WordprocessingDocument wordDoc,
                        Dictionary<string, Dictionary<string, List<string>>> replaceTables)
        {
            var body = wordDoc.MainDocumentPart.Document.Body;

            foreach (var tableEntry in replaceTables)
            {
                var columns = tableEntry.Value;
                var keys = columns.Keys.ToList();

                var tables = wordDoc.MainDocumentPart.Document.Body.Elements<Table>().ToList();
                var targetTable = tables
                    .FirstOrDefault(t => t.InnerText.Contains("{{Lp}}"));

                if (targetTable == null) continue;


                List<TableRow> newRows = new();

                int rowCount = columns.First().Value.Count;
                for (int i = 0; i < rowCount; i++)
                {
                    var newRow = new TableRow();

                    foreach (var colKey in keys)
                    {
                        var value = columns[colKey][i];
                        var cell = new TableCell(new Paragraph(new Run(new Text(value))));
                        newRow.Append(cell);
                    }

                    newRows.Add(newRow);
                }
                var templateRow = targetTable.Descendants<TableRow>()
                    .FirstOrDefault(row => RowContainsPlaceholders(row, keys));

                if (templateRow == null) continue;

                var parentRows = targetTable.Elements().ToList();
                int insertIndex = parentRows.IndexOf(templateRow);

                targetTable.RemoveChild(templateRow);

                foreach (var newRow in newRows)
                {
                    targetTable.InsertAt(newRow, insertIndex++);
                }

            }
        }

        private static bool RowContainsPlaceholders(TableRow row, List<string> keys)
        {
            foreach (var cell in row.Elements<TableCell>())
            {
                var text = string.Concat(cell.Descendants<Text>().Select(t => t.Text));
                if (keys.Any(k => text.Contains($"{k}")))
                    return true;
            }
            return false;
        }
        private static string GetUniqueFileName(string path)
        {
            if (!File.Exists(path)) return path;

            string directory = Path.GetDirectoryName(path)!;
            string filename = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);

            int counter = 1;
            string newPath;

            do
            {
                newPath = Path.Combine(directory, $"{filename} ({counter}){extension}");
                counter++;
            } while (File.Exists(newPath));

            return newPath;
        }


    }
}
