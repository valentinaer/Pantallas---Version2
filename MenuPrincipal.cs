using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version_2___Pantallas;

namespace grupoB_TP
{
    internal partial class MenuPrincipal : Form
    {
        public MenuPrincipal(string cuit)
        {
            InitializeComponent();
            MessageBox.Show(cuit);
            CUIT cuitpasaje = new CUIT(cuit);      

        }
        public void btnContinuar_Click(object sender, EventArgs e)
        {
            CUIT c= new CUIT();
            string CUITpasar= c.DevolverCUIT();

            if (rboSolicitarServicio.Checked)
            {
                
                new SolicitudDeServicio().ShowDialog();
            }
            if (rboConsultarEstadoDeServicio.Checked)
            {
                
                new EstadoDeServicio().ShowDialog();
            }
            if (rboConsultarEstadoDeCuenta.Checked)
            {
               
                new EstadoDeCuenta(CUITpasar).ShowDialog();
            }
        }

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
