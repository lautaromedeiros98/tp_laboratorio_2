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

		/// <summary>
		/// Compara 2 objetos de tipo Universitario
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns> True si son iguales , False caso contrario
		public override bool Equals(object obj)
		{
			if (obj is Universitario)
			{
				return ((Universitario)obj == this);
			}
			return false;
		}


		/// <summary>
		/// Metodo virtual que retorna los datos de un universitario en formato string 
		/// </summary>
		/// <returns></returns>
		protected virtual string MostrarDatos()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.Append(base.ToString());
			retorno.AppendLine("\nLEGAJO NUMERO:" + this.legajo);
			return retorno.ToString();
		}

		/// <summary>
		/// Dos universitarios son diferentes si su dni y legajo no coinciden
		/// </summary>
		/// <param name="pg1"></param>
		/// <param name="pg2"></param>
		/// <returns></returns> true si son iguales, false si son distintos
		public static bool operator !=(Universitario pg1,Universitario pg2)
		{
			return !(pg1 == pg2);
		}

		/// <summary>
		/// Dos universitarios son iguales si su dni y legajo coinciden
		/// </summary>
		/// <param name="pg1"></param>
		/// <param name="pg2"></param>
		/// <returns></returns> true si son iguales, false si son distintos
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

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Universitario()
			:base()
		{

		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="legajo"></param>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		public Universitario(int legajo,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
			:base(nombre,apellido,dni,nacionalidad)
		{
			this.legajo = legajo;
		}
	}
}
