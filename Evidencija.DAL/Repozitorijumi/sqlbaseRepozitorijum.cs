using Microsoft.Data.SqlClient;

namespace Evidencija.DAL.Repozitorijumi
{
    public abstract class SqlBaseRepozitorijum
    {
        protected readonly string _connectionString;

        protected SqlBaseRepozitorijum()
        {
            
            _connectionString = "Server=DESKTOP-6DP45N3;Database=evidencijarvs;Trusted_Connection=True;TrustServerCertificate=True";
        }

        protected SqlConnection KreirajKonekciju()
        {
            return new SqlConnection(_connectionString);
        }
    }
}