using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebEFCodeFirts.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public TipoCliente Tipo { get; set; }

    }
}