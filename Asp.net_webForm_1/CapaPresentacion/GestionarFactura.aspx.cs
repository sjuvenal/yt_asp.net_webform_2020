using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicaNegocios;
using CapaEntidades;
using System.Web.Script.Serialization;

namespace CapaPresentacion
{
    public partial class GestionarFactura : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarCombos();
            }
        }

        [WebMethod]
        public static List<Paciente> PromocionDetList(string cod_promocion)
        {
            List<Paciente> Lista = null;
            try
            {
                Lista = PacienteLN.getInstance().ListarPacientes();
            }
            catch (Exception ex)
            {
                Lista = null;
            }
            return Lista;
        }

        private void LlenarCombos()
        {
            List<Especialidad> Lista = EspecialidadLN.getInstance().Listar();

            ddlCliente.DataSource = Lista;
            ddlCliente.DataValueField = "IdEspecialidad";
            ddlCliente.DataTextField = "Descripcion";
            ddlCliente.DataBind();

            ddlProducto.DataSource = Lista;
            ddlProducto.DataValueField = "IdEspecialidad";
            ddlProducto.DataTextField = "Descripcion";
            ddlProducto.DataBind();
        }


        [WebMethod]
        public static bool InsertarFactura(string idCliente, string Fecha,string Detalle)
        {
            bool response = FacturaLN.getInstance().RegistrarFactura(idCliente, Fecha, Detalle);
            return response;
        }

  

    }
}