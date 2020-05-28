using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocios;
using System.Web.Services;

namespace CapaPresentacion
{
    public partial class frmGestionarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }
        private Paciente GetEntity()
        {
            Paciente objPaciente = new Paciente();
            objPaciente.IdPaciente = 0;
            objPaciente.Nombres = txtNombres.Text;
            objPaciente.ApPaterno = txtPaterno.Text;
            objPaciente.ApMaterno = txtMaterno.Text;
            objPaciente.Edad = Convert.ToInt32(txtEdad.Text);
            objPaciente.Sexo = (ddlSexo.SelectedValue == "Femenino") ? 'F' : 'M';
            objPaciente.NroDocumento = txtNroDocumento.Text;
            objPaciente.Telefono = txtTelefono.Text;
            objPaciente.Direccion = txtDireccion.Text;
            objPaciente.Estado = true;

            return objPaciente;
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Registro del paciente
            Paciente objPaciente = GetEntity();
            // enviar a la capa de logica de negocio
            bool response = PacienteLN.getInstance().RegistrarPaciente(objPaciente);

            if (response == true)
            {
                Response.Write("<script>alert('REGISTRO CORRECTO.')</script>");

            }
            else
            {
                Response.Write("<script>alert('REGISTRO INCORRECTO.')</script>");

            }
        }

        [WebMethod]
        public static List<Paciente> ListarPacientes()
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

        [WebMethod]
        public static  bool ActualizarDatosPaciente(string id, string direccion)
        {
            Paciente objPaciente = new Paciente()
            {
                IdPaciente = Convert.ToInt32(id),
                Direccion = direccion
            };

            bool ok = PacienteLN.getInstance().Actualizar(objPaciente);
            return ok;
        }

        [WebMethod]
        public static bool EliminarDatosPaciente(String id)
        {
            Int32 idPaciente = Convert.ToInt32(id);

            bool ok = PacienteLN.getInstance().Eliminar(idPaciente);

            return ok;

        }
    }
}