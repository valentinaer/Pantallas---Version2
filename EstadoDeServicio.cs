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

            //int[] numerosdeTrackeo = { 123, 456, 789};

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
                OrdenDeServicio Os = new OrdenDeServicio();
                OrdenDeServicio orden = new OrdenDeServicio();
                MessageBox.Show(numeroTrack, "ingreso");
                orden = Os.BuscarNumeroTrack(int.Parse(numeroTrack));

                MessageBox.Show(orden.numeroTrackeo.ToString(), "Errores");

                lblCuitI.Text = orden.CUIT;
                lblUrgente.Text = orden.urgente;
                lblCotizacion.Text = orden.estado;
                if(orden.tipoDeEnvio == "NACIONAL"){
                    lblDestino.Text= orden.calleDestino + " " + orden.alturaDestino + ", " + orden.ciudadDestino + ", " +  orden.provinciaDestino + ", " +  orden.paisDestino;
                    lblOrigen.Text = orden.calleOrigen + " " + orden.alturaOrigen + ", " +  orden.ciudadOrigen + ", " +  orden.provinciaDestino + ", " +  orden.paisOrigen;
                }else
                {
                    //pais, ciudad
                    lblDestino.Text= orden.calleDestino + " " + orden.alturaDestino + ", " + orden.ciudadDestino + ", " +  orden.paisDestino;
                    lblOrigen.Text = orden.calleOrigen + " " + orden.alturaOrigen + ", " +  orden.ciudadOrigen + ", " +  orden.paisOrigen;
                }
               
                

                if(orden.estado != "")
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
