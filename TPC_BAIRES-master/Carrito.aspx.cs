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
    public partial class Carrito : System.Web.UI.Page
    {
        public List<Producto> productos = new List<Producto>();
        public Cliente cliente = null;
        public CarritoDominio carrito = null;
        public ProductoNegocio productoNegocio = null;
        public decimal TotalCarrito = 0;
        public void Page_Load(object sender, EventArgs e)
        {
            productoNegocio = new ProductoNegocio();
            cliente = (Cliente)Session["Cliente" + Session.SessionID];
            if (cliente != null)
            {

                //Consigo carrito
                               
                var add = (string)Request.QueryString["add"];
                var borrar = (string)Request.QueryString["borrar"];
                carrito = (CarritoDominio)Session["Carrito" + Session.SessionID];
                SetUpcarrito(carrito,add,borrar);
            }


        }
        private void SetUpcarrito(CarritoDominio carrito, string add, string borrar)
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
                Session["Carrito" + Session.SessionID] = carrito;
            }

            if (!string.IsNullOrEmpty(borrar))
            {
                Producto producto = productoNegocio.ConseguirProducto(Convert.ToInt32(borrar));
                carrito.productos.Remove(producto);
                Session["Carrito" + Session.SessionID] = carrito;
            }

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
            if (carrito != null && carrito.productos.Any())
            {
                Response.Redirect("Checkout.aspx");
            }
            else
            { }
        }
        protected void Vaciar(object sender, EventArgs e)
        {
            carrito = null;
            Session["Carrito" + Session.SessionID] = carrito;
        }


    }
}