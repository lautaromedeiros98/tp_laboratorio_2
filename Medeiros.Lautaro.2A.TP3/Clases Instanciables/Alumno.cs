using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Clases_Instanciables;

namespace Clases_Instanciables
{
	public sealed class Alumno : Universitario 
	{
		private Universidad.EClases claseQueToma;
		private EEstadoCuenta estadoCuenta;

		public Alumno()
			:base()
		{

		}

		public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
			:base(id,nombre,apellido,dni,nacionalidad)
		{
			this.claseQueToma = claseQueToma;
		}

		public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
			:this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
		{
			this.estadoCuenta = estadoCuenta;
		}

		protected override string MostrarDatos()
		{
			return base.MostrarDatos() + "\n" + "ESTADO DE CUENTA: " + estadoCuenta.ToString() + "\n"+ ParticiparEnClase() + "\n" ;
		}

		public static bool operator !=(Alumno a ,Universidad.EClases clase)
		{
			if(a.claseQueToma != clase)
			{
				return true;
			}
			return false;
		}

		public static bool operator ==(Alumno a,Universidad.EClases clase)
		{
			if(a.claseQueToma == clase)
			{
				if(a.estadoCuenta!=EEstadoCuenta.Deudor)
				{
					return true;
				}
			}
			return false;
		}

		public override string ParticiparEnClase()
		{
			return "TOMA CLASES DE " + this.claseQueToma.ToString();
		}

		public override string ToString()
		{
			return this.MostrarDatos();
		}

		public enum EEstadoCuenta
		{
			AlDia,
			Deudor,
			Becado
		}
	}
}
