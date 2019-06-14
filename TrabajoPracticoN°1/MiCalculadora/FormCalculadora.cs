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

namespace MiCalculadora
{
	public partial class FormCalculadora : Form
	{
		public FormCalculadora()
		{
			InitializeComponent();
		}

		private void FormCalculadora_Load(object sender, EventArgs e)
		{
			this.cmbOperador.AutoSize = false;
			this.txtNumero1.AutoSize = false;
			this.txtNumero2.AutoSize = false;

			this.cmbOperador.Size = new System.Drawing.Size(100, 70);
			this.txtNumero1.Size = new System.Drawing.Size(113, 40);
			this.txtNumero2.Size = new System.Drawing.Size(113, 40);
		}

		/// <summary>
		/// Limpia los TextBox y el ComboBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnLimpiar_Click(object sender, EventArgs e)
		{
			txtNumero1.Clear();
			txtNumero2.Clear();
			cmbOperador.Text= "";
		}

		/// <summary>
		/// Realiza la operacion y muestra el resultado
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOperar_Click(object sender, EventArgs e)
		{
			if(!Equals(txtNumero1.Text,""))
			{
				if(!Equals(txtNumero2.Text, ""))
				{
					if(Equals(cmbOperador.Text,""))
					{
						lblResultado.Text = (Calculadora.Operar(new Numero(txtNumero1.Text), new Numero(txtNumero2.Text), "+")).ToString();
					}
					else
					{
						lblResultado.Text = (Calculadora.Operar(new Numero(txtNumero1.Text), new Numero(txtNumero2.Text), cmbOperador.SelectedItem.ToString())).ToString();					
					}
				}
			}
		}

		/// <summary>
		/// Cierra la aplicacion
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnCerrar_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Convierte el resultado a binario
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnConvertirABinario_Click(object sender, EventArgs e)
		{
			if (!Equals(lblResultado.Text, "Resultado"))
			{
				lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
			}
		}

		/// <summary>
		/// Convierte el resultado binario a decimal
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnConvertirADecimal_Click(object sender, EventArgs e)
		{
			if (Numero.EsBinario(lblResultado.Text))
			{
				lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
			}
		}
	}
}
