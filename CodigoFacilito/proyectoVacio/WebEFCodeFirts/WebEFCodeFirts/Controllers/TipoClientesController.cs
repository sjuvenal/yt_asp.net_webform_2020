using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEFCodeFirts.Models;

namespace WebEFCodeFirts.Controllers
{
    public class TipoClientesController : Controller
    {
        ContextoAplicacion db = new ContextoAplicacion();
        // GET: TipoClientes
        public ActionResult Index()
        {
            return Json(db.Tipos.ToList(),JsonRequestBehavior.AllowGet) ;
        }

        public string Crear(string nombreTipo) 
        {
            if (nombreTipo != null)
            {
                TipoCliente tipoCliente = new TipoCliente();
                tipoCliente.NombreTipo = nombreTipo;
                db.Tipos.Add(tipoCliente);
                db.SaveChanges();
                return "Se agrego correctamente";
            }
            else
                return "El nombre del tipo no es correcto";
        }

        public string Modificar(int id, string nombreTipo)
        {
            if (nombreTipo != null)
            {
                TipoCliente tipoCliente = db.Tipos.Find(id);
                if (tipoCliente != null)
                {
                    tipoCliente.NombreTipo = nombreTipo;
                    db.Entry(tipoCliente).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    return "El registro se modifico de manera correcta";
                }
                else
                    return "No existe este tipo de cliente";
            }
            else
                return "No existe datos, para consultar";
        }
    }
}