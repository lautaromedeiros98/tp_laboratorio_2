using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;
using System.Xml.Serialization;
using Archivos;

namespace Clases_Instanciables
{
	public class Universidad
	{
		private List<Alumno> alumnos;
		private List<Jornada> jornada;
		private List<Profesor> profesores;

		/// <summary>
		/// Asigna valores y/o retorna la lista de alumnos
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
		/// Asigna valores y/o retorna la lista de jornadas
		/// </summary>
		public List<Jornada> Jornadas
		{
			get
			{
				return this.jornada;
			}
			set
			{
				this.jornada = value;
			}
		}

		/// <summary>
		/// Asigna valores y/o retorna la lista de profesores
		/// </summary>
		public List<Profesor> Instructores
		{
			get
			{
				return this.profesores;
			}
			set
			{
				this.profesores = value;
			}
		}

		/// <summary>
		/// indexador tipo entero para recorrer la lista de jornadas
		/// </summary>
		/// <param name="i"></param>
		/// <returns></returns>
		public Jornada this[int i]
		{
			get
			{
				return jornada[i];
			}
			set
			{
				jornada[i] = value;
			}
		}

		/// <summary>
		/// Escribe un archivo xml con los datos de una universidad
		/// </summary>
		/// <param name="uni"></param>
		/// <returns></returns>
		public static bool Guardar(Universidad uni)
		{
			Xml<Universidad> xml = new Xml<Universidad>();
			return xml.Guardar("Universidad.xml", uni);
		}

		/// <summary>
		/// retorna en formato de string los datos de una universidad
		/// </summary>
		/// <param name="uni"></param>
		/// <returns></returns>
		private static string MostrarDatos(Universidad uni)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("<---------------------------------------------------------------------->");
			sb.AppendLine("JORNADA:");
			foreach (Jornada j in uni.Jornadas)
			{
				sb.AppendLine(j.ToString());
			}
			sb.AppendLine("<---------------------------------------------------------------------->");
			sb.AppendFormat("ALUMNOS:");
			foreach (Alumno a in uni.Alumnos)
			{
				sb.AppendLine(a.ToString());
			}
			sb.AppendLine("<---------------------------------------------------------------------->");
			sb.AppendLine("PROFESOR:");
			foreach (Profesor p in uni.Instructores)
			{
				sb.AppendLine(p.ToString());
			}
			sb.AppendLine("<---------------------------------------------------------------------->");
			return sb.ToString();
		}

		/// <summary>
		/// una universidad es distinta de un alumno si el mismo no pertenece a esta
		/// </summary>
		/// <param name="g"></param>
		/// <param name="a"></param>
		/// <returns></returns>
		public static bool operator !=(Universidad g,Alumno a)
		{
			return !(g == a);
		}

		/// <summary>
		/// una universidad es distinta a un profesor si este no dicta clases en la misma
		/// </summary>
		/// <param name="g"></param>
		/// <param name="i"></param>
		/// <returns></returns>
		public static bool operator !=(Universidad g,Profesor i)
		{
			return !(g == i);
		}

		/// <summary>
		/// Verifica que la clase tenga un profesor para dar la clase , caso contrario lo asigna
		/// </summary>
		/// <param name="u"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
		public static Profesor operator !=(Universidad u,EClases clase)
		{
			foreach(Profesor item in u.Instructores)
			{
				if(item!=clase)
				{
					return item;
				}
			}
			return null;
		}

		/// <summary>
		/// Operador que agrega una clase a la universidad con un profesor que la dicte
		/// </summary>
		/// <param name="g"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
		public static Universidad operator +(Universidad g,EClases clase)
		{
			Profesor p = (g == clase);
			if (!Equals(p,null))
			{
				Jornada j = new Jornada(clase, p);
				foreach (Alumno a in g.Alumnos)
				{
					if (a == clase)
					{
						j += a;
					}
				}
				g.jornada.Add(j);
			}
			return g;
		}

		/// <summary>
		/// agrega un alumno a una universidad si el mismo no pertenece a la universidad
		/// </summary>
		/// <param name="u"></param>
		/// <param name="a"></param>
		/// <returns></returns>
		public static Universidad operator +(Universidad u,Alumno a)
		{
			if(u!=a)
			{
				u.Alumnos.Add(a);
			}
			return u;
		}

		/// <summary>
		/// agrega un profesor a una universidad si el mismo no pertenece a esta
		/// </summary>
		/// <param name="u"></param>
		/// <param name="i"></param>
		/// <returns></returns>
		public static Universidad operator +(Universidad u,Profesor i)
		{
			if(u!=i)
			{
				u.Instructores.Add(i);
			}
			return u;
		}

		/// <summary>
		/// una universidad es igual a un alumno si este pertenece a la misma
		/// </summary>
		/// <param name="g"></param>
		/// <param name="a"></param>
		/// <returns></returns>
		public static bool operator ==(Universidad g, Alumno a)
		{
			foreach(Alumno item in g.Alumnos)
			{
				if(item==a)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// una universidad es igual a un profesor si este dicta clases en la misma
		/// </summary>
		/// <param name="g"></param>
		/// <param name="i"></param>
		/// <returns></returns>
		public static bool operator ==(Universidad g, Profesor i)
		{
			foreach(Profesor item in g.Instructores)
			{
				if(item==i)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// una universidad es igual a una clase si en esa clase hay un profesor dictando clases
		/// </summary>
		/// <param name="u"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
		public static Profesor operator ==(Universidad u, EClases clase)
		{
			foreach (Profesor p in u.Instructores)
			{
				if (p == clase)
				{
					return p;
				}
			}
			throw new SinProfesorException();
		}

		/// <summary>
		/// Retorna los datos de una universidad en forma de string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return MostrarDatos(this);
		}

		/// <summary>
		/// cponstructor por defecto que inicializa las listas de alumnos,profesores y jornadas
		/// </summary>
		public Universidad()
		{
			this.alumnos = new List<Alumno>();
			this.Instructores = new List<Profesor>();
			this.jornada = new List<Jornada>();
		}

		public enum EClases
		{
			Programacion,
			Laboratorio,
			Legislacion,
			SPD
		}
	}
}
