namespace grupoB_TP
{
    partial class MenuPrincipal
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
            this.rboSolicitarServicio = new System.Windows.Forms.RadioButton();
            this.rboConsultarEstadoDeCuenta = new System.Windows.Forms.RadioButton();
            this.rboConsultarEstadoDeServicio = new System.Windows.Forms.RadioButton();
            this.lblMenuPrincipal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnContinuar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rboSolicitarServicio
            // 
            this.rboSolicitarServicio.AutoSize = true;
            this.rboSolicitarServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rboSolicitarServicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rboSolicitarServicio.Location = new System.Drawing.Point(23, 42);
            this.rboSolicitarServicio.Name = "rboSolicitarServicio";
            this.rboSolicitarServicio.Size = new System.Drawing.Size(147, 25);
            this.rboSolicitarServicio.TabIndex = 0;
            this.rboSolicitarServicio.TabStop = true;
            this.rboSolicitarServicio.Text = "Solicitar Servicio ";
            this.rboSolicitarServicio.UseVisualStyleBackColor = true;
            // 
            // rboConsultarEstadoDeCuenta
            // 
            this.rboConsultarEstadoDeCuenta.AutoSize = true;
            this.rboConsultarEstadoDeCuenta.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rboConsultarEstadoDeCuenta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rboConsultarEstadoDeCuenta.Location = new System.Drawing.Point(23, 165);
            this.rboConsultarEstadoDeCuenta.Name = "rboConsultarEstadoDeCuenta";
            this.rboConsultarEstadoDeCuenta.Size = new System.Drawing.Size(219, 25);
            this.rboConsultarEstadoDeCuenta.TabIndex = 1;
            this.rboConsultarEstadoDeCuenta.TabStop = true;
            this.rboConsultarEstadoDeCuenta.Text = "Consultar Estado de Cuenta";
            this.rboConsultarEstadoDeCuenta.UseVisualStyleBackColor = true;
            // 
            // rboConsultarEstadoDeServicio
            // 
            this.rboConsultarEstadoDeServicio.AutoSize = true;
            this.rboConsultarEstadoDeServicio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rboConsultarEstadoDeServicio.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rboConsultarEstadoDeServicio.Location = new System.Drawing.Point(23, 104);
            this.rboConsultarEstadoDeServicio.Name = "rboConsultarEstadoDeServicio";
            this.rboConsultarEstadoDeServicio.Size = new System.Drawing.Size(225, 25);
            this.rboConsultarEstadoDeServicio.TabIndex = 4;
            this.rboConsultarEstadoDeServicio.TabStop = true;
            this.rboConsultarEstadoDeServicio.Text = "Consultar Estado de Servicio";
            this.rboConsultarEstadoDeServicio.UseVisualStyleBackColor = true;
            // 
            // lblMenuPrincipal
            // 
            this.lblMenuPrincipal.AutoSize = true;
            this.lblMenuPrincipal.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMenuPrincipal.ForeColor = System.Drawing.Color.Purple;
            this.lblMenuPrincipal.Location = new System.Drawing.Point(12, 20);
            this.lblMenuPrincipal.Name = "lblMenuPrincipal";
            this.lblMenuPrincipal.Size = new System.Drawing.Size(0, 25);
            this.lblMenuPrincipal.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rboConsultarEstadoDeServicio);
            this.groupBox1.Controls.Add(this.rboConsultarEstadoDeCuenta);
            this.groupBox1.Controls.Add(this.rboSolicitarServicio);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Purple;
            this.groupBox1.Location = new System.Drawing.Point(25, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 212);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecciona la operación a realizar:";
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnContinuar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnContinuar.Location = new System.Drawing.Point(116, 238);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(127, 33);
            this.btnContinuar.TabIndex = 7;
            this.btnContinuar.Text = "Continuar";
            this.btnContinuar.UseVisualStyleBackColor = false;
            this.btnContinuar.Click += new System.EventHandler(this.btnContinuar_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(374, 286);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblMenuPrincipal);
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Name = "MenuPrincipal";
            this.Text = "|";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadioButton rboSolicitarServicio;
        private RadioButton rboConsultarEstadoDeCuenta;
        private RadioButton rboConsultarEstadoDeServicio;
        private RadioButton rboS;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Label lblMenuPrincipal;
        private GroupBox groupBox1;
        private Button btnContinuar;
    }
}