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

		public ENacionalidad Nacionalidad
		{
			get
			{
				return this.nacionalidad;
			}
			set
			{
				this.nacionalidad = value;
			}
		}

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

		public string StringToDni
		{
			set
			{
				this.dni = this.ValidarDni(this.Nacionalidad,value);
			}
		}

		public Persona()
		{

		}

		public Persona(string nombre,string apellido,ENacionalidad nacionalidad)
		{
			this.Nombre = nombre;
			this.Apellido = apellido;
			this.nacionalidad = nacionalidad;
		}

		public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad)
			:this(nombre,apellido,nacionalidad)
		{
			this.DNI = dni;
		}

		public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad)
			:this(nombre,apellido,nacionalidad)
		{
			this.StringToDni = dni;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("NOMBRE COMPLETO: " + Nombre + ", " + Apellido);
			sb.AppendLine("NACIONALIDAD: " + Nacionalidad);
			return sb.ToString();
		}

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

		public int ValidarDni(ENacionalidad nacionalidad,string dato)
		{
			return (ValidarDni(nacionalidad,int.Parse(dato)));
		}

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
