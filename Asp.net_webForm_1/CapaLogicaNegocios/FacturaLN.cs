using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoDatos;

namespace CapaLogicaNegocios
{
    public class FacturaLN
    {
        #region "PATRON SINGLETON"
        private static FacturaLN facturaLN = null;
        private FacturaLN() { }
        public static FacturaLN getInstance()
        {
            if (facturaLN == null)
            {
                facturaLN = new FacturaLN();
            }
            return facturaLN;
        }
        #endregion

        public bool RegistrarFactura(string idCliente, string Fecha, string Detalle)
        {
            try
            {
                return FacturaDAO.getInstance().RegistrarFactura(idCliente, Fecha, Detalle);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
