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
    public partial class Accesorios : System.Web.UI.Page
    {
        public List<Producto> productosfiltrados = new List<Producto>();
        public List<Producto> productos = new List<Producto>();
        public Cliente cliente = null;
        public CarritoDominio carrito = null;
        public string valorBusqueda = null;
        public ProductoNegocio productoNegocio = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            productosfiltrados = (new ProductoNegocio().ListarAccesorios());
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
            if (string.IsNullOrEmpty(valorBusqueda))
            {
                productos = (productoNegocio.listar());
            }
            else
            {
                productos = (productoNegocio.BuscarProducto(valorBusqueda));
            }
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
                int x = 0;
                if (Int32.TryParse(add, out x))
                {
                    x = Int32.Parse(add);
                    Producto producto = productoNegocio.ConseguirProducto(x);
                    carrito.productos.Add(producto);
                }
            }
            Session["Carrito" + Session.SessionID] = carrito;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TextBox1.Text))
            {
                Response.Redirect("Shop.aspx");
            }
            else
            {

                Response.Redirect("Shop.aspx?valor=" + TextBox1.Text);
            }
        }
    }
}