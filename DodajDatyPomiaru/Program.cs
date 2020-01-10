using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCDReader;

namespace DodajDatyPomiaru
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            string inputFileName = args[0];
            string outputFileName = Path.Combine(Path.GetDirectoryName(inputFileName) ?? throw new InvalidOperationException(), Path.GetFileNameWithoutExtension(inputFileName) + "_[daty].kcd");
            string paramFileName = args[1];

            KcdReader kcdReader = new KcdReader(inputFileName);
            kcdReader.LoadKcd();
            List<KcdFeature> kcdFeatures = kcdReader.GetKcdFeatures();

            using (StreamWriter sw = new StreamWriter(new FileStream(outputFileName, FileMode.Create), Encoding.GetEncoding(1250)))
            {
                foreach (string header in kcdReader.GetHeader())
                {
                    sw.Write(header + '\r');
                }

                foreach (KcdFeature kcdFeature in kcdFeatures)
                {
                    sw.Write(kcdFeature.AtrKodObiektu + '\r');

                    if (kcdFeature.AtrC != null) sw.Write(kcdFeature.AtrC + '\r');
                    if (kcdFeature.AtrG != null) sw.Write(kcdFeature.AtrG + '\r');
                    if (kcdFeature.AtrM != null) sw.Write(kcdFeature.AtrM + '\r');
                    if (kcdFeature.AtrS != null) sw.Write(kcdFeature.AtrS + '\r');
                    if (kcdFeature.AtrK != null) sw.Write(kcdFeature.AtrK + '\r');
                    if (kcdFeature.AtrI != null) sw.Write(kcdFeature.AtrI + '\r');
                    if (kcdFeature.AtrO != null) sw.Write(kcdFeature.AtrO + '\r');

                    foreach (string atrP in kcdFeature.AtrP)
                    {
                        sw.Write(atrP + '\r');
                    }

                    if (kcdFeature.Atr1 != null) sw.Write(kcdFeature.Atr1 + '\r');
                    if (kcdFeature.Atr2 != null) sw.Write(kcdFeature.Atr2 + '\r');

                    if (kcdFeature.Atr3 != null) sw.Write(kcdFeature.Atr3 + '\r');
                    if (kcdFeature.Atr4 != null) sw.Write(kcdFeature.Atr4 + '\r');
                    if (kcdFeature.Atr6 != null) sw.Write(kcdFeature.Atr6 + '\r');
                    if (kcdFeature.Atr7 != null) sw.Write(kcdFeature.Atr7 + '\r');
                    if (kcdFeature.Atr8 != null) sw.Write(kcdFeature.Atr8 + '\r');
                    if (kcdFeature.Atr11 != null) sw.Write(kcdFeature.Atr11 + '\r');
                    if (kcdFeature.Atr15 != null) sw.Write(kcdFeature.Atr15 + '\r');
                    if (kcdFeature.Atr16 != null) sw.Write(kcdFeature.Atr16 + '\r');
                    if (kcdFeature.Atr17 != null) sw.Write(kcdFeature.Atr17 + '\r');
                    if (kcdFeature.Atr18 != null) sw.Write(kcdFeature.Atr18 + '\r');
                    if (kcdFeature.Atr19 != null) sw.Write(kcdFeature.Atr19 + '\r');
                    if (kcdFeature.Atr40 != null) sw.Write(kcdFeature.Atr40 + '\r');
                    if (kcdFeature.Atr41 != null) sw.Write(kcdFeature.Atr41 + '\r');
                    if (kcdFeature.Atr73 != null) sw.Write(kcdFeature.Atr73 + '\r');
                    if (kcdFeature.Atr76 != null) sw.Write(kcdFeature.Atr76 + '\r');
                    if (kcdFeature.Atr77 != null) sw.Write(kcdFeature.Atr77 + '\r');
                    if (kcdFeature.Atr78 != null) sw.Write(kcdFeature.Atr78 + '\r');
                    if (kcdFeature.Atr79 != null) sw.Write(kcdFeature.Atr79 + '\r');
                    if (kcdFeature.Atr81 != null) sw.Write(kcdFeature.Atr81 + '\r');
                    if (kcdFeature.Atr84 != null) sw.Write(kcdFeature.Atr84 + '\r');
                    if (kcdFeature.Atr86 != null) sw.Write(kcdFeature.Atr86 + '\r');
                    if (kcdFeature.Atr87 != null) sw.Write(kcdFeature.Atr87 + '\r');
                    if (kcdFeature.Atr88 != null) sw.Write(kcdFeature.Atr88 + '\r');
                    if (kcdFeature.Atr89 != null) sw.Write(kcdFeature.Atr89 + '\r');
                    if (kcdFeature.Atr91 != null) sw.Write(kcdFeature.Atr91 + '\r');
                    if (kcdFeature.Atr92 != null) sw.Write(kcdFeature.Atr92 + '\r');
                    if (kcdFeature.Atr93 != null) sw.Write(kcdFeature.Atr93 + '\r');
                    if (kcdFeature.Atr94 != null) sw.Write(kcdFeature.Atr94 + '\r');
                    if (kcdFeature.Atr103 != null) sw.Write(kcdFeature.Atr103 + '\r');
                    if (kcdFeature.Atr109 != null) sw.Write(kcdFeature.Atr109 + '\r');
                    if (kcdFeature.Atr110 != null) sw.Write(kcdFeature.Atr110 + '\r');
                    if (kcdFeature.Atr113 != null) sw.Write(kcdFeature.Atr113 + '\r');
                    if (kcdFeature.Atr255 != null) sw.Write(kcdFeature.Atr255 + '\r');
                    if (kcdFeature.Atr333 != null) sw.Write(kcdFeature.Atr333 + '\r');
                    if (kcdFeature.Atr990 != null) sw.Write(kcdFeature.Atr990 + '\r');
                    if (kcdFeature.Atr991 != null) sw.Write(kcdFeature.Atr991 + '\r');
                    if (kcdFeature.Atr995 != null) sw.Write(kcdFeature.Atr995 + '\r');

                    //foreach (string atrW in kcdFeature.AtrW)
                    //{
                    //    sw.Write(atrW + '\r');
                    //} 
                }

                sw.Write(":FK" + '\r');
            }

            Console.WriteLine(@"Koniec");
            Console.ReadKey();
        }
    }
}
