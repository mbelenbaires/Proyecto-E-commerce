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
    public partial class InicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var Buleano = (string)Request.QueryString["logOut"];
            if (Buleano != null)
            {
                CerrarSesion(Buleano);
            }
        }
        protected void BtnSesion_click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente aux = new Cliente();
            aux = null;
            aux = clienteNegocio.BuscarMailyContra(TboxEmail.Text,TboxContraseña.Text);
            if (aux != null)
            {
                Session["Cliente" + Session.SessionID] = aux;
                Response.Redirect("Shop.aspx");
            }
            else
            {
                Panel1.Visible = true;
            }

        }
        private void CerrarSesion(string Out)
        {
            Session["Cliente" + Session.SessionID] = null;
            Session["Carrito" + Session.SessionID] = null;
            Response.Redirect("Shop.aspx");

        }
    }
}