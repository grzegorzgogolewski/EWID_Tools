using System;
using System.Globalization;
using System.IO;
using System.Text;
using KCDReader;

namespace RozbijObiekty
{
    static class Program
    {
        private static void Main(string[] args)
        {
            string inFileName = args[0];

            // USUNIĘCIE DUBLI PUNKTOW NA WEJSCIU

            string outFileName = Path.Combine(Path.GetDirectoryName(inFileName) ?? throw new InvalidOperationException(), Path.GetFileNameWithoutExtension(inFileName) + ".tmp");

            using (StreamReader sr = new StreamReader(inFileName, Encoding.GetEncoding(1250)))
            using (StreamWriter sw = new StreamWriter(outFileName, false, Encoding.GetEncoding(1250)))
            {
                string linePop = "";

                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();

                    if (line != linePop)
                    {
                        linePop = line;
                        sw.WriteLine(line);    
                    }
                }
            }

            inFileName = outFileName;

            KcdReader kcdReader = new KcdReader(inFileName);
            kcdReader.LoadKcd();

            int featureCount = 0;

            using (StreamWriter sw =
                new StreamWriter(
                    new FileStream(
                        Path.Combine(Path.GetDirectoryName(inFileName) ?? throw new InvalidOperationException(), 
                            Path.GetFileNameWithoutExtension(inFileName) + "_[err].kcd"), FileMode.Create), 
                    Encoding.GetEncoding(1250)))
            {
                foreach (KcdFeature kcdFeature in kcdReader.GetKcdFeatures())
                {
                    if (kcdFeature.AtrDuplicatesCount == 0)
                    {
                        featureCount++;

                        sw.Write(kcdFeature.AtrKodObiektu + '\r');
                        if (kcdFeature.AtrC != null) sw.Write(kcdFeature.AtrC + '\r');
                        if (kcdFeature.AtrM != null) sw.Write(kcdFeature.AtrM + '\r');
                        if (kcdFeature.AtrS != null) sw.Write(kcdFeature.AtrS + '\r');
                        if (kcdFeature.AtrK != null) sw.Write(kcdFeature.AtrK + '\r');
                        if (kcdFeature.Atr333 != null) sw.Write(kcdFeature.Atr333 + '\r');
                        if (kcdFeature.AtrI != null) sw.Write(kcdFeature.AtrI + '\r');

                        foreach (string atrP in kcdFeature.AtrP)
                        {
                            sw.Write(atrP + '\r');
                        }

                        if (kcdFeature.AtrO != null) sw.Write(kcdFeature.AtrO + '\r');

                        if (kcdFeature.Atr6 != null) sw.Write(kcdFeature.Atr6 + '\r');
                        if (kcdFeature.Atr15 != null) sw.Write(kcdFeature.Atr15 + '\r');
                        if (kcdFeature.Atr16 != null) sw.Write(kcdFeature.Atr16 + '\r');
                        if (kcdFeature.Atr17 != null) sw.Write(kcdFeature.Atr17 + '\r');
                        if (kcdFeature.Atr18 != null) sw.Write(kcdFeature.Atr18 + '\r');
                        if (kcdFeature.Atr73 != null) sw.Write(kcdFeature.Atr73 + '\r');
                        if (kcdFeature.Atr76 != null) sw.Write(kcdFeature.Atr76 + '\r');
                        if (kcdFeature.Atr77 != null) sw.Write(kcdFeature.Atr77 + '\r');
                        if (kcdFeature.Atr78 != null) sw.Write(kcdFeature.Atr78 + '\r');
                        if (kcdFeature.Atr79 != null) sw.Write(kcdFeature.Atr79 + '\r');
                        if (kcdFeature.Atr94 != null) sw.Write(kcdFeature.Atr94 + '\r');
                        
                        if (kcdFeature.AtrW != null) sw.Write(kcdFeature.AtrW + '\r');
                    }
                }

                if (featureCount > 0) sw.Write(":FK" + '\r');
            }

            featureCount = 0;

            using (StreamWriter sw = new StreamWriter(
                new FileStream(
                    Path.Combine(Path.GetDirectoryName(inFileName) ?? throw new InvalidOperationException(),
                        Path.GetFileNameWithoutExtension(inFileName) + "_[poprawne].kcd"), FileMode.Create),
                Encoding.GetEncoding(1250)))
            {
                foreach (KcdFeature kcdFeature in kcdReader.GetKcdFeatures())
                {
                    if (kcdFeature.AtrDuplicatesCount == 1)
                    {
                        featureCount++;

                        sw.Write(kcdFeature.AtrKodObiektu + '\r');
                        if (kcdFeature.AtrC != null) sw.Write(kcdFeature.AtrC + '\r');
                        if (kcdFeature.AtrM != null) sw.Write(kcdFeature.AtrM + '\r');
                        if (kcdFeature.AtrS != null) sw.Write(kcdFeature.AtrS + '\r');
                        if (kcdFeature.AtrK != null) sw.Write(kcdFeature.AtrK + '\r');
                        if (kcdFeature.Atr333 != null) sw.Write(kcdFeature.Atr333 + '\r');
                        if (kcdFeature.AtrI != null) sw.Write(kcdFeature.AtrI + '\r');

                        foreach (string atrP in kcdFeature.AtrP)
                        {
                            sw.Write(atrP + '\r');
                        }

                        if (kcdFeature.AtrO != null) sw.Write(kcdFeature.AtrO + '\r');

                        if (kcdFeature.Atr6 != null) sw.Write(kcdFeature.Atr6 + '\r');
                        if (kcdFeature.Atr15 != null) sw.Write(kcdFeature.Atr15 + '\r');
                        if (kcdFeature.Atr16 != null) sw.Write(kcdFeature.Atr16 + '\r');
                        if (kcdFeature.Atr17 != null) sw.Write(kcdFeature.Atr17 + '\r');
                        if (kcdFeature.Atr18 != null) sw.Write(kcdFeature.Atr18 + '\r');
                        if (kcdFeature.Atr73 != null) sw.Write(kcdFeature.Atr73 + '\r');
                        if (kcdFeature.Atr76 != null) sw.Write(kcdFeature.Atr76 + '\r');
                        if (kcdFeature.Atr77 != null) sw.Write(kcdFeature.Atr77 + '\r');
                        if (kcdFeature.Atr78 != null) sw.Write(kcdFeature.Atr78 + '\r');
                        if (kcdFeature.Atr79 != null) sw.Write(kcdFeature.Atr79 + '\r');
                        if (kcdFeature.Atr94 != null) sw.Write(kcdFeature.Atr94 + '\r');
                        
                        if (kcdFeature.AtrW != null) sw.Write(kcdFeature.AtrW + '\r');
                    }
                }

                if (featureCount > 0) sw.Write(":FK" + '\r');
            }

            featureCount = 0;

            using (StreamWriter sw = new StreamWriter(
                new FileStream(
                    Path.Combine(Path.GetDirectoryName(inFileName) ?? throw new InvalidOperationException(),
                        Path.GetFileNameWithoutExtension(inFileName) + "_[duble].kcd"), FileMode.Create),
                Encoding.GetEncoding(1250)))
            {
                foreach (KcdFeature kcdFeature in kcdReader.GetKcdFeatures())
                {
                    if (kcdFeature.AtrDuplicatesCount > 1)
                    {
                        featureCount++;

                        sw.Write(kcdFeature.AtrKodObiektu + '\r');
                        if (kcdFeature.AtrC != null) sw.Write(kcdFeature.AtrC + '\r');
                        if (kcdFeature.AtrM != null) sw.Write(kcdFeature.AtrM + '\r');
                        if (kcdFeature.AtrS != null) sw.Write(kcdFeature.AtrS + '\r');
                        if (kcdFeature.AtrK != null) sw.Write(kcdFeature.AtrK + '\r');
                        if (kcdFeature.Atr333 != null) sw.Write(kcdFeature.Atr333 + '\r');
                        if (kcdFeature.AtrI != null) sw.Write(kcdFeature.AtrI + '\r');

                        foreach (string atrP in kcdFeature.AtrP)
                        {
                            sw.Write(atrP + '\r');
                        }

                        if (kcdFeature.AtrO != null) sw.Write(kcdFeature.AtrO + '\r');

                        if (kcdFeature.Atr6 != null) sw.Write(kcdFeature.Atr6 + '\r');
                        if (kcdFeature.Atr15 != null) sw.Write(kcdFeature.Atr15 + '\r');
                        if (kcdFeature.Atr16 != null) sw.Write(kcdFeature.Atr16 + '\r');
                        if (kcdFeature.Atr17 != null) sw.Write(kcdFeature.Atr17 + '\r');
                        if (kcdFeature.Atr18 != null) sw.Write(kcdFeature.Atr18 + '\r');
                        if (kcdFeature.Atr73 != null) sw.Write(kcdFeature.Atr73 + '\r');
                        if (kcdFeature.Atr76 != null) sw.Write(kcdFeature.Atr76 + '\r');
                        if (kcdFeature.Atr77 != null) sw.Write(kcdFeature.Atr77 + '\r');
                        if (kcdFeature.Atr78 != null) sw.Write(kcdFeature.Atr78 + '\r');
                        if (kcdFeature.Atr79 != null) sw.Write(kcdFeature.Atr79 + '\r');
                        if (kcdFeature.Atr94 != null) sw.Write(kcdFeature.Atr94 + '\r');

                        if (kcdFeature.AtrW != null) sw.Write(kcdFeature.AtrW + '\r');
                    }
                }

                if (featureCount > 0) sw.Write(":FK" + '\r');
            }

            Console.WriteLine(@"Koniec");
            Console.ReadKey();
        }
    }
}
