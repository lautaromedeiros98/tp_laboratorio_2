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
			return true;
		}

	    static PaqueteDAO()
		{

		}
	}
}
