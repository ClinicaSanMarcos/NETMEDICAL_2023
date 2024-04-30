using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;



namespace Sigesoft.Node.WinClient.UI
{
    public class ConnectionHelperSige
    {

        /// <summary>
        /// Obtiene la cadena de conexion del App.Config
        /// </summary>
        private static string ConnectionString
        {
            get
            {
                var csConf = ConfigurationManager.ConnectionStrings["SigesoftConnectionString2"];
                return csConf != null ? csConf.ConnectionString : string.Empty;

            }
        }

        private static string ConnectionStringSAM
        {
            get
            {
                var csConf = ConfigurationManager.ConnectionStrings["ContasolConnectionString"];
                return csConf != null ? csConf.ConnectionString : string.Empty;
            }
        }

        public static IDbConnection GetConnectionSAM
        {
            get
            {
                return new SqlConnection(ConnectionStringSAM);
            }
        }
        /// <summary>
        /// Obtiene una conexión nativa para consultas rápidas a la bd de Contasol.
        /// </summary>
        public static IDbConnection GetConnection
        {
            get
            {
                return new SqlConnection(ConnectionString);
            }
        }
        private static string ConnectionStringTIS
        {
            get
            {
                var csConf = ConfigurationManager.ConnectionStrings["ConnectionTIS_INTEGRADO"];
                return csConf != null ? csConf.ConnectionString : string.Empty;
            }
        }

        public static IDbConnection GetConnectionTIS
        {
            get
            {
                return new SqlConnection(ConnectionStringTIS);
            }
        }
    }
}
