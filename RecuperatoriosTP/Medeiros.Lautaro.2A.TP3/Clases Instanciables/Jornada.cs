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

		/// <summary>
		/// Retorna y asigna la lista de alumnos de una jornada
		/// </summary>
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

		/// <summary>
		/// Retorna el listado de clases de una jornada o lo asigna
		/// </summary>
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

		/// <summary>
		/// retorna o asigna un profesor a la jornada
		/// </summary>
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

		/// <summary>
		/// Guarda en un archivo de texto los datos de una jornada
		/// </summary>
		/// <param name="jor"></param>
		/// <returns></returns>
		public static bool Guardar(Jornada jor)
		{
			Texto archivoTxt = new Texto();
			return archivoTxt.Guardar("Jornada.txt", jor.ToString());
		}

		/// <summary>
		/// Constructor privado que inicializa la lista de alumnos
		/// </summary>
		private Jornada()
		{
			this.alumnos = new List<Alumno>();
		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="clase"></param>
		/// <param name="instructor"></param>
		public Jornada(Universidad.EClases clase,Profesor instructor)
			:this()
		{
			this.Clase = clase;
			this.Instructor = instructor;
		}

		/// <summary>
		/// Metodo que retorna desde un archivo los datos de una jornada
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// una jornada y un alumno seran distintos si el alumno no participa en esta
		/// </summary>
		/// <param name="j"></param>
		/// <param name="a"></param>
		/// <returns></returns>true si el alumno participa de la jornada , caso contrario false
		public static bool operator !=(Jornada j,Alumno a)
		{
			return !(j == a);
		}

		/// <summary>
		/// Operador que agrega un alumno a una jornada siempre y cuando este no participa en la jornada
		/// </summary>
		/// <param name="j"></param>
		/// <param name="a"></param>
		/// <returns></returns>
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

		/// <summary>
		/// una jornada y un alumno seran iguales si el alumno no participa en esta
		/// </summary>
		/// <param name="j"></param>
		/// <param name="a"></param>
		/// <returns></returns>true si el alumno participa de la jornada , caso contrario false
		public static bool operator ==(Jornada j,Alumno a)
		{
			return a == j.Clase;
		}

		/// <summary>
		/// Retorna en formato string los datos de una jornada
		/// </summary>
		/// <returns></returns>
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
