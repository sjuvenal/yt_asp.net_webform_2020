using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using plantillaMVC.Models;

namespace plantillaMVC.Controllers
{
    public class ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Clientes
        public ActionResult Index()
        {
            BusquedaClienteModelView cliente = new BusquedaClienteModelView();
            //return View(db.Clientes.ToList());
            return View(cliente);
        }

        [HttpPost]
        public ActionResult BuscarNombre(BusquedaClienteModelView model)
        {
            if (ModelState.IsValid)
            {
                ClientesViewModel clientes = new ClientesViewModel();
                clientes.BuscarPorNombre(model.NombreBuscar);
                return PartialView("_ListadoClientes", clientes.Clientes);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View("index", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarEmail(BusquedaClienteModelView model)
        {
            if (ModelState.IsValid)
            {
                ClientesViewModel clientes = new ClientesViewModel();
                clientes.BuscarPorEmail(model.NombreBuscar);
                return PartialView("_ListadoClientes", clientes.Clientes);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View("index", model);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarTelefono(BusquedaClienteModelView model)
        {
            if (ModelState.IsValid)
            {
                ClientesViewModel clientes = new ClientesViewModel();
                clientes.BuscarPorTelefono(model.NombreBuscar);
                return PartialView("_ListadoClientes", clientes.Clientes);
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return View("index", model);
            }
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            db.Entry(cliente).Reference("Tipo").Load();
            db.Entry(cliente).Collection(p => p.Telefonos).Load();
            db.Entry(cliente).Collection(p => p.Correos).Load();
            db.Entry(cliente).Collection(p => p.Direcciones).Load();

            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {

            var list = new SelectList(new[]
                                            {
                                                new { ID = "",Name ="--SELECCIONE EL TIPO DE PERSONA"},
                                                new { ID = "PERSONA FISICA",Name ="PERSONA FISICA"},
                                                new { ID = "PERSONA MORAL",Name ="PERSONA MORAL"},
                                            },
                "ID", "Name", 1);
            var tipo = new SelectList(db.TipoClientes.ToList(), "TipoClienteId", "NombreTipo");
            ViewData["list"] = list;
            ViewData["tipos"] = tipo;
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        /*
        public ActionResult Create([Bind(Include = "ClienteId,Nombre,RFC,TipoPersonSat,TipoClienteId")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cliente);
        }
        */
        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }

            db.Entry(cliente).Collection(p => p.Telefonos).Load();
            db.Entry(cliente).Collection(p => p.Correos).Load();
            db.Entry(cliente).Collection(p => p.Direcciones).Load();

            var list = new SelectList(new[]
                                           {
                                                new { ID = "",Name ="--SELECCIONE EL TIPO DE PERSONA"},
                                                new { ID = "PERSONA FISICA",Name ="PERSONA FISICA"},
                                                new { ID = "PERSONA MORAL",Name ="PERSONA MORAL"},
                                            },
               "ID", "Name", 1);
            var tipo = new SelectList(db.TipoClientes.ToList(), "TipoClienteId", "NombreTipo");
            ViewData["list"] = list;
            ViewData["tipos"] = tipo;

            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                Cliente clienteModificar = db.Clientes.Find(cliente.ClienteId);
                db.Entry(clienteModificar).Collection(p => p.Telefonos).Load();
                db.Entry(clienteModificar).Collection(p => p.Correos).Load();
                db.Entry(clienteModificar).Collection(p => p.Direcciones).Load();
                ProcesaTelefonos(cliente, clienteModificar);
                ProcesaEmail(cliente, clienteModificar);
                ProcesaDireccion(cliente, clienteModificar);

                clienteModificar.Nombre = cliente.Nombre;
                clienteModificar.TipoClienteId = cliente.TipoClienteId;
                clienteModificar.RFC = cliente.RFC;
                clienteModificar.TipoPersonSat = cliente.TipoPersonSat;
                db.Entry(clienteModificar).State = EntityState.Modified;
                db.SaveChanges();
                return Json(true);
            }
            return Json(false);
        }

        private void ProcesaTelefonos(Cliente cliente, Cliente clienteModificar)
        {
            var telefonosExistentes = new List<Telefono>();
            if (clienteModificar.Telefonos != null)
                telefonosExistentes = clienteModificar.Telefonos.ToList<Telefono>();
            var telefonosModificados = new List<Telefono>();
            if (cliente.Telefonos != null)
                telefonosModificados = cliente.Telefonos.ToList<Telefono>();
            var telefonosAgregar = telefonosModificados.Except(telefonosExistentes);
            var telefonosEliminar = telefonosExistentes.Except(telefonosModificados);

            telefonosEliminar.ToList<Telefono>().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);

            foreach (Telefono telefono in telefonosAgregar)
            {
                clienteModificar.Telefonos.Add(telefono);
            }
        }

        private void ProcesaEmail(Cliente cliente, Cliente clienteModificar)
        {
            var emailExistentes = new List<Email>();
            if (clienteModificar.Correos != null)
                emailExistentes = clienteModificar.Correos.ToList<Email>();
            var emailModificados = new List<Email>();
            if (cliente.Correos != null)
                emailModificados = cliente.Correos.ToList<Email>();
            var emailAgregar = emailModificados.Except(emailExistentes);
            var emailEliminar = emailExistentes.Except(emailModificados);

            emailEliminar.ToList<Email>().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);

            foreach (Email telefono in emailAgregar)
            {
                clienteModificar.Correos.Add(telefono);
            }
        }


        private void ProcesaDireccion(Cliente cliente, Cliente clienteModificar)
        {
            var direccionesExistentes = new List<Direccion>();
            if (clienteModificar.Correos != null)
                direccionesExistentes = clienteModificar.Direcciones.ToList<Direccion>();
            var direccionesModificados = new List<Direccion>();
            if (cliente.Correos != null)
                direccionesModificados = cliente.Direcciones.ToList<Direccion>();
            var direccionesAgregar = direccionesModificados.Except(direccionesExistentes);
            var direccionesEliminar = direccionesExistentes.Except(direccionesModificados);

            direccionesEliminar.ToList<Direccion>().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);

            foreach (Direccion telefono in direccionesAgregar)
            {
                clienteModificar.Direcciones.Add(telefono);
            }
        }



        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Entry(cliente).Collection(p => p.Telefonos).Load(); //solo actualiza en cascada
            cliente.Telefonos.ToList<Telefono>().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted); //elimna todos los registros
            db.Entry(cliente).Collection(p => p.Correos).Load(); //solo actualiza en cascada, quiere decir que el campo de clienteId = null
            cliente.Correos.ToList<Email>().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted); //elimna por completo todos los registros relacionados con el cliente
            db.Entry(cliente).Collection(p => p.Direcciones).Load();
            cliente.Correos.ToList<Email>().ForEach(t => db.Entry(t).State = System.Data.Entity.EntityState.Deleted);

            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
