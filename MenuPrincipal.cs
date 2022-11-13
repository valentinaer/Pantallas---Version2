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
        public MenuPrincipal()
        {
            InitializeComponent();
        }
        public void btnContinuar_Click(object sender, EventArgs e)
        {

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
                new EstadoDeCuenta().ShowDialog();
            }
        }
        private void MenuPrincipal_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            //ArchivoOrdenDeServicios.Grabar();
            Application.Exit();
            /*if (MessageBox.Show("quiere cerrar el formulario?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                e.Cancel = true;
                
            }
            */
        }
    }
}
