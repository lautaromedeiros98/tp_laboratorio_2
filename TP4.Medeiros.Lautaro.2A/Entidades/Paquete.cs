using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete
    {
		private string direccionEntrega;
		private EEstado estado;
		private string trackingID;

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

		public string TrackingID
		{
			get
			{
				return this.trackingID;
			}
			set
			{
				this.trackingID = value;
			}
		}

		public void MockCicloDeVida()
		{

		}

		public string MostrarDatos(IMostrar<Paquete> elemento)
		{
			return "";
		}

		public static bool operator !=(Paquete p1, Paquete p2)
		{
			return !(p1 == p2);
		}

		public static bool operator ==(Paquete p1, Paquete p2)
		{
			return true;
		}

		public Paquete(string direccionEntrega,string trackingID)
		{
			this.DireccionEntrega = direccionEntrega;
			this.TrackingID = trackingID;
		}

		public override string ToString()
		{
			return base.ToString();
		}

		public enum DelegadoEstado
		{
			Delegado
		}

		public enum EEstado
		{
			Ingresado,
			EnViaje,
			Entregado
		}
	}
}
