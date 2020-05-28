using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEFCodeFirts.Models;

namespace WebEFCodeFirts.Controllers
{
    public class ClientesController : Controller
    {
        ContextoAplicacion db = new ContextoAplicacion();
        // GET: Clientes
        public ActionResult Index()
        {
            var consulta = from c in db.Clientes
                           select
                           new
                           {
                               id=c.ClienteId,
                               NombreCliente=c.Nombre,
                               Tipo=c.Tipo.NombreTipo
                           };
            return Json(consulta.ToList(), JsonRequestBehavior.AllowGet);
        }

        public string Crear(int idTipo, string nombreCliente)
        { 
            
            if(nombreCliente!=null)
            {
                var tipoCliente = db.Tipos.Find(idTipo);
                if(tipoCliente!=null)
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = nombreCliente;
                    cliente.Tipo = tipoCliente;
                    db.Clientes.Add(cliente);
                    db.SaveChanges();
                    return "El registro de" + nombreCliente + ", se a agregado correctamente";
                }
                else
                    return "El tipo de cliente no existe";
            }
            else
                return "Ingrese los datos correspondiente";

        }

        public string Modificar(int idCliente, string nombreCliente)
        {

            return "";
        }
    }
}