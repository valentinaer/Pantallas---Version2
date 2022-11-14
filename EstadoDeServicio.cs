using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version_2___Pantallas;

namespace grupoB_TP
{
    public partial class EstadoDeServicio : Form
    {
        public EstadoDeServicio()
        {
            InitializeComponent();
        }
        private void EstadoDeServicio_Load(object sender, EventArgs e)
        {
            //Carga nuevamente para tener las ultimas ordenes de servicio sin cerrar el sistema
            ArchivoOrdenDeServicios.Grabar();
        }

        // Boton para buscar el estado de servicio
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string mensaje = "";
            grpDatosEstadoDeServicio.Visible = true;

            string numeroTrack = txtTrackeo.Text;

            Console.WriteLine($"Código de trackeo: {numeroTrack}");
            mensaje += Validador.PedirVacio("El número de tracking", numeroTrack);
            mensaje += Validador.PedirEntero("tracking", 0, 9999, numeroTrack);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje, "Errores");
            }

            else
            {
                OrdenDeServicio orden = new OrdenDeServicio();

                orden = ArchivoOrdenDeServicios.BuscarNumeroTrack(int.Parse(numeroTrack));

                if (orden == null)
                {
                    MessageBox.Show("El numero de trackeo no existe", "Errores");
                }
                else
                {
                    lblCuitI.Text = orden.Cuit;
                    lblUrgente.Text = orden.Urgente;
                    lblCotizacion.Text = orden.Estado;
                    if (orden.TipoDeEnvio == "NACIONAL")
                    {
                        lblDestino.Text = orden.CalleDestino + " " + orden.AlturaDestino +
                            ", " + orden.CiudadDestino + ", " + orden.ProvinciaDestino + ", "
                            + orden.PaisDestino;

                        lblOrigen.Text = orden.CalleOrigen + " " + orden.AlturaOrigen + ", "
                            + orden.CiudadOrigen + ", " + orden.ProvinciaDestino + ", " +
                            orden.PaisOrigen;
                    }
                    else
                    {
                        lblDestino.Text = orden.CalleDestino + " " + orden.AlturaDestino + ", " + orden.CiudadDestino + ", " + orden.PaisDestino;
                        lblOrigen.Text = orden.CalleOrigen + " " + orden.AlturaOrigen + ", " + orden.CiudadOrigen + ", " + orden.PaisOrigen;
                    }

                }
            }
        }

        private void EstadoDeServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
