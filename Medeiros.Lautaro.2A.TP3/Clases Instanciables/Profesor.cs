using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;

namespace Clases_Instanciables
{
	public sealed class Profesor : Universitario
	{
		private Queue<Universidad.EClases> clasesDelDia;
		private static Random random;

		private void _randomClases()
		{
			for (int i=0; i<2;i++)
			{
				this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
				System.Threading.Thread.Sleep(250);

			}
		}

		protected override string MostrarDatos()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.Append(base.MostrarDatos());
			retorno.AppendLine(this.ParticiparEnClase());
			return retorno.ToString();
		}

		public static bool operator !=(Profesor i,Universidad.EClases clase)
		{
			return !(i == clase);
		}

		public static bool operator ==(Profesor i,Universidad.EClases clase)
		{
			foreach(Universidad.EClases item in i.clasesDelDia)
			{
				if(item == clase)
				{
					return true;
				}
			}
			return false;
		}

		public override string ParticiparEnClase()
		{
			StringBuilder retorno = new StringBuilder(); 
			retorno.AppendLine("CLASES DEL DIA:");
			foreach (Universidad.EClases item in this.clasesDelDia)
			{
				retorno.AppendLine(item.ToString());
			}
			return retorno.ToString();
		}

		public Profesor()
		{
			
		}

		static Profesor()
		{
			random = new Random();
		}

		public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
			:base(id,nombre,apellido,dni,nacionalidad)
		{
			this.clasesDelDia = new Queue<Universidad.EClases>();
			_randomClases();
		}

		public override string ToString()
		{
			return this.MostrarDatos();
		}
	}
}
