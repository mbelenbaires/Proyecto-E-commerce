using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOMINIO;
using System.Data.SqlClient;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            Articulo aux;
            SqlCommand comando = new SqlCommand();
            SqlConnection conexion = new SqlConnection();
            SqlDataReader lector;

            try
            {
                conexion.ConnectionString = "Server = CHICO-PC\\SQLEXPRESS; Database = TPC_BAIRES; Trusted_Connection = True";               
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select * from articulos a";
                comando.Connection = conexion;
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    aux = new Articulo();
                    aux.Nombre = lector["Nombre"].ToString();
                    aux.Descripcion = lector["Descripcion"].ToString();
                    aux.Precio = (decimal)lector["Precio_venta"];
                    aux.Tamaño = (string)lector["Tamano"];
                    aux.Categoria = lector["Categoria"].ToString();
                    aux.Imagen = (string)lector["Foto"];

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
                conexion.Close();
            }

        }
    }
}
