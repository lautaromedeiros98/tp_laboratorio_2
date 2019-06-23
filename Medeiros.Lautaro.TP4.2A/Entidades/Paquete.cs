using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
	public class Paquete : IMostrar<Paquete>
	{
		#region Atributos
		private string direccionEntrega;
		private EEstado estado;
		private string trackingId;
		#endregion

		#region Eventos
		public event DelegadoEstado InformeEstado;
		#endregion

		#region
		public string DireccionEntrega
		{
			get
			{
				return this.direccionEntrega;
			}
			set
			{
				this.direccionEntrega = value;
			}
		}

		public EEstado Estado
		{
			get
			{
				return this.estado;
			}
			set
			{
				this.estado = value;
			}
		}

		public string TrackingId
		{
			get
			{
				return this.trackingId;
			}
			set
			{
				this.trackingId = value;
			}
		}
		#endregion

		#region Metodos
		/// <summary>
		/// Actualiza el estado de un paquete
		/// </summary>
		public void MockCicloDeVida()
		{
			while (this.Estado != EEstado.Entregado)
			{
				Thread.Sleep(4000);
				this.Estado++;
				this.InformeEstado(null, null);
			}
			if (this.Estado == EEstado.Entregado)
			{
				try
				{
					PaqueteDAO.Insertar(this);
				}
				catch (Exception e)
				{
					throw e;
				}
			}
		}
		/// <summary>
		/// Muestra los datos de un paquete
		/// </summary>
		/// <param name="elemento"></param>
		/// <returns></returns>
		public string MostrarDatos(IMostrar<Paquete> elemento)
		{
			return string.Format("{0} para {1}", ((Paquete)elemento).trackingId, ((Paquete)elemento).direccionEntrega);
		}

		/// <summary>
		/// Compara los tracking id de 2 paquetes retornando true si son iguales, caso contrario false
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		public static bool operator !=(Paquete p1,Paquete p2)
		{
			return !(p1 == p2);
		}

		/// <summary>
	    /// Compara los tracking id de 2 paquetes retornando true si son iguales, caso contrario false
		/// </summary>
		/// <param name="p1"></param>
		/// <param name="p2"></param>
		/// <returns></returns>
		public static bool operator ==(Paquete p1,Paquete p2)
		{
			if(p1.TrackingId == p2.TrackingId)
			{
				return true;
			}
			return false;
		}
		
		public Paquete(string direccionEntrega,string trakingId)
		{
			this.DireccionEntrega = direccionEntrega;
			this.TrackingId = trakingId;
		}

		/// <summary>
		/// Retorna los datos de un paquete en forma string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return this.MostrarDatos(this);
		}
		#endregion

		#region Tipos Anidados
		public delegate void DelegadoEstado(object sender, EventArgs args);
		public enum EEstado
		{
			Ingresado,
			EnViaje,
			Entregado
		}
		#endregion
	}
}
