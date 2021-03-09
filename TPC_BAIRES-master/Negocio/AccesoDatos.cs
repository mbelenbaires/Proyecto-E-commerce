using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Negocio
{
    public class AccesoDatos
    {
        public SqlConnection Conexion { get; }
        public SqlCommand Comando { get; set; }
        public SqlDataReader Lector { get; set; }

        public AccesoDatos()
        {
            Conexion = new SqlConnection("data source =CHICO-PC\\sqlexpress; initial catalog = TPC_BAIRES; integrated security = sspi");
            //Conexion = new SqlConnection("data source =localhost\\sqlexpress; initial catalog = TPC_BAIRES; integrated security = sspi");
            //Conexion = new SqlConnection("data source =DESKTOP-2KS73NA\\sqlexpress; initial catalog = TPC_BAIRES; integrated security = sspi");
            Comando = new SqlCommand();
            Comando.Connection = Conexion;
        }

        public void SetearQuery(string Consulta)
        {
            Comando.CommandType = System.Data.CommandType.Text;
            Comando.CommandText = Consulta;
            Comando.Parameters.Clear();
        }

        public void setearSP(string sp)
        {

        }

        public void EjecutarLector()
        {
            try
            {
                Conexion.Open();
                Lector = Comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void CerrarConexion()
        {
            Conexion.Close();
        }

        public void agregarParametro(string nombre, object valor)
        {
            Comando.Parameters.AddWithValue(nombre, valor);
        }

        public void Clear()
        {
            Comando.Parameters.Clear();
        }

        internal void EjecutarAccion()
        {
            try
            {
                Conexion.Open();
                Comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Conexion.Close();
            }



        }
    }
}
