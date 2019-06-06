using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
	public class Xml<T> : IArchivo<T>
	{
		public bool Guardar(string archivo,T datos)
		{
			try
			{
				XmlTextWriter writer = new XmlTextWriter(archivo,Encoding.UTF32);
				XmlSerializer serializer = new XmlSerializer(typeof(T)); ;
				serializer.Serialize(writer, datos);
				writer.Close();
				return true;
			}
			catch (ArchivosException ex)
			{
				throw new ArchivosException(ex);
			}
		}

		public bool Leer(string archivo,out T datos)
		{
			try
			{
				XmlTextReader reader = new XmlTextReader(archivo);
				XmlSerializer serializer = new XmlSerializer(typeof(T));
				datos = (T)serializer.Deserialize(reader);
				reader.Close();
				return true;
			}
			catch (ArchivosException ex)
			{
				throw new ArchivosException(ex);
			}
		}
	}
}
