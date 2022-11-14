using Dapper;
using Microsoft.Data.SqlClient;
using ModelsDap.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDap.DB
{
    public class DbConnection
    {
        public static string conString;

        public DbConnection()
        {
            //conString = ConfigurationManager.ConnectionStrings["Hildur"].ConnectionString;
            conString = @"Data Source=hildur.ucn.dk;User ID=DMA-CSD-S211_10407501;Password=Password1!;Database=DMA-CSD-S211_10407501;Encrypt=False;TrustServerCertificate=False";
        }

        public DbConnection(string connectionString)
        {
            conString = connectionString;
        }

    
    }
}
