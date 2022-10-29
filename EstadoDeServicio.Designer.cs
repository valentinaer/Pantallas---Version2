namespace grupoB_TP
{
    partial class EstadoDeServicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumeroTrackeo = new System.Windows.Forms.Label();
            this.txtTrackeo = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Purple;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el Nº de trackeo para conocer el estado del servicio:";
            // 
            // lblNumeroTrackeo
            // 
            this.lblNumeroTrackeo.AutoSize = true;
            this.lblNumeroTrackeo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNumeroTrackeo.Location = new System.Drawing.Point(158, 42);
            this.lblNumeroTrackeo.Name = "lblNumeroTrackeo";
            this.lblNumeroTrackeo.Size = new System.Drawing.Size(108, 21);
            this.lblNumeroTrackeo.TabIndex = 1;
            this.lblNumeroTrackeo.Text = "Nº de trackeo:";
            // 
            // txtTrackeo
            // 
            this.txtTrackeo.Location = new System.Drawing.Point(139, 66);
            this.txtTrackeo.Name = "txtTrackeo";
            this.txtTrackeo.Size = new System.Drawing.Size(149, 23);
            this.txtTrackeo.TabIndex = 2;
            this.txtTrackeo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(172, 95);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 26);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // EstadoDeServicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(438, 130);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtTrackeo);
            this.Controls.Add(this.lblNumeroTrackeo);
            this.Controls.Add(this.label1);
            this.Name = "EstadoDeServicio";
            this.Text = "Estado del Servicio";
            this.Load += new System.EventHandler(this.EstadoDeServicio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                    e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion

        private Label label1;
        private Label lblNumeroTrackeo;
        private TextBox txtTrackeo;
        private Button btnBuscar;
    }
}