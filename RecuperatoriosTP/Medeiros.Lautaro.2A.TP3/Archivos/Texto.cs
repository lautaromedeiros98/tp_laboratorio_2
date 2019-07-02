using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
		/// <summary>
		/// Escribe en un archivo de texto especificado el o los datos pasados por parametro
		/// </summary>
		/// <param name="archivo"></param>
		/// <param name="datos"></param>
		/// <returns></returns>
		public bool Guardar(string archivo, string datos)
		{
			try
			{
				StreamWriter swriter = new StreamWriter(archivo);
				swriter.WriteLine(datos);
				swriter.Close();
				return true;
			}
			catch (ArchivosException ex)
			{
				throw new ArchivosException(ex);
			}
		}

		/// <summary>
		/// Lee un archivo de texto especificado y los asigna a variable pasada por parametro de referencia
		/// </summary>
		/// <param name="archivo"></param>
		/// <param name="datos"></param>
		/// <returns></returns>
		public bool Leer(string archivo, out string datos)
		{
			try
			{
				StreamReader sreader = new StreamReader(archivo);
				datos = sreader.ReadToEnd();
				sreader.Close();
				return true;
			}
			catch (ArchivosException ex)
			{
				throw new ArchivosException(ex);
			}
		}
	}
}
