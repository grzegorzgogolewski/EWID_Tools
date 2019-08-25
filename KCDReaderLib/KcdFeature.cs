using System.Collections.Generic;

namespace KCDReader
{
    public class KcdFeature
    {
        public string AtrKodObiektu { get; set; }
        public string AtrC { get; set; }
        public string AtrM { get; set; }
        public string AtrS { get; set; }
        public string AtrK { get; set; }    //  KERG, OPERAT, IDMAT
        public string Atr333 { get; set; }
        public string AtrI { get; set; }
        public List<string> AtrP { get; set; } = new List<string>();
        public string AtrO { get; set; }
        public string Atr6 { get; set; }
        public string Atr15 { get; set; }
        public string Atr16 { get; set; }   //  Źródło danych o położeniu (16)
        public string Atr17 { get; set; }
        public string Atr18 { get; set; }
        public string Atr73 { get; set; }   //  Data pomiaru (73)
        public string Atr76 { get; set; }
        public string Atr77 { get; set; }
        public string Atr78 { get; set; }
        public string Atr79 { get; set; }
        public string Atr94 { get; set; }
        public string AtrW { get; set; }
        public int AtrDuplicatesCount { get; set; }
    }

}
