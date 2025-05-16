using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceGenerator.Generators.WordTemplate
{
    public static class NameChecker
    {
        public static string GetUniqueFileName(string path)
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
