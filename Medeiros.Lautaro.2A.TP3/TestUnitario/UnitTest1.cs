using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using Clases_Abstractas;
using Archivos;
using Excepciones;


namespace TestUnitario
{
	[TestClass]
	public class UnitTest1
	{
		/// <summary>
		/// Test de la excepcion AlumnoRepetido
		/// </summary>
		[TestMethod]
		public void TestExceptionAlumnoRepetido()
		{
			Universidad universidad = new Universidad();
			Alumno a1 = new Alumno(1, "Dran", "Lopez", "41551423",Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
		   Alumno.EEstadoCuenta.Becado);
			Alumno a2 = new Alumno(1, "Dran", "Lopez", "41551423", Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
		   Alumno.EEstadoCuenta.Becado);
			try
			{
				universidad	 += a1;
				universidad	 += a2;
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
			}
		}

		/// <summary>
		/// Verifica un dni que sea valido
		/// </summary>
		[TestMethod]
		public void TestExceptionDniInvalido()
		{
			try
			{
				Alumno a1 = new Alumno(1, "Pedro", "Lopez", "abc123", Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion, Alumno.EEstadoCuenta.Deudor);
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(DniInvalidoException));
			}
		}

		/// <summary>
		/// Valida el dni y la nacionalidad
		/// </summary>
		[TestMethod]
		public void TestDniValidoParaNacionalidad()
		{
			try
			{
				Alumno a1 = new Alumno(1, "Pedro", "Lopez", "sssdds455", Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(DniInvalidoException));
			}
		}

		/// <summary>
		/// Verifica que los atributos de la universidad esten inicializados
		/// </summary>
		[TestMethod]
		public void TestAtributosNull()
		{
			Universidad universidad = new Universidad();
			if (universidad.Alumnos is null || universidad.Jornadas is null || universidad.Instructores is null)
			{
				Assert.IsTrue(false);
			}
			Assert.IsTrue(true);
		}

	}
}
