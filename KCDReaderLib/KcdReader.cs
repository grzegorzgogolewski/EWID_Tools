using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace KCDReader
{
    public class KcdReader
    {
        private readonly string _fileName;
        private readonly List<string> _kcdHeader = new List<string>();
        private readonly List<KcdFeature> _kcdFeaturesList = new List<KcdFeature>();

        public KcdReader(string fileName)
        {
            _fileName = fileName;
        }

        public void LoadKcd()
        {
            string[] kcdAllLines = File.ReadAllLines(_fileName, Encoding.GetEncoding(1250));

            KcdFeature kcdFeature = new KcdFeature();

            foreach (string kcdLine in kcdAllLines)
            {
                if (kcdLine.StartsWith(":E") || kcdLine.StartsWith(":FK"))
                {
                    if (kcdFeature.AtrKodObiektu != null)
                    {
                        Dictionary<string, int> duplicates = kcdFeature.AtrP.GroupBy(x => x).Where(g => g.Count() > 1).ToDictionary(x => x.Key, y => y.Count());
                        kcdFeature.AtrDuplicatesCount = duplicates.Count;

                        _kcdFeaturesList.Add(kcdFeature);
                    }

                    kcdFeature = new KcdFeature
                    {
                        AtrKodObiektu = kcdLine
                    };
                }
                else
                {
                    if (_kcdFeaturesList.Count == 0 && kcdFeature.AtrKodObiektu == null)
                    {
                        _kcdHeader.Add(kcdLine);
                    }
                    else
                    {
                        switch (kcdLine.Substring(0, 1))
                        {
                            case "c":
                                kcdFeature.AtrC = kcdLine;
                                break;

                            case "g":
                                kcdFeature.AtrG = kcdLine;
                                break;

                            case "m":
                                kcdFeature.AtrM = kcdLine;
                                break;

                            case "s":
                                kcdFeature.AtrS = kcdLine;
                                break;

                            case "k":
                                kcdFeature.AtrK = kcdLine;
                                break;

                            case "i":
                                kcdFeature.AtrI = kcdLine;
                                break;

                            case "p":
                                kcdFeature.AtrP.Add(kcdLine);
                                break;

                            case "w":
                                kcdFeature.AtrW.Add(kcdLine);
                                break;

                            case "o":
                                kcdFeature.AtrO = kcdLine;
                                break;

                            case "a":

                                int comaPos = kcdLine.IndexOf(',');
                                string atr = kcdLine.Substring(0, comaPos);

                                switch (atr)
                                {
                                    case "a1":
                                        kcdFeature.Atr1 = kcdLine;
                                        break;
                                    case "a2":
                                        kcdFeature.Atr2 = kcdLine;
                                        break;
                                    case "a3":
                                        kcdFeature.Atr3 = kcdLine;
                                        break;
                                    case "a4":
                                        kcdFeature.Atr4 = kcdLine;
                                        break;
                                    case "a6":
                                        kcdFeature.Atr6 = kcdLine;
                                        break;

                                    case "a7":
                                        kcdFeature.Atr7 = kcdLine;
                                        break;
                                    case "a8":
                                        kcdFeature.Atr8 = kcdLine;
                                        break;
                                    case "a11":
                                        kcdFeature.Atr11 = kcdLine;
                                        break;
                                    case "a15":
                                        kcdFeature.Atr15 = kcdLine;
                                        break;

                                    case "a16":
                                        kcdFeature.Atr16 = kcdLine;
                                        break;

                                    case "a17":
                                        kcdFeature.Atr17 = kcdLine;
                                        break;

                                    case "a18":
                                        kcdFeature.Atr18 = kcdLine;
                                        break;
                                    case "a19":
                                        kcdFeature.Atr19 = kcdLine;
                                        break;
                                    case "a40":
                                        kcdFeature.Atr40 = kcdLine;
                                        break;
                                    case "a41":
                                        kcdFeature.Atr41 = kcdLine;
                                        break;

                                    case "a73":
                                        kcdFeature.Atr73 = kcdLine;
                                        break;

                                    case "a77":
                                        kcdFeature.Atr77 = kcdLine;
                                        break;

                                    case "a76":
                                        kcdFeature.Atr76 = kcdLine;
                                        break;

                                    case "a78":
                                        kcdFeature.Atr78 = kcdLine;
                                        break;

                                    case "a79":
                                        kcdFeature.Atr79 = kcdLine;
                                        break;

                                    case "a81":
                                        kcdFeature.Atr81 = kcdLine;
                                        break;

                                    case "a84":
                                        kcdFeature.Atr84 = kcdLine;
                                        break;

                                    case "a86":
                                        kcdFeature.Atr86 = kcdLine;
                                        break;
                                    case "a87":
                                        kcdFeature.Atr87 = kcdLine;
                                        break;
                                    case "a88":
                                        kcdFeature.Atr88 = kcdLine;
                                        break;
                                    case "a89":
                                        kcdFeature.Atr89 = kcdLine;
                                        break;
                                    case "a91":
                                        kcdFeature.Atr91 = kcdLine;
                                        break;
                                    case "a92":
                                        kcdFeature.Atr92 = kcdLine;
                                        break;

                                    case "a93":
                                        kcdFeature.Atr93 = kcdLine;
                                        break;

                                    case "a94":
                                        kcdFeature.Atr94 = kcdLine;
                                        break;
                                    case "a103":
                                        kcdFeature.Atr103 = kcdLine;
                                        break;
                                    case "a109":
                                        kcdFeature.Atr109 = kcdLine;
                                        break;
                                    case "a110":
                                        kcdFeature.Atr110 = kcdLine;
                                        break;
                                    case "a113":
                                        kcdFeature.Atr113 = kcdLine;
                                        break;

                                    case "a255":
                                        kcdFeature.Atr255 = kcdLine;
                                        break;
                                    case "a333":
                                        kcdFeature.Atr333 = kcdLine;
                                        break;
                                    case "a990":
                                        kcdFeature.Atr990 = kcdLine;
                                        break;
                                    case "a991":
                                        kcdFeature.Atr991 = kcdLine;
                                        break;
                                    case "a995":
                                        kcdFeature.Atr995 = kcdLine;
                                        break;

                                    default:
                                        Console.WriteLine($"Nierozpoznany typ atrybutu: {atr}");
                                        break;
                                }

                                break;

                            default:
                                Console.WriteLine($"Nierozpoznany typ rodzaju atrybutu: {kcdLine.Substring(0, 1)}");
                                break;
                        }
                    }
                }
            }
        }

        public List<KcdFeature> GetKcdFeatures()
        {
            return _kcdFeaturesList;
        }

        public List<String> GetHeader()
        {
            return _kcdHeader;
        }

        public int KcdFeaturesCount()
        {
            return _kcdFeaturesList.Count;
        }
    }
}
