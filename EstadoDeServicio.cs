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
    public partial class EstadoDeServicio : Form
    {
        public EstadoDeServicio()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            grpDatosEstadoDeServicio.Visible = true;

            int[] numerosdeTrackeo = { 123, 456, 789};

            string numeroTrack = txtTrackeo.Text;

            Console.WriteLine($"Código de trackeo: {numeroTrack}");
            mensaje += Validador.PedirVacio("El número de Tracking", numeroTrack);
            mensaje += Validador.PedirEntero("tracking", 0 ,9999, numeroTrack);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje, "Errores");
            }
            
            else
            {
                string estado = Utilidades.Buscar(0, 19, numeroTrack, "./OrdenDeServicio.txt");
                string cuit = Utilidades.Buscar(0, 2, numeroTrack, "./OrdenDeServicio.txt");
                string calleorigen = Utilidades.Buscar(0, 7, numeroTrack, "./OrdenDeServicio.txt");
                string alturaorigen = Utilidades.Buscar(0, 8, numeroTrack, "./OrdenDeServicio.txt");
                string calledestino = Utilidades.Buscar(0, 13, numeroTrack, "./OrdenDeServicio.txt");
                string alturadestino = Utilidades.Buscar(0, 14, numeroTrack, "./OrdenDeServicio.txt");
                string urgente = Utilidades.Buscar(0, 18, numeroTrack, "./OrdenDeServicio.txt");
                Console.WriteLine(estado);
                lblCuitI.Text = cuit;
                lblUrgente.Text = urgente;
                lblDestino.Text= calleorigen + " " + alturaorigen;
                lblOrigen.Text = calledestino + " " + alturadestino;
                lblCotizacion.Text = estado;

                if(estado != "")
                {
                    
                }
                else
                {
                    MessageBox.Show("No existe un servicio con el número de trackeo ingresado.", "Estado de servicio");
                }
                
            }  
        }

        private void EstadoDeServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
