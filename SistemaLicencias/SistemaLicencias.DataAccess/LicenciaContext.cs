using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SistemaLicencias.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaLicencias.DataAccess
{
    public class LicenciaContext : SistemadelicenciasContext
    {
       
        public static string ConnectionString { get; set; }

        public LicenciaContext()
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public static void BuildConnectionString(string connection)
        {
            var connectionStringBuilder = new SqlConnectionStringBuilder { ConnectionString = connection };
            ConnectionString = connectionStringBuilder.ConnectionString;
        }

       
    }
}
