using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using DOMINIO;

namespace TPC_BAIRES
{
    public partial class Checkout : System.Web.UI.Page
    {
        public List<Producto> productos = new List<Producto>();
        public Cliente cliente = null;
        public CarritoDominio carrito = null;
        public VentaNegocio ventaNegocio = null;
        public ProductoNegocio productoNegocio = null;
        public decimal TotalCarrito = 0;
        public void Page_Load(object sender, EventArgs e)
        {
            ventaNegocio = new VentaNegocio();
            productoNegocio = new ProductoNegocio();
            cliente = (Cliente)Session["Cliente" + Session.SessionID];
            if (cliente != null)
            {
                carrito = (CarritoDominio)Session["Carrito" + Session.SessionID];
                //Consigo carrito
                SetUpcarrito(carrito);
            }
        }
        private void SetUpcarrito(CarritoDominio carrito)
        {
            if (carrito != null)
            {
                Session["Carrito" + Session.SessionID] = carrito;
                foreach (Producto item in carrito.productos)
                {
                    TotalCarrito += item.Precio;
                }
            }

        }

        protected void Compra(object sender, EventArgs e)
        {

            // aca cambio el estado del producto a 0 y queda como vendido
            productoNegocio.CambiarEstadoProductos(carrito.productos);
            //genero venta
            ventaNegocio.AltaVenta(cliente.DNI, TotalCarrito);
            //vacio el carrito
            Session["Carrito" + Session.SessionID]=null;
            Response.Redirect("https://www.mercadopago.com.ar/checkout/v1/redirect?pref_id=18262266-9a2842ad-70fa-456f-b1e5-8c0593d7e5d1");

        }
    }
}