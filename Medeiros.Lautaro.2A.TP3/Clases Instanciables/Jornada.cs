using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Instanciables;
using System.IO;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
		private List<Alumno> alumnos;
		private Universidad.EClases clase;
		private Profesor instructor;

		public List<Alumno> Alumnos
		{
			get
			{
				return this.alumnos;
			}
			set
			{
				this.alumnos = value;
			}
		}

		public Universidad.EClases Clase
		{
			get
			{
				return this.clase;
			}
			set
			{
				this.clase = value;
			}
		}

		public Profesor Instructor
		{
			get
			{
				return this.instructor;
			}
			set
			{
				this.instructor = value;
			}
		}

		public static bool Guardar(Jornada jor)
		{
			Texto archivoTxt = new Texto();
			return archivoTxt.Guardar("Jornada.txt", jor.ToString());
		}

		private Jornada()
		{
			this.alumnos = new List<Alumno>();
		}

		public Jornada(Universidad.EClases clase,Profesor instructor)
			:this()
		{
			this.Clase = clase;
			this.Instructor = instructor;
		}

		public string Leer()
		{
			try
			{
				StreamReader reader = new StreamReader(@"C: \Users\Lalo\source\repos\Medeiros.Lautaro.2A.TP3\Jornada.txt");
				return reader.ReadToEnd();
			}
			catch
			{
				return "";
			}
		}

		public static bool operator !=(Jornada j,Alumno a)
		{
			return !(j == a);
		}

		public static Jornada operator +(Jornada j,Alumno a)
		{
			foreach (Alumno item in j.alumnos)
			{
				if (a == item)
				{
					return j;
				}
			}
			j.alumnos.Add(a);
			return j;
		}

		public static bool operator ==(Jornada j,Alumno a)
		{
			return a == j.Clase;
		}

		public override string ToString()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.Append("CLASE DE: " + clase.ToString() + " POR: " + instructor.ToString() + "Alumnos: \n");
			foreach (Alumno a in alumnos)
			{
				retorno.AppendLine( a.ToString());
			}
			return retorno.ToString();
		}
	}
}
