using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Datos
{
    public class BaseDatos
    {
        public static string Cadena = ConfigurationManager.AppSettings["sistemaConnectionString1"];

        private static string DataSource = "localhost";
        private static string InitialCatalog = "sistema";
        private static bool IntegratedSecurity = true;
        private static int ConnectTimeout = 30;

        //private static String cadenasql;
            public static String CadenaSQL
            {
                get
                {
                    SqlConnectionStringBuilder csb = new SqlConnectionStringBuilder();

                    csb.DataSource = DataSource;
                    csb.InitialCatalog = BaseDatos.InitialCatalog;
                    csb.IntegratedSecurity = BaseDatos.IntegratedSecurity;
                    csb.ConnectTimeout = BaseDatos.ConnectTimeout;

                    return csb.ConnectionString;
                }
            }

                
        public static string Sistema = ConfigurationManager.AppSettings["SistemaDirectorio"];
        public static string BD = ConfigurationManager.AppSettings["SistemaDirectorio"].ToString();


        public BaseDatos()
        { }


       
    }
}
