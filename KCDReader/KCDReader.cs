using System;
using System.Collections.Generic;
using System.IO;

namespace KCDReader
{
    public class KcdObj
    {
        public string FileName { get; set; }

        readonly List<MzObiekty> _mzObiekty = new List<MzObiekty>();

        public KcdObj(string fileName)
        {
            FileName = fileName;    
        }

        public void LoadKcd()
        {
            try
            {
                using (StreamReader kcdFile = new StreamReader(FileName))
                {
                    string lineKcd;
                    long lineNumber = 0;

                    while ((lineKcd = kcdFile.ReadLine()) != null)
                    {
                        lineNumber++;

                        if (lineKcd.StartsWith(":"))
                        {
                            MzObiekty obiekt = new MzObiekty();

                            obiekt.NrWarstwy = lineKcd.Substring(1);
                            obiekt.NrWarstwyLine = lineNumber;

                            _mzObiekty.Add(obiekt);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }

        public List<MzObiekty> GetObjectsMz()
        {
            return _mzObiekty;
        }
        
    }
}
