using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Modelo
{
    public class ConexionBD
    {

        private string cadena = "server=*****; database=*****; user=*****; password=*****";
        public MySqlConnection conectar = new MySqlConnection();

        public void AbrirConexion()
        {
            try
            {
                conectar.ConnectionString = cadena;
                conectar.Open();
                //System.Diagnostics.Debug.WriteLine("Conexion Exitosa");
            }
            catch (Exception ex)
            {
                //System.Diagnostics.Debug.WriteLine("Conexion Fallida - " + ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if(conectar.State == ConnectionState.Open)
                {
                    conectar.Close();
                    //System.Diagnostics.Debug.WriteLine("Cerrar conexion");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("No se pudo cerrar conexion - " + ex.Message);
                throw;
            }
        }


    }
}
