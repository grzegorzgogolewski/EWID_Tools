using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UtworzOpis
{
    internal static class Program
    {
        private static void Main()
        {
            const string fileName = @"r:\koronowo_artur.kcd";

            string[] readText = File.ReadAllLines(fileName, Encoding.GetEncoding(1250));

            List<string> outpuText = new List<string>();

            foreach (string s in readText)
            {
                if (s.StartsWith("a998,"))
                {
                    outpuText.Add(s.Replace("a998,", "a17,"));

                }

                outpuText.Add(s);
            }

            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(fileName) ?? throw new InvalidOperationException(), Path.GetFileNameWithoutExtension(fileName) + "_uwagi.kcd"), outpuText, Encoding.GetEncoding(1250));
        }
    }
}
