using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaLogicaNegocios;
using CapaPresentacion.Custom;
using System.Web.Security;

namespace CapaPresentacion
{
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                Session["UserSession"] = null;
            }
        }

        protected void LoginUser_Aunthenticate(object sender, AuthenticateEventArgs e)
        {
            bool auth = Membership.ValidateUser(LoginUser.UserName, LoginUser.Password);

            if (auth)
            {
                Empleado objEmpleado = EmpleadoLN.getInstance().AccesoSistema(LoginUser.UserName, LoginUser.Password);

                if (objEmpleado != null)
                {
                    SessionManager _SessionManager = new SessionManager(Session);
                    //SessionManager.UserSessionId = objEmpleado.ID.ToString();
                    _SessionManager.UserSessionEmpleado = objEmpleado;
                    FormsAuthentication.RedirectFromLoginPage(LoginUser.UserName, false);
                }
                else
                {
                    Response.Write("<script>alert('USUARIO INCORRECTO.')</script>");
                }
            }
        }

        //protected void btnIngresar_Click(object sender, EventArgs e)
        //{

        //    Empleado objEmpleado = EmpleadoLN.getInstance().AccesoSistema(txtUsuario.Text, txtPassword.Text);

        //    if (objEmpleado != null)
        //    {
        //        Response.Write("<script>alert('Uusario correcto')</script>");
        //        Response.Redirect("PanelGeneral.aspx");
        //    }
        //    else 
        //    {
        //        Response.Write("<script>alert('Uusario Incorrecto')</script>");

        //    }
        //    //if (user.Equals(userName) && password.Equals(passNanme))
        //    //{
        //    //    Response.Write("<script>alert('USUARIO CORRECTO')</script>");
        //    //}
        //    //else
        //    //{
        //    //    Response.Write("<script>alert('USUARIO INCORRECTO')</script>");
        //    //}
        //}
    }
}