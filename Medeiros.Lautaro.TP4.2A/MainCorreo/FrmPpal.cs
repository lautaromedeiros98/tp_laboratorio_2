using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
	public partial class FrmPpal : Form
	{
		private Correo correo;
		public FrmPpal()
		{
			InitializeComponent();
			this.correo = new Correo();
			this.FormClosing += new FormClosingEventHandler(this.FrmPla_FormClosing);
		}
		/// <summary>
		/// Llama al metodo FinEntregas para finalizar los hilos en ejecucion
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmPla_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.correo.FinEntregas();
		}

		/// <summary>
		/// Agrega un paquete al correo si el paquete no pertenece al mismo y lo agrega a la base de datos
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnAgregar_Click(object sender, EventArgs e)
		{
			Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
			paquete.InformeEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
			try
			{
				this.correo += paquete;
			}
			catch (TrackingIdRepetidoException a)
			{
				MessageBox.Show(a.Message, "Paquete Repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
			}
			this.ActualizarEstados();
		}

		/// <summary>
		/// muestra el listado de todos los paquetes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMostrarTodos_Click(object sender, EventArgs e)
		{
			this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
		}

		/// <summary>
		/// Limpia los listBox y acomoda los paquetes segun su estado
		/// </summary>
		private void ActualizarEstados()
		{
			this.lstEstadoIngresado.Items.Clear();
			this.lstEstadoEnViaje.Items.Clear();
			this.lstEstadoEntregado.Items.Clear();

			foreach (Paquete paquete in this.correo.Paquetes)
			{
				switch (paquete.Estado)
				{
					case Paquete.EEstado.Ingresado:
						this.lstEstadoIngresado.Items.Add(paquete);
						break;

					case Paquete.EEstado.EnViaje:
						this.lstEstadoEnViaje.Items.Add(paquete);
						break;

					case Paquete.EEstado.Entregado:
						this.lstEstadoEntregado.Items.Add(paquete);
						break;
				}
			}
		}

		/// <summary>
		/// LLama al metodo acutalizarEstados()
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void paq_InformaEstado(object sender, EventArgs e)
		{
			if (this.InvokeRequired)
			{
				Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
				this.Invoke(d, new object[] { sender, e });
			}
			else
			{
				this.ActualizarEstados();
			}
		}

		/// <summary>
		/// Muestra la informacion en el rich text box y guarda los datos en el archivo de texto en el escritorio
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="elemento"></param>
		private void MostrarInformacion<T>(IMostrar<T> elemento)
		{
			if (!Object.Equals(elemento, null))
			{
				string datos = this.correo.MostrarDatos(this.correo);
				this.rtbMostrar.Text = datos;

				try
				{
					datos.Guardar("salida.txt");
				}
				catch (Exception)
				{
					MessageBox.Show("Error al guardar el txt");
				}
			}
		}

		/// <summary>
		/// Al hacer click derecho sobre un paquete entregado se mostrara en el rich text box
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.rtbMostrar.Text = this.lstEstadoEntregado.SelectedItem.ToString();
		}
	}
}
