using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using evidencijaRVS.Evidencija.DAL.Models;

namespace Evidencija.DAL.Repozitorijumi
{
    public class PregledStoredProcRepozitorijum : SqlBaseRepozitorijum
    {
        public List<Pregled> PreuzmiPomocuStoredProcedure()
        {
            var lista = new List<Pregled>();

            using (SqlConnection konekcija = KreirajKonekciju())
            {
                using (SqlCommand komanda = new SqlCommand("sp_SviPregledi", konekcija))
                {
                    komanda.CommandType = CommandType.StoredProcedure;
                    konekcija.Open();
                    using (SqlDataReader reader = komanda.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Pregled
                            {
                                pregled_id = Convert.ToInt32(reader["pregled_id"]),
                                dijagnoza = reader["dijagnoza"]?.ToString() ?? string.Empty
                            });
                        }
                    }
                }
            }

            return lista;
        }
    }
}







