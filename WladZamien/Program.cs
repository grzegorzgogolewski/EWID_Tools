using System;
using System.Collections.Generic;
using KCDReader;

namespace WladZamien
{
    class Program
    {
        private static void Main(string[] args)
        {
            var kcd = new KcdObj(args[0]);

            kcd.LoadKcd();

            List<MzObiekty> obiekty = kcd.GetObjectsMz();

            foreach (var obiekt in obiekty)
            {
                Console.WriteLine(obiekt.NrWarstwy);
            }

        }
    }
}
