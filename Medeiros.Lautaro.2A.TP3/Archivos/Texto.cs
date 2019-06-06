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
