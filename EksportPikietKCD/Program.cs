using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using KCDReader;

namespace EksportPikietKCD
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = args[0];
            string outputFile = Path.Combine(Path.GetDirectoryName(fileName) ?? throw new InvalidOperationException(), Path.GetFileNameWithoutExtension(fileName) + "_[pikiety].kcd");
            string logFile = Path.Combine(Path.GetDirectoryName(fileName) ?? throw new InvalidOperationException(), Path.GetFileNameWithoutExtension(fileName) + "_[pikiety].log");

            KcdReader kcdReader = new KcdReader(fileName);
            kcdReader.LoadKcd();

            List<KcdFeature> kcdFeatures = kcdReader.GetKcdFeatures();
            
            foreach (KcdFeature kcdFeature in kcdFeatures.Where(kcdFeature => string.IsNullOrEmpty(kcdFeature.AtrK)))
            {
                kcdFeature.AtrK = "brak";
            }

            Dictionary<string, int> operatyCount = kcdFeatures.Select(kcd => kcd.AtrK).Distinct().ToDictionary(o => o, o => 0);

            using (StreamWriter sw = new StreamWriter(new FileStream(outputFile, FileMode.Create), Encoding.GetEncoding(1250)))
            {
                foreach (KcdFeature kcdFeature in kcdFeatures.Where(kcdFeature =>
                    !kcdFeature.AtrKodObiektu.StartsWith(":ET") && 
                    !kcdFeature.AtrKodObiektu.StartsWith(":ES") &&
                    !kcdFeature.AtrKodObiektu.StartsWith(":EP")))
                {
                    kcdFeature.AtrP = kcdFeature.AtrP.Distinct().ToList();

                    foreach (string atrP in kcdFeature.AtrP)
                    {
                        operatyCount[kcdFeature.AtrK] = operatyCount[kcdFeature.AtrK] + 1;

                        sw.Write(":EP1902" + '\r');
                        if (!string.IsNullOrEmpty(kcdFeature.AtrK) && kcdFeature.AtrK != "brak") sw.Write(kcdFeature.AtrK + '\r');   //  KERG, OPERAT, IDMAT
                        sw.Write(atrP + '\r');
                        
                        if (!string.IsNullOrEmpty(kcdFeature.Atr15)) sw.Write(kcdFeature.Atr15 + '\r');  //  Źródło danych o położeniu SUT (15)
                        if (!string.IsNullOrEmpty(kcdFeature.Atr16)) sw.Write(kcdFeature.Atr16 + '\r');  //  Źródło danych o położeniu (16)

                        if (!string.IsNullOrEmpty(kcdFeature.Atr73)) sw.Write(kcdFeature.Atr73 + '\r');  //  Data pomiaru (73)
                        sw.Write("a103," + operatyCount[kcdFeature.AtrK]+ '\r');
                        sw.Write(atrP.Replace("p", "w") + '\r');    //  w - etykieta
                    }
                }

                sw.Write(":FK" + '\r');
            }

            using (StreamWriter sw = new StreamWriter(new FileStream(logFile, FileMode.Create), Encoding.GetEncoding(1250)))
            {
                foreach (KeyValuePair<string, int> operat in operatyCount)
                {
                    Console.WriteLine(operat.Key + ": " + operat.Value);
                    sw.WriteLine(operat.Key + ": " + operat.Value);
                }
            }

            Console.Write(@"Koniec");
            Console.ReadKey();
        }
    }
}
