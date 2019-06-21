using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
	public static class PaqueteDAO
	{
		private static SqlCommand comando;
		private static SqlConnection conexion;

		public static bool Insertar(Paquete p)
		{
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = "INSERT INTO correo-sp-2017(direccionEntrega,trackingID,alumno) values('" + p.DireccionEntrega + "','" + p.TrackingID + "','Lautaro Medeiros')";
            try
            {
                conexion.Open();
                if (comando.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception a)
            {
                Console.WriteLine(a.Message);
                return false;
            }
            finally
            {
                conexion.Close();
            }
        }

	    static PaqueteDAO()
		{
            comando = new SqlCommand();
            //ACA INICAR LA CONEXION DEL SQLCONNECTION
		}
	}
}
