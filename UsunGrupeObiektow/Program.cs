using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UsunGrupeObiektow
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string inputFileName = args[0];
            string paramFileName = args[1];

            string outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName) ?? throw new InvalidOperationException(), Path.GetFileNameWithoutExtension(inputFileName) + "_[wynik].kcd");

            List<string> kcdAllLines = File.ReadAllLines(inputFileName, Encoding.GetEncoding(1250)).ToList();

            List<string> grupyObiektow = File.ReadAllLines(paramFileName, Encoding.GetEncoding(1250)).ToList();

            using (StreamWriter sw = new StreamWriter(new FileStream(outputFileName, FileMode.Create), Encoding.GetEncoding(1250)))
            {
                sw.NewLine = "\n";

                foreach (string inputLine in kcdAllLines.Where(inputLine => !grupyObiektow.Contains(inputLine)))
                {
                    sw.WriteLine(inputLine);
                }
            }
        }
    }
}
