using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
		private double numero;

		/// <summary>
		/// Propiedad privada la cual setea el numero ya validado
		/// </summary>
		private string SetNumero
		{
			set
			{
				this.numero = ValidarNumero(value);
			}
		}

		/// <summary>
		/// Convierte un numero binario a decimal
		/// </summary>
		/// <param name="binario"></param>
		/// <returns></returns>Retorna el numero convertido
		public static string BinarioDecimal(string binario)
		{
			char[] aux = binario.ToCharArray();
			Array.Reverse(aux);
			double auxDecimal = 0;
			int tamanio = binario.Length;
			int i;
			for (i = 0; i < tamanio; i++)
			{
				if (aux[i] != '0' && aux[i] != '1')
				{
					return "0";
				}
			}
			for (i = 0; i < tamanio; i++)
			{
				if (aux[i] == '1')
				{
					auxDecimal = auxDecimal + Math.Pow(2, i);
				}
			}
			return string.Format("{0}", auxDecimal);
		}

		/// <summary>
		/// Convierte un numero decimal a binario
		/// </summary>
		/// <param name="numero"></param>
		/// <returns></returns>Retorna el numero convertido
		public static string DecimalBinario(double numero)
		{
			string binario = "";
			if (numero >= 0)
			{
				while (numero > 0)
				{
					if (numero % 2 == 0)
					{
						binario = "0" + binario;
					}
					else
					{
						binario = "1" + binario;
					}
					numero = (int)numero / 2;
				}
			}
			else
			{
				return null;
			}
			return binario;
		}

		/// <summary>
		/// Convierte un numero decimal a binario
		/// </summary>
		/// <param name="numero"></param>
		/// <returns></returns> Retorna el numero convertido
		public static string DecimalBinario(string numero)
		{
			double d;
			if (double.TryParse(numero, out d))
			{
				return DecimalBinario(d);
			}
			return "0";
		}

		/// <summary>
		/// Constructor por defecto , inicializa el numero en 0
		/// </summary>
		public Numero()
		{
			this.numero = 0;
		}

		/// <summary>
		/// Constructor que inicializa el numero con elparametro recibido
		/// </summary>
		/// <param name="numero"></param>
		public Numero(double numero)
		{
			this.numero = numero;
		}

		/// <summary>
		/// Convierte el parametro string a double y lo setea
		/// </summary>
		/// <param name="strNumero"></param>
		public Numero(string strNumero) 
		{
			SetNumero = strNumero;
		}

		/// <summary>
		/// Sobrecarga de operador que realiza la resta entre dos objetos de tipo Numero
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns></returns> Resultado de dicha operacion
		public static double operator -(Numero n1,Numero n2)
		{
			return n1.numero - n2.numero;
		}

		/// <summary>
		/// Sobrecarga de operador que realiza la multiplicacion entre dos objetos de tipo Numero
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns></returns>Retorna el resultado de dicha operacion
		public static double operator *(Numero n1, Numero n2)
		{
			return n1.numero * n2.numero;
		}

		/// <summary>
		/// Sobrecarga de operador que realiza la division entre dos objetos de tipo Numero diferentes de "0"
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns></returns>Retorna el resultado de dicha operacion
		public static double operator /(Numero n1, Numero n2)
		{
			if(n2.numero == 0)
			{
				return double.MinValue;
			}
			return n1.numero / n2.numero;
		}

		/// <summary>
		/// Sobrecarga de operador que realiza la suma entre dos objetos de tipo Numero
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns></returns>Retorna el resultado de dicha operacion
		public static double operator +(Numero n1, Numero n2)
		{
			return n1.numero + n2.numero;
		}

		/// <summary>
		/// Valida que el dato recibido sea un numero valido
		/// </summary>
		/// <param name="strNumero"></param>
		/// <returns></returns>El numero validado ,caso contrario "0"
		private static double ValidarNumero(string strNumero)
		{
			double retorno;
			if(double.TryParse(strNumero,out retorno))
			{
				return retorno;
			}
			return 0;
		}

		/// <summary>
		/// Metodo auxiliar que verifica si un numero es binario
		/// </summary>
		/// <param name="numero"></param>
		/// <returns></returns>True si el numeor es binario, False si el numero no es binario
		/// <returns></returns>True si el numeor es binario, False si el numero no es binario
		public static bool EsBinario(string numero)
		{
			foreach(char e in numero)
			{
				if(!e.Equals('0') && !e.Equals('1'))
				{
					return false;
				}
			}
			return true;
		}
	}
}
