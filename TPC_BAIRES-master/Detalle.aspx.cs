using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;
using Negocio;

namespace TPC_BAIRES
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Producto prod = new Producto();
        public Cliente cliente = null;
        public CarritoDominio carrito = null;
        public ProductoNegocio productoNegocio = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            productoNegocio = new ProductoNegocio();
            cliente = (Cliente)Session["Cliente" + Session.SessionID];
            var ver = (string)Request.QueryString["ver"];
            //Consigo el item
            prod = productoNegocio.ConseguirProducto(Convert.ToInt32(ver));
        }
        private void SetUpcarrito(CarritoDominio carrito, string add)
        {
            if (carrito == null)
            {
                carrito = new CarritoDominio();
                carrito.productos = new List<Producto>();
            }

            if (!string.IsNullOrEmpty(add))
            {
                Producto producto = productoNegocio.ConseguirProducto(Convert.ToInt32(add));
                carrito.productos.Add(producto);

            }
            Session["Carrito" + Session.SessionID] = carrito;
        }

    }
}