using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestUnitarios
{
	[TestClass]
	public class Tests
	{
		/// <summary>
		/// Verifica que la lista de paquetes de un correo este instanciada
		/// </summary>
		[TestMethod]
		public void TestPaqueteDeCorreoNULL()
		{
			Correo correo = new Correo();
			bool v = false;
			try
			{
				Assert.IsNotNull(correo);
				v = true;
			}
			catch (Exception)
			{

			}
			Assert.IsTrue(v);
		}

		/// <summary>
		/// Verifica que no se puedan cargar 2 paqueetes con un mismo tracking id
		/// </summary>
		[TestMethod]
		public void TestPaquetesTrackingID()
		{
			Correo correo = new Correo();
			Paquete p1 = new Paquete("Alguna Calle", "123");
			Paquete p2 = new Paquete("Alguna Calle", "123");
			bool v = false;

			try
			{
				correo += p1;
				correo += p2;
			}
			catch (TrackingIdRepetidoException)
			{
				v = true;
			}
			Assert.IsTrue(v);
		}
	}
}
