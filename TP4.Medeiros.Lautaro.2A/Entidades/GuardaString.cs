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
		public static bool Guardar(this string texto,string archivo)
		{
            StreamWriter writer; 
            try
            {
                writer = new StreamWriter(Environment.SpecialFolder.Desktop.ToString() + "/archivo.txt", true);
                if(!Equals(archivo,null))
                {
                    writer.Write(archivo);
                }
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
