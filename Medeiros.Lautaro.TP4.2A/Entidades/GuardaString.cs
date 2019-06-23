using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString	
    {
		/// <summary>
		/// Guarda los datos de un paquete en un archivo de texto en el escritorio de la computadora
		/// </summary>
		/// <param name="texto"></param>
		/// <param name="archivo"></param>
		/// <returns></returns>
		public static bool Guardar(this string texto,string archivo)
		{
			StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo,true);
			try
			{
				writer.Write(texto);
				writer.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return true;
		}
    }
}
