using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KCDReader
{
    public class KcdObj
    {
        private string _fileName;

        public string FileName { get => _fileName; set => _fileName = value; }

        List<MZ_Obiekty> mzObiekty = new List<MZ_Obiekty>();

        public KcdObj(string fileName)
        {
            FileName = fileName;    
        }

        public void LoadKcd()
        {
            StreamReader fileKcd = new StreamReader(_fileName);
        }

        public List<MZ_Obiekty> GetObjectsMz()
        {
            return mzObiekty;
        }
        
    }
}
