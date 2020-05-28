using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace plantillaMVC.Models
{
    public class ClientesViewModel
    {
        private ApplicationDbContext contexto;
        public ClientesViewModel()
        {
            contexto = new ApplicationDbContext();
            Clientes = new List<ClientesBusqueda>();
        }
        public List<ClientesBusqueda> Clientes { get; set; }

        public void BuscarPorNombre(string busqueda)
        {
            var consulta = from c in contexto.Clientes
                           where c.Nombre.Contains(busqueda)
                           select new
                           {
                               c.ClienteId,
                               c.RFC,
                               c.TipoPersonSat,
                               Tipo = c.Tipo.NombreTipo ?? "",
                               NombreCliente = c.Nombre,
                               NombreContacto = c.ContactoCliente.NombreCompleto ?? c.Nombre,
                               Correo = (from t in c.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Telefono = (from t in c.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Direccion = (from d in c.Direcciones
                                            where d.Principal
                                            select d.Calle + "" + d.NumExterior + " " + d.Colonia).FirstOrDefault() ?? ""
                           };

            Clientes.Clear();
            if(consulta != null)
            {
                var lclientes = consulta.ToList();
                foreach(var item in lclientes)
                {
                    Clientes.Add(new ClientesBusqueda
                    {
                        ClienteId = item.ClienteId,
                        Nombre = item.NombreCliente,
                        NombreContacto = item.NombreContacto,
                        RFC = item.RFC,
                        Tipo = item.Tipo,
                        TipoPersonaSat = item.TipoPersonSat,
                        Email = item.Correo,
                        Telefono = item.Telefono,
                        Direccion = item.Direccion
                    });
                }
            }
        }

        public void BuscarPorEmail (string email)
        {
            var consulta = from cl in contexto.Clientes
                           where cl.ClienteId ==
                           (from e in cl.Correos
                            where e.Direccion == email
                            select cl.ClienteId).FirstOrDefault()
                           select new
                           {
                               cl.ClienteId,
                               cl.RFC,
                               cl.TipoPersonSat,
                               Tipo = cl.Tipo.NombreTipo ?? "",
                               NombreCliente = cl.Nombre,
                               NombreContacto = cl.ContactoCliente.NombreCompleto ?? cl.Nombre,
                               Correo = (from t in cl.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Telefono = (from t in cl.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Direccion = (from d in cl.Direcciones
                                            where d.Principal
                                            select d.Calle + "" + d.NumExterior + " " + d.Colonia).FirstOrDefault() ?? ""
                           };

            Clientes.Clear();
            if (consulta != null)
            {
                var lclientes = consulta.ToList();
                foreach (var item in lclientes)
                {
                    Clientes.Add(new ClientesBusqueda
                    {
                        ClienteId = item.ClienteId,
                        Nombre = item.NombreCliente,
                        NombreContacto = item.NombreContacto,
                        RFC = item.RFC,
                        Tipo = item.Tipo,
                        TipoPersonaSat = item.TipoPersonSat,
                        Email = item.Correo,
                        Telefono = item.Telefono,
                        Direccion = item.Direccion
                    });
                }
            }
        }

        public void BuscarPorTelefono(string telefono)
        {
            var consulta = from cl in contexto.Clientes
                           where cl.ClienteId ==
                           (from e in cl.Telefonos
                            where e.NumeroTelefonico == telefono
                            select cl.ClienteId).FirstOrDefault()
                           select new
                           {
                               cl.ClienteId,
                               cl.RFC,
                               cl.TipoPersonSat,
                               Tipo = cl.Tipo.NombreTipo ?? "",
                               NombreCliente = cl.Nombre,
                               NombreContacto = cl.ContactoCliente.NombreCompleto ?? cl.Nombre,
                               Correo = (from t in cl.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Telefono = (from t in cl.Telefonos where t.Principal select t.NumeroTelefonico).FirstOrDefault() ?? "",
                               Direccion = (from d in cl.Direcciones
                                            where d.Principal
                                            select d.Calle + "" + d.NumExterior + " " + d.Colonia).FirstOrDefault() ?? ""
                           };

            Clientes.Clear();
            if (consulta != null)
            {
                var lclientes = consulta.ToList();
                foreach (var item in lclientes)
                {
                    Clientes.Add(new ClientesBusqueda
                    {
                        ClienteId = item.ClienteId,
                        Nombre = item.NombreCliente,
                        NombreContacto = item.NombreContacto,
                        RFC = item.RFC,
                        Tipo = item.Tipo,
                        TipoPersonaSat = item.TipoPersonSat,
                        Email = item.Correo,
                        Telefono = item.Telefono,
                        Direccion = item.Direccion
                    });
                }
            }
        }
    }
}