using KCDReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WladZamien
{
    class Program
    {
        static void Main(string[] args)
        {
            KcdObj kcd = new KcdObj(args[0]);

            kcd.LoadKcd();

           

            
        }
    }
}
