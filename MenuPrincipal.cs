using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grupoB_TP
{
    public partial class MenuPrincipal : Form
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

        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
