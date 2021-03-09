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
    public partial class Shop : System.Web.UI.Page
    {

        //Creo los objetos necesarios
        public List<Producto> productos = new List<Producto>();
        public string valorBusqueda = null;
        public Cliente cliente = null;
        public CarritoDominio carrito = null;        
        public ProductoNegocio productoNegocio= null;
        public void Page_Load(object sender, EventArgs e)
        {
            productoNegocio = new ProductoNegocio();
            cliente = (Cliente)Session["Cliente" + Session.SessionID];
            if (cliente != null)
            { 
                carrito = (CarritoDominio)Session["Carrito" + Session.SessionID];
                var add = (string)Request.QueryString["add"];
                var borrar = (string)Request.QueryString["borrar"];
                //Consigo carrito
                SetUpcarrito(carrito, add, borrar);
            }
            valorBusqueda = (string)Request.QueryString["valor"];
            if (string.IsNullOrEmpty(valorBusqueda)) { 
                productos = (productoNegocio.listar());
            } else
            {
                productos = (productoNegocio.BuscarProducto(valorBusqueda));
            }
        }



       protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

     
        protected void Button1_Click(object sender, EventArgs e)
        {
                                   
                if (string.IsNullOrEmpty(TextBox1.Text))
               {
                  Response.Redirect("Shop.aspx");
            }
               else
            {

                    Response.Redirect("Shop.aspx?valor="+ TextBox1.Text);
                }
        }

        private void SetUpcarrito(CarritoDominio carrito, string add, string borrar)
        {
            if(carrito == null)
            {
                carrito = new CarritoDominio();
                carrito.productos = new List<Producto>();
            }

            if (!string.IsNullOrEmpty(add))
            {
                Producto producto = productoNegocio.ConseguirProducto(Convert.ToInt32(add));
                carrito.productos.Add(producto);

               
            }
            if (!string.IsNullOrEmpty(borrar))
            {
                Producto producto = productoNegocio.ConseguirProducto(Convert.ToInt32(borrar));
                carrito.productos.Remove(producto);

            }
            Session["Carrito" + Session.SessionID] = carrito;
        }

        public bool BuscarEnCarrito(int id, List<Producto> car)
        {
            
                foreach (var produ in car)
                {
                    if (id == produ.Id) { return true; }
                }

            return false;
        }

    }



}