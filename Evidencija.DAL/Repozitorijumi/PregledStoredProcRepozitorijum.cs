using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using evidencijaRVS.Evidencija.DAL.Models;

namespace Evidencija.DAL.Repozitorijumi
{
    public class PregledStoredProcRepozitorijum : SqlBaseRepozitorijum
    {
        

        protected readonly string _connectionString;

      
       public PregledStoredProcRepozitorijum(string connectionString)
      : base(connectionString)
        {
        }
        

        public List<Pregled> PreuzmiPomocuStoredProcedure(
            DateTime? datumOd = null,
            DateTime? datumDo = null,
            bool? hitanSlucaj = null,
            string prioritet = null)
        {
            var lista = new List<Pregled>();

            using (SqlConnection konekcija = KreirajKonekciju())
            using (SqlCommand komanda = new SqlCommand("sp_SviPregledi", konekcija))
            {
                komanda.CommandType = CommandType.StoredProcedure;

                komanda.Parameters.Add("@DatumOd", SqlDbType.DateTime2).Value =
                    datumOd.HasValue ? datumOd.Value : DBNull.Value;
                komanda.Parameters.Add("@DatumDo", SqlDbType.DateTime2).Value =
                    datumDo.HasValue ? datumDo.Value : DBNull.Value;
                komanda.Parameters.Add("@HitanSlucaj", SqlDbType.Bit).Value =
                    hitanSlucaj.HasValue ? hitanSlucaj.Value : DBNull.Value;
                komanda.Parameters.Add("@Prioritet", SqlDbType.NVarChar, -1).Value =
                    string.IsNullOrWhiteSpace(prioritet) ? DBNull.Value : prioritet;

                konekcija.Open();
                using (SqlDataReader reader = komanda.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Pregled
                        {
                            pregled_id = Convert.ToInt32(reader["pregled_id"]),
                            anamneza_id = Convert.ToInt32(reader["anamneza_id"]),
                            telesna_temperatura = Convert.ToDecimal(reader["telesna_temperatura"]),
                            dijagnoza = reader["dijagnoza"]?.ToString() ?? string.Empty,
                            terapija = reader["terapija"]?.ToString() ?? string.Empty,
                            hitanslucaj = Convert.ToBoolean(reader["hitanslucaj"]),
                            prioritetpregleda = reader["prioritetpregleda"]?.ToString() ?? string.Empty,
                            datumpregleda = Convert.ToDateTime(reader["datumpregleda"])

                        });
                        }
                    }
                }
            

            return lista;
        }
    }
}







