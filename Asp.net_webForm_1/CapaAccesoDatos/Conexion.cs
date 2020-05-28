using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Conexion
    {
        #region "PATRON SIGLENTO"

        private static Conexion conexion = null;
        private Conexion() { }
        public static Conexion getInstance()
        {
            if (conexion == null) 
            {
                conexion = new Conexion();
            }
            return conexion;
        }
        #endregion

        public SqlConnection ConexionDB()
        {
            SqlConnection conexion = new SqlConnection();
            conexion.ConnectionString = "Data Source=LAPTOP-IJPALFOG; Initial Catalog=DBClinica_test; User Id=sa; Password=123456";
            return conexion;
        }

    }

}
