namespace MiCalculadora
{
	partial class FormCalculadora
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblResultado = new System.Windows.Forms.Label();
			this.btnConvertirADecimal = new System.Windows.Forms.Button();
			this.btnLimpiar = new System.Windows.Forms.Button();
			this.btnCerrar = new System.Windows.Forms.Button();
			this.btnOperar = new System.Windows.Forms.Button();
			this.btnConvertirABinario = new System.Windows.Forms.Button();
			this.cmbOperador = new System.Windows.Forms.ComboBox();
			this.txtNumero1 = new System.Windows.Forms.TextBox();
			this.txtNumero2 = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblResultado
			// 
			this.lblResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblResultado.Location = new System.Drawing.Point(12, 9);
			this.lblResultado.Name = "lblResultado";
			this.lblResultado.Size = new System.Drawing.Size(369, 23);
			this.lblResultado.TabIndex = 0;
			this.lblResultado.Text = "Resultado";
			this.lblResultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnConvertirADecimal
			// 
			this.btnConvertirADecimal.Location = new System.Drawing.Point(206, 191);
			this.btnConvertirADecimal.Name = "btnConvertirADecimal";
			this.btnConvertirADecimal.Size = new System.Drawing.Size(175, 44);
			this.btnConvertirADecimal.TabIndex = 8;
			this.btnConvertirADecimal.Text = "Convertir a decimal";
			this.btnConvertirADecimal.UseVisualStyleBackColor = true;
			this.btnConvertirADecimal.Click += new System.EventHandler(this.BtnConvertirADecimal_Click);
			// 
			// btnLimpiar
			// 
			this.btnLimpiar.Location = new System.Drawing.Point(146, 136);
			this.btnLimpiar.Name = "btnLimpiar";
			this.btnLimpiar.Size = new System.Drawing.Size(108, 36);
			this.btnLimpiar.TabIndex = 5;
			this.btnLimpiar.Text = "Limpiar";
			this.btnLimpiar.UseVisualStyleBackColor = true;
			this.btnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
			// 
			// btnCerrar
			// 
			this.btnCerrar.Location = new System.Drawing.Point(273, 136);
			this.btnCerrar.Name = "btnCerrar";
			this.btnCerrar.Size = new System.Drawing.Size(108, 36);
			this.btnCerrar.TabIndex = 6;
			this.btnCerrar.Text = "Cerrar";
			this.btnCerrar.UseVisualStyleBackColor = true;
			this.btnCerrar.Click += new System.EventHandler(this.BtnCerrar_Click);
			// 
			// btnOperar
			// 
			this.btnOperar.Location = new System.Drawing.Point(12, 136);
			this.btnOperar.Name = "btnOperar";
			this.btnOperar.Size = new System.Drawing.Size(108, 36);
			this.btnOperar.TabIndex = 4;
			this.btnOperar.Text = "Operar";
			this.btnOperar.UseVisualStyleBackColor = true;
			this.btnOperar.Click += new System.EventHandler(this.BtnOperar_Click);
			// 
			// btnConvertirABinario
			// 
			this.btnConvertirABinario.Location = new System.Drawing.Point(25, 191);
			this.btnConvertirABinario.Name = "btnConvertirABinario";
			this.btnConvertirABinario.Size = new System.Drawing.Size(175, 44);
			this.btnConvertirABinario.TabIndex = 7;
			this.btnConvertirABinario.Text = "Convertir a binario";
			this.btnConvertirABinario.UseVisualStyleBackColor = true;
			this.btnConvertirABinario.Click += new System.EventHandler(this.BtnConvertirABinario_Click);
			// 
			// cmbOperador
			// 
			this.cmbOperador.AllowDrop = true;
			this.cmbOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOperador.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cmbOperador.FormattingEnabled = true;
			this.cmbOperador.IntegralHeight = false;
			this.cmbOperador.Items.AddRange(new object[] {
            "+",
            "/",
            "-",
            "*"});
			this.cmbOperador.Location = new System.Drawing.Point(146, 45);
			this.cmbOperador.Name = "cmbOperador";
			this.cmbOperador.Size = new System.Drawing.Size(37, 37);
			this.cmbOperador.TabIndex = 2;
			// 
			// txtNumero1
			// 
			this.txtNumero1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumero1.Location = new System.Drawing.Point(12, 45);
			this.txtNumero1.Name = "txtNumero1";
			this.txtNumero1.Size = new System.Drawing.Size(113, 31);
			this.txtNumero1.TabIndex = 1;
			// 
			// txtNumero2
			// 
			this.txtNumero2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtNumero2.Location = new System.Drawing.Point(267, 44);
			this.txtNumero2.Name = "txtNumero2";
			this.txtNumero2.Size = new System.Drawing.Size(113, 31);
			this.txtNumero2.TabIndex = 3;
			// 
			// FormCalculadora
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(393, 257);
			this.Controls.Add(this.txtNumero2);
			this.Controls.Add(this.txtNumero1);
			this.Controls.Add(this.cmbOperador);
			this.Controls.Add(this.btnConvertirABinario);
			this.Controls.Add(this.btnOperar);
			this.Controls.Add(this.btnCerrar);
			this.Controls.Add(this.btnLimpiar);
			this.Controls.Add(this.btnConvertirADecimal);
			this.Controls.Add(this.lblResultado);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormCalculadora";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Calculadora de Lautaro Medeiros del curso 2°A";
			this.Load += new System.EventHandler(this.FormCalculadora_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblResultado;
		private System.Windows.Forms.Button btnConvertirADecimal;
		private System.Windows.Forms.Button btnLimpiar;
		private System.Windows.Forms.Button btnCerrar;
		private System.Windows.Forms.Button btnOperar;
		private System.Windows.Forms.Button btnConvertirABinario;
		private System.Windows.Forms.ComboBox cmbOperador;
		private System.Windows.Forms.TextBox txtNumero1;
		private System.Windows.Forms.TextBox txtNumero2;
	}
}

