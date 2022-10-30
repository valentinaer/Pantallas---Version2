using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grupoB_TP
{
    public partial class SolicitudDeServicio : Form
    {
        public SolicitudDeServicio()
        {
            InitializeComponent();
        }

        // function with all the attributes from the form solicitudDeServicio: rango de peso, cantidad de bultos, urgente, nacional /
        public void cotizar(string origen, string destino   )
        {
            // -------------- Escondemos elementos -----------------//

            btnCotizar.Visible = false;
            grpCotizacion.Visible = true;
            lblMenuPrincipal.Visible = true;
            grpCaracteristicaServicio.Visible = false;
            grpTipoEnvio.Visible = false;
            grpTipoRecepcion.Visible = false;
            grpNacional.Visible = false;
            grpInternacional.Visible = false;
            grpCotizacion.Visible = true;

            // -------------- Centramos el elemento de cotizacion -----------------//
            //centra el elemento de cotizacion hoirzontalmente y verticalmente
            grpCotizacion.Location = new Point(
                this.ClientSize.Width / 2 - grpCotizacion.Size.Width / 2,
                this.ClientSize.Height / 2 - grpCotizacion.Size.Height / 2);

            // centra el titulo horizontalmente
            lblMenuPrincipal.Location = new Point(
                this.ClientSize.Width / 2 - lblMenuPrincipal.Size.Width / 2,
                lblMenuPrincipal.Location.Y);

            // centra el boton cotizar horizontalmente
            btnCotizar.Location = new Point(
                this.ClientSize.Width / 2 - btnCotizar.Size.Width / 2,
                btnCotizar.Location.Y);


            // Si el checkbox de urgente esta marcado seteamos la variable a Urgente para utilizar como texto 
            string urgente = "";
            if (chkUrgente.Checked)
            {
                urgente = "Urgente";
            }
            else
            {
                urgente = "No Urgente";
            }

            // Calculamos el precio y multiplicamos por 4 para obtener el precio final de envio internacional
            double price = 0;
            if (rboNacional.Checked)
            {
                price = calculatePrecio();
            }
            else
            {
                price = calculatePrecio() * 4;
            }

            // Seteamos el texto de la cotizacion
            lblCotizacion.Text = "$" + price;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;
            lblUrgente.Text = urgente;
            lblCuitI.Text = "30-" + Usuario.DNI + "-9";

            // Id_Cotizacion,NumeroTrackeo,CUIT,FechaSolicitud,Origen,Destino,Urgente,Nacional,RangoPeso,CantidadBultos,Id_Factura,Id_Direccion,Precio
            // save the data in the file Cotizacion.txt
            //search last id and add 1 in cotizacion.txt
            int idCotizacion = 0;
            string[] linesCotizacion = System.IO.File.ReadAllLines(@"Cotizacion.txt");
            foreach (string lineCotizacion in linesCotizacion)
            {
                string[] words = lineCotizacion.Split(',');
                idCotizacion = Convert.ToInt32(words[0]);
            }

            string[] fields = new string[] { Convert.ToString(idCotizacion), "1", "30-" + Usuario.DNI + "-9", DateTime.Now.ToString(), origen, destino, urgente, rboNacional.Checked.ToString(), cmbRangoPeso.Text, cmbCantidadBultosN.Text, "1", "1", lblCotizacion.Text };
            string line = string.Join(",", fields);
            File.AppendAllText("Cotizacion.txt", line + Environment.NewLine);

            //Id_Cotizacion,CUIT,Fecha,Pagado
            string[] fieldsFactura = new string[] { Convert.ToString(idCotizacion) , "30-" + Usuario.DNI + "-9", DateTime.Now.ToString(), "false" };
            string lineFactura = string.Join(",", fieldsFactura);
            File.AppendAllText("Factura.txt", lineFactura + Environment.NewLine);

        }
        private double calculatePrecio()
        {
            double precio = 0;
            double precioUrgente = 0;
            double precioFinal = 0;

            // -------------- Sobres Hasta 500g -----------------//
            if (cmbCantidadBultosN.SelectedIndex == 0)
            {

                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 20;
                }

                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 60;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 100;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 140;
                }
            }

            // ----------------- Segun la cantidad de bultos -----------------//
            else if (cmbCantidadBultosN.SelectedIndex == 1)
            {
                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 30;
                }
                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 70;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 110;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 150;
                }
            }

            // ------------- Bultos hasta 20Kg --------//
            else if (cmbCantidadBultosN.SelectedIndex == 2)
            {
                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 40;
                }
                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 80;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 120;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 160;
                }
            }

            // ------------- Bultos hasta 30Kg --------//
            else if (cmbCantidadBultosN.SelectedIndex == 3)
            {
                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 50;
                }
                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 90;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 130;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 170;
                }
            }

            // si es urgente sumamos 20% al precio
            if (chkUrgente.Checked)
            {
                precioUrgente = precio * 0.2;
            }

            // tope maximo de urgencia es 50, por eso si es mas alto sobre escribimos 50
            if (precioUrgente > 50)
            {
                precioUrgente = 50;
            }

            // retiro fijo es 30 y destino fijo 40
            precioFinal = precio + precioUrgente + 30 + 40;

            return precioFinal;
        }
        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbRangoPeso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void txtOrigen_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblMenuPrincipal_Click(object sender, EventArgs e)
        {

        }
        private void rboRecibeSucursal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpCotizacion_Enter(object sender, EventArgs e)
        {

        }
        private void SolicitudDeServicioNacional_Load(object sender, EventArgs e)
        {

        }
        //Boton CONFIRMACION
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int tracking = Autonumerar();
            MessageBox.Show($"La solicitud de servicio se registro de forma exitosa." +
                $" {"\n"} Su numero de trackeo es: {tracking}");


            // destino si es nacional
            string destino = "";
            string origen = "";

            // if sucursal show in a string the sucursal selected from dropdown, if envio a domicilio show in a string the provincia and ciudad selected from dropdown
            if (rboRecibeSucursal.Checked && !rboRetiroDomicilio.Checked)
            {
                origen = cmbSucursalOrigen.Text;
            }
            
            if (rboRetiroDomicilio.Checked && !rboRecibeSucursal.Checked)
            {
                origen = cmbProvinciaOrigen.Text + " - " + cmbCiudadOrigen.Text;
            }
                                
            
            if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
            {
                destino = cmbSucursalesDestino.Text;
            }
            else if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
            {
                destino = cmbCiudadDestino.Text + " - " + cmbProvinciaDestino.Text;
            }
            else {
                destino = cmbPaisCiudadDestino.Text + " - " + cmbRegionI.Text;
            }

            string tipoEnvio = rboNacional.Checked ? "Nacional" : "Internacional";
            string CUIT = "30-" + Usuario.DNI + "-9";
            //Id_Cotizacion,Aprobado,Estado,Id_Trackeo,CUIT,FechaSolicitud,Origen,Destino,Urgente,TipoDeEnvio,RangoPeso,CantidadBultos
            string[] fields = new string[] { tracking.ToString(), "true", "Recibida", tracking.ToString(), CUIT, DateTime.Now.ToString(), origen, destino, chkUrgente.Checked.ToString(), tipoEnvio, cmbRangoPeso.Text, cmbCantidadBultosN.Text };
            string line = string.Join(",", fields);
            File.AppendAllText("OrdenDeServicio.txt", line + Environment.NewLine);


        }
        private int Autonumerar()
        {
            Random r = new Random();
            return r.Next(0001, 9999);
        }



        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // -------------- Escondemos elementos -----------------//
            grpCotizacion.Visible = false;
            
            lblMenuPrincipal.Visible = false;
            grpCaracteristicaServicio.Visible = true;
            grpTipoEnvio.Visible = true;
            grpTipoRecepcion.Visible = true;
            grpNacional.Visible = true;
            grpInternacional.Visible = false;
            btnCotizar.Visible = true;
        }

        //Mostrar Provincia Origen
        private void cmbProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvinciaOrigen.Text == "BUENOS AIRES")
            {
                cmbCiudadOrigen.Items.Clear();
                cmbCiudadOrigen.Items.Add("Mar del Plata");
                cmbCiudadOrigen.Items.Add("Quilmes");
                cmbCiudadOrigen.Items.Add("Bahia Blanca");
                cmbCiudadOrigen.Items.Add("Salto");
            }
            else if (cmbProvinciaOrigen.Text != "BUENOS AIRES")
            {
                cmbCiudadOrigen.Items.Clear();
                cmbCiudadOrigen.Items.Add("NO IMPLEMENTADO");
            }
        }
        //Mostrar Provincia Destino
        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvinciaDestino.Text == "BUENOS AIRES")
            {
                cmbCiudadDestino.Items.Clear();
                cmbCiudadDestino.Items.Add("Mar del Plata");
                cmbCiudadDestino.Items.Add("Quilmes");
                cmbCiudadDestino.Items.Add("Bahia Blanca");
                cmbCiudadDestino.Items.Add("Salto");
            }
            else if (cmbProvinciaDestino.Text != "BUENOS AIRES")
            {
                cmbCiudadDestino.Items.Clear();
                cmbCiudadDestino.Items.Add("NO IMPLEMENTADO");
            }
        }
        //Mostrar Internacional Destino
        private void cmbRegionI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegionI.Text == "Europa")
            {
                cmbPaisCiudadDestino.Items.Clear();
                cmbPaisCiudadDestino.Items.Add("Madrid España");
                cmbPaisCiudadDestino.Items.Add("Paris, Francia");
                cmbPaisCiudadDestino.Items.Add("Roma, Italia");
                cmbPaisCiudadDestino.Items.Add("Berlin, Alemania");
            }
            else if (cmbProvinciaDestino.Text != "Europa")
            {
                cmbPaisCiudadDestino.Items.Clear();
                cmbPaisCiudadDestino.Items.Add("NO IMPLEMENTADO");
            }
        }

        private void rboOrigenSucursal_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
