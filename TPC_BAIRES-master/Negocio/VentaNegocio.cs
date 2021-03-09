using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;

namespace Negocio
{
    public class VentaNegocio
    {
        public void AltaVenta(int dni, decimal total)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("Insert into ventas values (@dni, @total)");
                datos.Clear();
                datos.agregarParametro("@DNI", dni);
                datos.agregarParametro("@total", total);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
