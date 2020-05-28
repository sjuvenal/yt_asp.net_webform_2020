using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;


namespace CapaAccesoDatos
{
    public class FacturaDAO
    {
        #region "PATRON SINGLETON"
        private static FacturaDAO daoFactura = null;
        private FacturaDAO() { }
        public static FacturaDAO getInstance()
        {
            if (daoFactura == null)
            {
                daoFactura = new FacturaDAO();
            }
            return daoFactura;
        }
        #endregion
        public bool RegistrarFactura(string idCliente, string Fecha, string Detalle)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            bool response = false;
            try
            {
                con = Conexion.getInstance().ConexionDB();

                cmd = new SqlCommand("spRegistrarFactura", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmIdCliente", idCliente);
                cmd.Parameters.AddWithValue("@prmMonto", 1);
                cmd.Parameters.AddWithValue("@prmIdVendedor", 1);
                cmd.Parameters.AddWithValue("@prmFchVenta", Fecha);
                cmd.Parameters.AddWithValue("@idFactura", 0).Direction = ParameterDirection.Output;

                con.Open();

                int filas = cmd.ExecuteNonQuery();

                if (filas > 0) response = true;

                int idFactura = (int)cmd.Parameters["@idFactura"].Value;

                JavaScriptSerializer js = new JavaScriptSerializer();
                ListaDetalleFactura[] detalle = js.Deserialize<ListaDetalleFactura[]>(Detalle);

                int iContador = 0;
                foreach (ListaDetalleFactura miDatoDet in detalle)
                {
                    iContador += 1;
                    cmd = new SqlCommand("spRegistrarFacturaDetalle", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PrmIdFactura", idFactura);
                    cmd.Parameters.AddWithValue("@prmIdProducto", miDatoDet.idProducto);
                    cmd.Parameters.AddWithValue("@prmPrecio", miDatoDet.Precio);
                    cmd.Parameters.AddWithValue("@prmSubTotal", miDatoDet.Precio);
                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                response = false;
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return response;
        }

        public class ListaDetalleFactura
        {
            public string idProducto { set; get; }
            public string Producto { set; get; }
            public string Precio { set; get; }
        }
    }
}
