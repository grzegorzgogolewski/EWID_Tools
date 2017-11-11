using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace EksportDzeGML
{
    class Program
    {
        // ReSharper disable once UnusedParameter.Local
        static void Main(string[] args)
        {
            List<string> listaDzialek = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader("listaDLK.txt"))
                {
                    while (sr.Peek() >= 0)
                    {
                        string linia = sr.ReadLine();

                        if (linia != null && linia.Length >= 15) listaDzialek.Add(linia);
                        
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Brak pliku w katalogu programu: listaDLK.txt\n");
                return;
            }

            string connectionString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.110.6)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=EWID)));User Id=ewid4;Password=2015geo;";

            using (OracleConnection conn = new OracleConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (OracleCommand cmd = new OracleCommand())
                    {
                        cmd.Connection = conn;

                        foreach (string dzialka in listaDzialek)
                        {

                            Console.Write("Wydawanie GML dla dzialki: " + dzialka + "...");

                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = "begin ewd.gml_pomin_dane_os := 1; end;";

                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "GML_EGB_DZIALKI";
                            cmd.CommandType = CommandType.StoredProcedure;

                            OracleParameter result = new OracleParameter("result", OracleDbType.Blob)
                            {
                                Direction = ParameterDirection.ReturnValue
                            };
                            cmd.Parameters.Add(result);

                            OracleParameter zapytanie = new OracleParameter("zapytanie", OracleDbType.Varchar2)
                            {
                                Direction = ParameterDirection.Input,
                                Value = "SELECT dzialka_id FROM kdzialka where zmiana_kas_id is null AND EW_DLK_IDG5(mslink) = '" + dzialka + "'"
                            };
                            cmd.Parameters.Add(zapytanie);

                            OracleParameter naDzien = new OracleParameter("na_dzien", OracleDbType.Date)
                            {
                                Direction = ParameterDirection.Input,
                                Value = DateTime.Now
                            };
                            cmd.Parameters.Add(naDzien);

                            OracleParameter xmlHeader = new OracleParameter("xml_header", OracleDbType.Int32)
                            {
                                Direction = ParameterDirection.Input,
                                Value = 1
                            };
                            cmd.Parameters.Add(xmlHeader);

                            OracleParameter danePowiazane = new OracleParameter("dane_powiazane", OracleDbType.Int32)
                            {
                                Direction = ParameterDirection.Input,
                                Value = 0
                            };
                            cmd.Parameters.Add(danePowiazane);

                            OracleParameter danePodmiotowe = new OracleParameter("dane_podmiotowe", OracleDbType.Int32)
                            {
                                Direction = ParameterDirection.Input,
                                Value = 0
                            };
                            cmd.Parameters.Add(danePodmiotowe);

                            OracleParameter wszystkiePunktyGraniczne = new OracleParameter("wszystkie_punkty_graniczne", OracleDbType.Int32)
                            {
                                Direction = ParameterDirection.Input,
                                Value = 0
                            };
                            cmd.Parameters.Add(wszystkiePunktyGraniczne);

                            OracleParameter wydajBudynki = new OracleParameter("wydaj_budynki", OracleDbType.Int32)
                            {
                                Direction = ParameterDirection.Input,
                                Value = 0
                            };
                            cmd.Parameters.Add(wydajBudynki);

                            cmd.ExecuteNonQuery();

                            OracleBlob blob = (OracleBlob)cmd.Parameters[0].Value;

                            byte[] filedata = new byte[blob.Length];

                            blob.Read(filedata, 0, Convert.ToInt32(blob.Length));

                            using (FileStream fs = new FileStream(dzialka.Replace("/", "_") + ".gml", FileMode.Create))
                            {
                                fs.Write(filedata, 0, filedata.Length);
                            }

                            cmd.Parameters.Clear();

                            Console.WriteLine("OK");
                        }

                    }

                    Console.ReadKey();

                }
                catch (OracleException ex)
                {
                    Console.WriteLine(@"Database error: " + ex.Message);
                }
                catch (Exception ex) // catches any other error
                {
                    Console.WriteLine(@"Programe error: " + ex.Message);
                }
            }
        }
    }
}
