using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
	public abstract class Universitario : Persona
	{
		private int legajo;

		public override bool Equals(object obj)
		{
			if (obj is Universitario)
			{
				return ((Universitario)obj == this);
			}
			return false;
		}

		protected virtual string MostrarDatos()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.Append(base.ToString());
			retorno.AppendLine("\nLEGAJO NUMERO:" + this.legajo);
			return retorno.ToString();
		}

		public static bool operator !=(Universitario pg1,Universitario pg2)
		{
			return !(pg1 == pg2);
		}

		public static bool operator ==(Universitario pg1, Universitario pg2)
		{
			if(pg1 is Universitario && pg2 is Universitario)
			{
				if(pg1.legajo == pg2.legajo && pg1.DNI == pg2.DNI)
				{
					return true;
				}
			}
			return false;
		}

		public abstract string ParticiparEnClase();

		public Universitario()
			:base()
		{

		}

		public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
			:base(nombre,apellido,dni,nacionalidad)
		{
			this.legajo = legajo;
		}
	}
}
