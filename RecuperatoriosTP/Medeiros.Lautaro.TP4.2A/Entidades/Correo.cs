using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
	public class Correo :IMostrar<List<Paquete>>
	{
		private List<Thread> mockPaquetes;
		private List<Paquete> paquetes;

		public List<Paquete> Paquetes
		{
			get
			{
				return this.paquetes;
			}
			set
			{
				this.paquetes = value;
			}
		}

		public Correo()
		{
			this.mockPaquetes = new List<Thread>();
			this.paquetes = new List<Paquete>();
		}

		/// <summary>
		/// Finaliza todos los hilos en ejecucion
		/// </summary>
		public void FinEntregas()
		{
			foreach(Thread item in this.mockPaquetes)
			{
				item.Abort();
			}
		}

		/// <summary>
		/// Muestra los datos del correo y cada uno de sus paquetes con su estado
		/// </summary>
		/// <param name="elementos"></param>
		/// <returns></returns>
		public string MostrarDatos(IMostrar<List<Paquete>> elementos)
		{
			StringBuilder retorno = new StringBuilder();
			if (!object.Equals(elementos, null))
			{
				foreach (Paquete p in ((Correo)elementos).Paquetes)
				{
					retorno.AppendLine(string.Format("{0} para {1} ({2})\r", p.TrackingId, p.DireccionEntrega, p.Estado.ToString()));
				}
			}

			return retorno.ToString();
		}

		/// <summary>
		/// Agrega un paquete a un correo si el paquete no pertenece al mismo
		/// </summary>
		/// <param name="c"></param>
		/// <param name="p"></param>
		/// <returns></returns>
		public static Correo operator +(Correo c,Paquete p)
		{
			foreach(Paquete item in c.Paquetes)
			{
				if(p==item)
				{
					throw new TrackingIdRepetidoException("Id repetido");
				}
			}
			c.Paquetes.Add(p);
			Thread hilo = new Thread(p.MockCicloDeVida);
			c.mockPaquetes.Add(hilo);
			hilo.Start();
			return c;
		}
	}
}
