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
   
    public partial class Buscador : System.Web.UI.Page
    {
        public List<Producto> productosfiltrados = new List<Producto>();
        public string valorBusqueda = "hola";
        public Cliente cliente = null;
        public CarritoDominio carrito = null;
        public ProductoNegocio productoNegocio = null;
        public void Page_Load(object sender, EventArgs e)
        {
            productoNegocio = new ProductoNegocio();
            cliente = (Cliente)Session["Cliente" + Session.SessionID];
            if (cliente != null)
            {
                carrito = (CarritoDominio)Session["Carrito" + Session.SessionID];
                var add = (string)Request.QueryString["add"];
                //Consigo carrito
                SetUpcarrito(carrito, add);
            }
            valorBusqueda = (string)Request.QueryString["valor"];

            productosfiltrados = new ProductoNegocio().BuscarProducto(valorBusqueda);
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