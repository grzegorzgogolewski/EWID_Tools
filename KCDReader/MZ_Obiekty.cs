using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCDReader
{
    public class MZ_Obiekty
    {
        string nr_w;
        long nr_w_line;
        string a79;
        long a79_line;

        public string NrWarstwy { get => nr_w; set => nr_w = value; }
        public long Nr_w_line { get => nr_w_line; set => nr_w_line = value; }
        public string A79 { get => a79; set => a79 = value; }
        public long A79_line { get => a79_line; set => a79_line = value; }
        
    }
}
