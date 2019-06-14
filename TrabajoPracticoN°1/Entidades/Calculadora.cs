using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
	public static class Calculadora
	{
		/// <summary>
		/// Realiza la operacion aritmetica con los parametros recibidos
		/// </summary>
		/// <param name="num1"></param>
		/// <param name="num2"></param>
		/// <param name="operador"></param>
		/// <returns></returns>El resultado de dicha operacion
		public static double Operar(Numero num1,Numero num2,string operador)
		{
			switch(ValidarOperador(operador))
			{
				case "*":
					return num1 * num2;
				case "/":
					return num1 / num2;
				case "-":
					return num1 - num2;
				case "+":
					return num1 + num2;
			}
			return num1 + num2;
		}

		/// <summary>
		/// Valida que el dato ingresado sea "+","-","*" o "/"
		/// </summary>
		/// <param name="operador"></param>
		/// <returns></returns> si es un operador valido retorna el mismo , caso contrario retornará "+"
		private static string ValidarOperador(string operador)
		{
			switch(operador)
			{
				case "*":
					return "*";
				case "/":
					return "/";
				case "-":
					return "-";
				default:
					return "+";
			}
		}
	}
}
