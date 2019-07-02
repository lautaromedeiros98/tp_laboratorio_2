using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
	public class DniInvalidoException : Exception
	{
		private const string mensajeBase = "Dni invalido";

		public DniInvalidoException() 
			: this(mensajeBase)
		{

		}
		public DniInvalidoException(Exception ex) 
			: this(mensajeBase, ex)
		{

		}
		public DniInvalidoException(string mensaje) 
			: this(mensaje, null)
		{

		}
		public DniInvalidoException(string mensaje, Exception ex) 
			: base(mensaje, ex)
		{

		}
	}
}
