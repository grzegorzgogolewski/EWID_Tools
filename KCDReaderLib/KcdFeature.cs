using System.Collections.Generic;

namespace KCDReader
{
    public class KcdFeature
    {
        public string AtrKodObiektu { get; set; }
        public string AtrC { get; set; }
        public string AtrG { get; set; }
        public string AtrM { get; set; }
        public string AtrS { get; set; }
        public string AtrK { get; set; }    //  KERG, OPERAT, IDMAT
        public string Atr333 { get; set; }
        public string AtrI { get; set; }
        public List<string> AtrP { get; set; } = new List<string>();
        public List<string> AtrW { get; set; } = new List<string>();
        public string AtrO { get; set; }
        public string Atr1 { get; set; }
        public string Atr2 { get; set; }
        public string Atr3 { get; set; }
        public string Atr4 { get; set; }
        public string Atr6 { get; set; }
        public string Atr7 { get; set; }
        public string Atr8 { get; set; }
        public string Atr11 { get; set; }
        public string Atr15 { get; set; }
        public string Atr16 { get; set; }   //  Źródło danych o położeniu (16)
        public string Atr17 { get; set; }
        public string Atr18 { get; set; }
        public string Atr19 { get; set; }
        public string Atr40 { get; set; }
        public string Atr41 { get; set; }
        public string Atr73 { get; set; }   //  Data pomiaru (73)
        public string Atr76 { get; set; }
        public string Atr77 { get; set; }
        public string Atr78 { get; set; }
        public string Atr79 { get; set; }
        public string Atr81 { get; set; }
        public string Atr84 { get; set; }
        public string Atr86 { get; set; }
        public string Atr87 { get; set; }
        public string Atr88 { get; set; }
        public string Atr89 { get; set; }
        public string Atr91 { get; set; }
        public string Atr92 { get; set; }
        public string Atr93 { get; set; }
        public string Atr94 { get; set; }
        public string Atr103 { get; set; }
        public string Atr109 { get; set; }
        public string Atr110 { get; set; }
        public string Atr113 { get; set; }
        public string Atr255 { get; set; }
        public string Atr990 { get; set; }
        public string Atr991 { get; set; }
        public string Atr995 { get; set; }

        public int AtrDuplicatesCount { get; set; }
    }
}
