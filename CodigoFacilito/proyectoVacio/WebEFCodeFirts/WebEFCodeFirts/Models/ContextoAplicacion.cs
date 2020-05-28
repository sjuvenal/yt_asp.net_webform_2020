using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebEFCodeFirts.Models
{
    public class ContextoAplicacion : DbContext
    {
        public ContextoAplicacion():base("name=DefaultConnectionString")
        {
            //definir la actualizacion de mi base de datos
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ContextoAplicacion, Migrations.Configuration>
                ("DefaultConnectionString"));
            
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoCliente> Tipos { get; set; }

    }
}