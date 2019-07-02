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

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Alumno()
			:base()
		{

		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="id"></param>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		/// <param name="claseQueToma"></param>
		public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
			:base(id,nombre,apellido,dni,nacionalidad)
		{
			this.claseQueToma = claseQueToma;
		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="id"></param>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		/// <param name="claseQueToma"></param>
		/// <param name="estadoCuenta"></param>
		public Alumno(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
			:this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
		{
			this.estadoCuenta = estadoCuenta;
		}

		/// <summary>
		/// Retorna los datos de un Alumno en formato string
		/// </summary>
		/// <returns></returns>
		protected override string MostrarDatos()
		{
			return base.MostrarDatos() + "\n" + "ESTADO DE CUENTA: " + estadoCuenta.ToString() + "\n"+ ParticiparEnClase() + "\n" ;
		}

		/// <summary>
		/// Una clase y un alumno seran distintos si el alumno no participa de ella
		/// </summary>
		/// <param name="a"></param>
		/// <param name="clase"></param>
		/// <returns></returns>true si el alumno participa en la clase, caso contrario false
		public static bool operator !=(Alumno a ,Universidad.EClases clase)
		{
			if(a.claseQueToma != clase)
			{
				return true;
			}
			return false;
		}

		/// <summary>
		/// Una clase y un alumno seran iguales si el alumno  participa de ella
		/// </summary>
		/// <param name="a"></param>
		/// <param name="clase"></param>
		/// <returns></returns>true si el alumno participa en la clase, caso contrario false
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

		/// <summary>
		/// Retorna en formato string las clases en las que participa el alumno
		/// </summary>
		/// <returns></returns>
		public override string ParticiparEnClase()
		{
			return "TOMA CLASES DE " + this.claseQueToma.ToString();
		}

		/// <summary>
		/// Retorna en formato string las clases en las que participa el alumno
		/// </summary>
		/// <returns></returns>
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
