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

		public static bool Guardar(Universidad uni)
		{
			Xml<Universidad> xml = new Xml<Universidad>();
			return xml.Guardar("Universidad.xml", uni);
		}

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

		public static bool operator !=(Universidad g,Alumno a)
		{
			return !(g == a);
		}

		public static bool operator !=(Universidad g,Profesor i)
		{
			return !(g == i);
		}

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

		public static Universidad operator +(Universidad u,Alumno a)
		{
			if(u!=a)
			{
				u.Alumnos.Add(a);
			}
			return u;
		}

		public static Universidad operator +(Universidad u,Profesor i)
		{
			if(u!=i)
			{
				u.Instructores.Add(i);
			}
			return u;
		}

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

		public override string ToString()
		{
			return MostrarDatos(this);
		}

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
