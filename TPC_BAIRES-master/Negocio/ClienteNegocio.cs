using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;

namespace Negocio
{
   public class ClienteNegocio
    {
        public Cliente BuscarDNI(int DNI)
        {
            AccesoDatos Datos = new AccesoDatos();
            Cliente aux = null;
            try
            {
                Datos.SetearQuery("SELECT *  FROM clientes where DNI =  '" + DNI + "'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    aux = new Cliente();
                    aux.DNI = (int)Datos.Lector["DNI"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Apellido = (string)Datos.Lector["Apellido"];
                    aux.Email = (string)Datos.Lector["Email"];
                    aux.Direccion = (string)Datos.Lector["Direccion"];
                    aux.CP = (string)Datos.Lector["CP"];
                    aux.Ciudad = (string)Datos.Lector["Ciudad"];
                    aux.Contrasena = (string)Datos.Lector["Contrasena"];

                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public bool BuscarMail(string mail)
        {
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM clientes where Email =  '" + mail + "'");
                Datos.EjecutarLector();
                if (Datos.Lector.Read())
                {
                    return true;
                }
                else return false;
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }

        public void AltaCliente(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("Insert into clientes values (@DNI, @Nombre, @Apellido, @Email, @Direccion, @Ciudad, @CP,@Contrasena)");
                datos.Clear();
                datos.agregarParametro("@DNI", cliente.DNI);
                datos.agregarParametro("@Nombre", cliente.Nombre);
                datos.agregarParametro("@Apellido", cliente.Apellido);
                datos.agregarParametro("@Email", cliente.Email);
                datos.agregarParametro("@Direccion", cliente.Direccion);
                datos.agregarParametro("@CP", cliente.CP);
                datos.agregarParametro("@Ciudad", cliente.Ciudad);
                datos.agregarParametro("@Contrasena", cliente.Contrasena);
                datos.EjecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("update Clientes set Nombre = @Nombre where DNI = @DNI;update Clientes set Apellido = @Apellido where DNI = @DNI;update Clientes set Email = @Email where DNI = @DNI;update Clientes set Direccion = @Direccion where DNI = @DNI;update Clientes set Ciudad = @Ciudad where DNI = @DNI;update Clientes set CP = @CP where DNI = @DNI;update Clientes set Contrasena = @Contrasena where DNI = @DNI;");
                datos.Clear();
                datos.agregarParametro("@DNI", cliente.DNI);
                datos.agregarParametro("@Nombre", cliente.Nombre);
                datos.agregarParametro("@Apellido", cliente.Apellido);
                datos.agregarParametro("@Email", cliente.Email);
                datos.agregarParametro("@Direccion", cliente.Direccion);
                datos.agregarParametro("@CP", cliente.CP);
                datos.agregarParametro("@Ciudad", cliente.Ciudad);
                datos.agregarParametro("@Contrasena", cliente.Contrasena);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Cliente BuscarMailyContra(string mail, string pass)
        {
            AccesoDatos Datos = new AccesoDatos();
            Cliente aux = null;
            try
            {
                Datos.SetearQuery("SELECT *  FROM clientes where Email like '" + mail + "' and Contrasena like '" + pass + "'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    aux = new Cliente();
                    aux.DNI = (int)Datos.Lector["DNI"];
                    aux.Nombre = (string)Datos.Lector["Nombre"];
                    aux.Apellido = (string)Datos.Lector["Apellido"];
                    aux.Email = (string)Datos.Lector["Email"];
                    aux.Direccion = (string)Datos.Lector["Direccion"];
                    aux.CP = (string)Datos.Lector["CP"];
                    aux.Ciudad = (string)Datos.Lector["Ciudad"];
                    aux.Contrasena = (string)Datos.Lector["Contrasena"];

                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Datos.CerrarConexion();
            }
        }
    }
}
