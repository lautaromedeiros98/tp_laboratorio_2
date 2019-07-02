using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
		private string apellido;
		private int dni;
		private ENacionalidad nacionalidad;
		private string nombre;

		/// <summary>
		/// Retorna el valor del atributo apellido de una persona
		/// Asigna valor al atributo apellido de una persona si este es valido
		/// </summary>
		public string Apellido
		{
			get
			{
				return this.apellido;
			}
			set
			{
				this.apellido=this.ValidarNombreApellido(value);
			}
		}

		/// <summary>
		/// Retorna el valor del atributo dni de una persona
		/// Asigna valor al atributo dni de una persona si este es valido
		/// </summary>
		public int DNI
		{
			get
			{
				return this.dni;
			}
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad,value);
			}
		}

		/// <summary>
		/// <summary>
		/// Retorna el valor del atributo nacionalidad de una persona
		/// Asigna valor al nacionalidad dni de una persona si este es valido
		/// </summary>
		/// </summary>
		public ENacionalidad Nacionalidad
		{
			get
			{
				return this.nacionalidad;
			}
			set
			{
				if(value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
				{
					this.nacionalidad = value;
				}
			}
		}

		/// <summary>
		/// Retorna el valor del atributo nombre de una persona
		/// Asigna valor al nombre dni de una persona si este es valido
		/// </summary>
		public string Nombre
		{
			get
			{
				return this.nombre;
			}
			set
			{
				this.nombre = this.ValidarNombreApellido(value);
			}
		}

		/// <summary>
		/// Retorna el valor del atributo dni de una persona
		/// Asigna valor al atributo dni de una persona si este es valido
		/// </summary>
		public string StringToDni
		{
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad,value);
			}
		}

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public Persona()
		{

		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="nacionalidad"></param>
		public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
		{
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.nacionalidad = nacionalidad;
		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad)
			:this(nombre,apellido,nacionalidad)
		{
			this.DNI = dni;
		}

		/// <summary>
		/// Constructor que inicializa los parametros si estos son validos
		/// </summary>
		/// <param name="nombre"></param>
		/// <param name="apellido"></param>
		/// <param name="dni"></param>
		/// <param name="nacionalidad"></param>
		public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad)
			:this(nombre,apellido,nacionalidad)
		{
			this.StringToDni = dni;
		}

		/// <summary>
		/// Retorna los datos de una persona en forma de string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("NOMBRE COMPLETO: " + Nombre + ", " + Apellido);
			sb.AppendLine("NACIONALIDAD: " + Nacionalidad);
			return sb.ToString();
		}

		/// <summary>
		/// Valida que el dato sea un dni valido y que corresponda a una nacionalidad valida
		/// </summary>
		/// <param name="nacionalidad"></param>
		/// <param name="dato"></param>
		/// <returns></returns>
		public int ValidarDni(ENacionalidad nacionalidad,int dato)
		{
			int auxiliar;
			if(int.TryParse(dato.ToString(),out auxiliar))
			{
				if (nacionalidad == ENacionalidad.Argentino && auxiliar >= 1 && auxiliar <= 89999999 || nacionalidad == ENacionalidad.Extranjero && auxiliar > 89999999 && auxiliar <= 99999999)
				{
					return auxiliar;
				}
				else
				{
					throw new NacionalidadInvalidaException("La nacionalidad no se condice con el  numero de DNI");
				}
			}
			else
			{
				throw new DniInvalidoException("Dni invalido");
			}
		}

		/// <summary>
		/// Valida que el dato sea un dni valido y que corresponda a una nacionalidad valida
		/// </summary>
		/// <param name="nacionalidad"></param>
		/// <param name="dato"></param>
		/// <returns></returns>
		public int ValidarDni(ENacionalidad nacionalidad,string dato)
		{
			return (ValidarDni(nacionalidad,int.Parse(dato)));
		}

		/// <summary>
		/// Valida que el dato sea un nombre o un apellido valido
		/// </summary>
		/// <param name="dato"></param>
		/// <returns></returns>
		public string ValidarNombreApellido(string dato)
		{
			foreach(char a in dato)
			{
				if(!((a >= 'a' && a <= 'z') || (a >= 'A' && a <= 'Z') || (a == ' ')))
				{
					return "";
				}
			}
			return dato;
		}

		public enum ENacionalidad
		{
			Argentino,
			Extranjero
		}
    }
}
