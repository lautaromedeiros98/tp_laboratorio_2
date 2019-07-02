using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
	[TestClass]
	public class Tests
	{
		/// <summary>
		/// Verifica que la lista de paquetes este inicializada 
		/// </summary>
		[TestMethod]
		public void PaqueteCorreoNull()
		{
			Correo correo = new Correo();
			Assert.IsNotNull(correo);
			Assert.IsTrue(true);			
		}

		/// <summary>
		/// Verifica que no se puedan cargar 2 paqueetes con un mismo id
		/// </summary>
		[TestMethod]
		public void TestTrackingIdIguales()
		{
			Correo correo = new Correo();
			Paquete p1 = new Paquete("Siempre viva", "123433");
			Paquete p2 = new Paquete("Siempre viva", "123433");
			try
			{
				correo += p1;
				correo += p2;
			}
			catch (TrackingIdRepetidoException)
			{
				Assert.IsTrue(true);
			}			
		}
	}
}
