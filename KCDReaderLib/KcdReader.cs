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

                            case "o":
                                kcdFeature.AtrO = kcdLine;
                                break;

                            case "a":

                                int comaPos = kcdLine.IndexOf(',');
                                string atr = kcdLine.Substring(0, comaPos);

                                switch (atr)
                                {
                                    case "a6":
                                        kcdFeature.Atr6 = kcdLine;
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

                                    case "a94":
                                        kcdFeature.Atr94 = kcdLine;
                                        break;

                                    case "a333":
                                        kcdFeature.Atr333 = kcdLine;
                                        break;

                                    default:
                                        //Console.WriteLine($"Nierozpoznany typ atrybutu: {atr}");
                                        break;
                                }

                                break;

                            case "w":
                                kcdFeature.AtrW = kcdLine;
                                break;

                            default:
                                //Console.WriteLine($"Nierozpoznany typ rodzaju atrybutu: {kcdLine.Substring(0, 1)}");
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

        public int KcdFeaturesCount()
        {
            return _kcdFeaturesList.Count;
        }
    }
}
