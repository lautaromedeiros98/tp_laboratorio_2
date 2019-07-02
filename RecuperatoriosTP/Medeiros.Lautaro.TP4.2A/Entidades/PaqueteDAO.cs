using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
	public static class PaqueteDAO
	{
		private static SqlCommand comando;
		private static SqlConnection conexion;

		/// <summary>
		/// Inicializa atributos de clase
		/// </summary>
		static PaqueteDAO()
		{
			conexion = new SqlConnection(Properties.Settings.Default.CCBDD);
			comando = new SqlCommand();
			comando.Connection = conexion;
		}
		/// <summary>
		/// Inserta un paquete a la base de datos
		/// </summary>
		/// <param name="p"></param>
		/// <returns></returns>
		public static bool Insertar(Paquete p)
		{
			try
			{
				comando.CommandText = string.Format("INSERT INTO [correo-sp-2017].[dbo].[Paquetes] values ('{0}','{1}','{2}')", p.DireccionEntrega, p.TrackingId, "Medeiros Lautaro");
				comando.CommandType = System.Data.CommandType.Text;
				conexion.Open();
				comando.ExecuteNonQuery();
				return true;
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{			
				conexion.Close();
			}
		}
	}
}
