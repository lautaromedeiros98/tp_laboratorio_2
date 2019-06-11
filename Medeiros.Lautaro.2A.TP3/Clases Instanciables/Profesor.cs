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

		/// <summary>
		/// Asigna 2 clases aleatorias a un profesor
		/// </summary>
		private void _randomClases()
		{
			for (int i=0; i<2;i++)
			{
				this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(0, 3));
				System.Threading.Thread.Sleep(250);

			}
		}

		/// <summary>
		/// Retorna los datos de un profesor en formato de string
		/// </summary>
		/// <returns></returns>
		protected override string MostrarDatos()
		{
			StringBuilder retorno = new StringBuilder();
			retorno.Append(base.MostrarDatos());
			retorno.AppendLine(this.ParticiparEnClase());
			return retorno.ToString();
		}

		/// <summary>
		/// un profesor y una clase seran distintos cuando el profesor no dicte la misma
		/// </summary>
		/// <param name="i"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
		public static bool operator !=(Profesor i,Universidad.EClases clase)
		{
			return !(i == clase);
		}

		/// <summary>
		/// Un profesor y una clase seran iguales cuando este dicte la clase
		/// </summary>
		/// <param name="i"></param>
		/// <param name="clase"></param>
		/// <returns></returns>
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

		/// <summary>
		/// Retorna en formato string las clases que dictara el profesor
		/// </summary>
		/// <returns></returns>
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

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Profesor()
		{
			
		}

		/// <summary>
		/// Constructor de clase que inicializa el atributo random
		/// </summary>
		static Profesor()
		{
			random = new Random();
		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="id"></param>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		public Profesor(int id,string nombre,string apellido,string dni,ENacionalidad nacionalidad)
			:base(id,nombre,apellido,dni,nacionalidad)
		{
			this.clasesDelDia = new Queue<Universidad.EClases>();
			_randomClases();
		}

		/// <summary>
		/// retorna en formato de srting los datos de un profesor
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.MostrarDatos();
		}
	}
}
