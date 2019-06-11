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
			Universidad gim = new Universidad();
			Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
		   Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
		   Alumno.EEstadoCuenta.Becado);
			Alumno a2 = new Alumno(1, "Juan", "Lopez", "12234456",
		   Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
		   Alumno.EEstadoCuenta.Becado);
			try
			{
				gim += a1;
				gim += a2;
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(AlumnoRepetidoException));
			}
		}

		/// <summary>
		/// Test de la Excepcion DniInvalido
		/// </summary>
		[TestMethod]
		public void TestExceptionDniInvalido()
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
		/// Test del validar Dni cuando no corresponde a su nacionalidad, o teset de NacionalidadInvalida
		/// </summary>
		[TestMethod]
		public void TestDniValidoParaNacionalidad()
		{
			try
			{
				Alumno a1 = new Alumno(1, "Pedro", "Lopez", "91000000", Clases_Abstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.SPD, Alumno.EEstadoCuenta.AlDia);
			}
			catch (Exception ex)
			{
				Assert.IsInstanceOfType(ex, typeof(NacionalidadInvalidaException));
			}
		}

		/// <summary>
		/// Test de que al crear una universidad sus atributos no queden en null
		/// </summary>
		[TestMethod]
		public void TestAtributosNull()
		{
			Universidad uni = new Universidad();
			if (uni.Alumnos is null || uni.Jornadas is null || uni.Instructores is null)
				Assert.IsTrue(false);
			Assert.IsTrue(true);
		}

	}
}
