using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DOMINIO;
using Negocio;
using System.Net.Mail;

namespace TPC_BAIRES
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
            var Buleano = (string)Request.QueryString["logOut"];
            if (Buleano != null) {
                CerrarSesion(Buleano);
            }

        }

        protected void Altacliente(Cliente Cli)
        {
            
                Cli.Apellido = TboxApellido.Text;
                Cli.Ciudad = TboxCiudad.Text;
                Cli.CP = TboxCP.Text;
                Cli.Direccion = TboxDireccion.Text;
                Cli.DNI = Convert.ToInt32(TboxDNI.Text);
                Cli.Email = TboxEmail.Text;
                Cli.Nombre = TboxNombre.Text;
                Cli.Contrasena = TboxContraseña.Text;
            
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente = null;
            cliente = clienteNegocio.BuscarDNI(Convert.ToInt32(TboxDNI.Text));
            try
            {
                if (cliente != null)
                {
                    CboxTerminos.Enabled = true;
                    Response.Redirect("InicioSesion.aspx");
                }
                else
                {  
                    TboxApellido.Text = "";
                    TboxCiudad.Text = "";
                    TboxCP.Text = "";
                    TboxDireccion.Text = "";
                    TboxEmail.Text = "";
                    TboxNombre.Text = "";
                    TboxContraseña.Text = "";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BtnRegistro_click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = new Cliente();
            cliente = null;
            try
            {
                cliente = clienteNegocio.BuscarDNI(Convert.ToInt32(TboxDNI.Text));
            }
            catch
            {
                Response.Write("<script language=javascript>alert('Ingresá un DNI válido.');</script>");
                return;
            }

                      
            
             try
            {
                if (cliente != null)
                {
                    Response.Write("<script language=javascript>alert('Ya hay un usuario registrado con ese DNI.');</script>");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (cliente == null)
            {
                try
                {
                    if (clienteNegocio.BuscarMail(TboxEmail.Text)) {
                        Response.Write("<script language=javascript>alert('Ya hay un usuario registrado con ese E-mail.');</script>");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                cliente = new Cliente();
                Cliente aux = new Cliente();
                Altacliente(cliente);
                clienteNegocio.AltaCliente(cliente);
                aux = clienteNegocio.BuscarDNI(cliente.DNI);
                Session["Cliente" + Session.SessionID] = aux;
                // SendMail(aux.Email, aux.Nombre);
                Response.Write("<script>alert('Registro Exitoso!');window.location.href='Shop.aspx'</script>");

            }
            else if (cliente != null)
            {
                Altacliente(cliente);
                clienteNegocio.Modificar(cliente);
                Session["Cliente" + Session.SessionID] = cliente;
                //SendMail(cliente.Email, cliente.Nombre);
                Response.Write("<script>alert('Registro Exitoso!');window.location.href='Shop.aspx'</script>");
            }
        }

        protected void SendMail(string Email, string NombreCliente)
        {
            try
            {
                MailMessage Mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                Mail.From = new MailAddress("bbtiendabb@gmail.com");
                Mail.To.Add(Email);
                Mail.Subject = "Bienvenide a BELUSHOP";
                Mail.Body = "Gracias " + NombreCliente + " por registrarte en nuestra tienda!";
                SmtpServer.Port = 25;
                SmtpServer.Credentials = new System.Net.NetworkCredential("bbtiendabb@gmail.com", "eddie666!");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(Mail);
            }
            catch(Exception ex)
            {
                
                Response.Write("<script language=javascript>alert('Hubo un error al intentar enviarte un E-mail.');</script>");
               // Response.Redirect("Shop.aspx");
                throw ex;
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