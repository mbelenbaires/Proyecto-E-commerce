using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data.SqlClient;


namespace Negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            Producto aux;
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("select * from articulos where Estado = 1");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    aux = new Producto();
                    aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    aux.Categoria = Datos.Lector["Categoria"].ToString();
                    aux.Nombre = Datos.Lector["Nombre"].ToString();
                    aux.Imagen = Datos.Lector["Foto"].ToString();
                    aux.Descripcion = Datos.Lector["Descripcion"].ToString();
                    aux.Precio = (decimal)Datos.Lector["Precio_venta"];
                    aux.Tamaño = (string)Datos.Lector["Tamano"];
                    lista.Add(aux);
                }
                return lista;
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

        public List<Producto> BuscarProducto(string nombre)
        {
            AccesoDatos Datos = new AccesoDatos();
            List<Producto> lista = new List<Producto>();
            Producto aux = null;
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where a.nombre LIKE  '%" + nombre + "%' or a.categoria LIKE  '%" + nombre + "%' or a.descripcion LIKE  '%" + nombre + "%'");
                Datos.EjecutarLector();
                while (Datos.Lector.Read())
                {
                    aux = new Producto();
                    aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    aux.Nombre = (string)Datos.Lector["nombre"];
                    aux.Precio = (decimal)Datos.Lector["precio_venta"];
                    aux.Descripcion = (string)Datos.Lector["descripcion"];
                    aux.Categoria = (string)Datos.Lector["categoria"];
                    aux.Imagen = (string)Datos.Lector["foto"];
                    lista.Add(aux);
                }
                return lista;
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

        public void CambiarEstadoProductos(List<Producto> productos)
        {
            AccesoDatos datos = new AccesoDatos();
            foreach (Producto item in productos) {
    
                try
                {
                    datos.SetearQuery("update Articulos set Estado = 0 where Id = @Id;");
                    datos.Clear();
                    datos.agregarParametro("@Id", item.Id);
                    datos.EjecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Producto> ListarPantalones()
        {
            List<Producto> Listado = new List<Producto>();
            Producto Aux;
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where a.categoria like '%Pantalón%' and a.estado=1");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Producto();
                    Aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    Aux.Nombre = (string)Datos.Lector["nombre"];
                    Aux.Descripcion = (string)Datos.Lector["descripcion"];
                    Aux.Imagen = (string)Datos.Lector["foto"];
                    Aux.Categoria = (string)Datos.Lector["categoria"];
                    Aux.Precio = (decimal)Datos.Lector["precio_venta"];
                    Aux.Tamaño = (string)Datos.Lector["tamano"];
                    Listado.Add(Aux);
                }
                return Listado;
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

        public List<Producto> ListarAccesorios()
        {
            List<Producto> Listado = new List<Producto>();
            Producto Aux;
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where a.categoria like '%ccesorio%' and a.estado=1");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Producto();
                    Aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    Aux.Nombre = (string)Datos.Lector["nombre"];
                    Aux.Descripcion = (string)Datos.Lector["descripcion"];
                    Aux.Imagen = (string)Datos.Lector["foto"];
                    Aux.Categoria = (string)Datos.Lector["categoria"];
                    Aux.Precio = (decimal)Datos.Lector["precio_venta"];
                    Listado.Add(Aux);
                }
                return Listado;
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

        public List<Producto> ListarTops()
        {
            List<Producto> Listado = new List<Producto>();
            Producto Aux;
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where (a.categoria like '%Buzo%' or a.categoria like '%emera%'or a.categoria like '%op%' or a.categoria like '%ampera%') and a.estado=1");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Producto();
                    Aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    Aux.Nombre = (string)Datos.Lector["nombre"];
                    Aux.Descripcion = (string)Datos.Lector["descripcion"];
                    Aux.Imagen = (string)Datos.Lector["foto"];
                    Aux.Categoria = (string)Datos.Lector["categoria"];
                    Aux.Precio = (decimal)Datos.Lector["precio_venta"];
                    Listado.Add(Aux);
                }
                return Listado;
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

        public List<Producto> ListarCalzado()
        {
            List<Producto> Listado = new List<Producto>();
            Producto Aux;
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where a.categoria like '%alzado%' and a.estado=1");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Producto();
                    Aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    Aux.Nombre = (string)Datos.Lector["nombre"];
                    Aux.Descripcion = (string)Datos.Lector["descripcion"];
                    Aux.Imagen = (string)Datos.Lector["foto"];
                    Aux.Categoria = (string)Datos.Lector["categoria"];
                    Aux.Precio = (decimal)Datos.Lector["precio_venta"];
                    Listado.Add(Aux);
                }
                return Listado;
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

        public List<Producto> ListarFyv()
        {
            List<Producto> Listado = new List<Producto>();
            Producto Aux;
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where (a.categoria like '%alda%' or a.categoria like '%ollera%'or a.categoria like '%estido%') and a.estado=1");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux = new Producto();
                    Aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    Aux.Nombre = (string)Datos.Lector["nombre"];
                    Aux.Descripcion = (string)Datos.Lector["descripcion"];
                    Aux.Imagen = (string)Datos.Lector["foto"];
                    Aux.Categoria = (string)Datos.Lector["categoria"];
                    Aux.Precio = (decimal)Datos.Lector["precio_venta"];
                    Listado.Add(Aux);
                }
                return Listado;
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

        public Producto ConseguirProducto(int id)
        {
            Producto Aux = new Producto();
            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.SetearQuery("SELECT * FROM articulos a where a.ID = '"+id+"'");
                Datos.EjecutarLector();

                while (Datos.Lector.Read())
                {
                    Aux.Id = Convert.ToInt32(Datos.Lector["Id"].ToString());
                    Aux.Nombre = (string)Datos.Lector["nombre"];
                    Aux.Descripcion = (string)Datos.Lector["descripcion"];
                    Aux.Imagen = (string)Datos.Lector["foto"];
                    Aux.Categoria = (string)Datos.Lector["categoria"];
                    Aux.Precio = (decimal)Datos.Lector["precio_venta"];
                }
                return Aux;
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
        public void ModificarProducto(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearQuery("update Articulos set Nombre = @Nombre where Id = @Id; update Articulos set precio_venta = @precio_venta where Id = @Id;update Articulos set categoria = @categoria where Id = @Id;update Articulos set Tamano = @Tamano where Id = @Id;update Articulos set descripcion = @descripcion where Id = @Id;update Articulos set foto = @foto where Id = @Id;update Articulos set estado = 0 where Id = @Id;");
                datos.Clear();
                datos.agregarParametro("@Nombre", producto.Nombre);
                datos.agregarParametro("@Precio_venta", producto.Precio);
                datos.agregarParametro("@Foto", producto.Imagen);
                datos.agregarParametro("@Tamano", producto.Tamaño);
                datos.agregarParametro("@Estado", producto.estado);
                datos.agregarParametro("@Id", producto.Id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
