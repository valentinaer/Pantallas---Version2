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
using Version_2___Pantallas;

namespace grupoB_TP
{
    public partial class SolicitudDeServicio : Form
    {
        public SolicitudDeServicio()
        {
            InitializeComponent();
        }

        public void mostrarOcultar(object sender, EventArgs e)
        {
            // Si radio button Nacional esta checkeda, mostrar el grupo Nacional
            if (rboNacional.Checked)
            {
                grpNacional.Visible = true;
                grpInternacional.Visible = false;
            }
            // Si radio button Internacional esta checkeda, mostrar el grupo Internacional
            else if (rboInternacional.Checked)
            {
                grpInternacional.Visible = true;
                grpNacional.Visible = false;
            }
        }


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
                price = calculatePrecioNacional();
            }
            else
            {
                price = calculatePrecioInternacional();
            }

            // Seteamos el texto de la cotizacion
            lblCotizacion.Text = "$" + price;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;
            lblUrgente.Text = urgente;
            lblCuitI.Text = "30-" + Validador.DNI + "-9";

            // Id_Cotizacion,NumeroTrackeo,CUIT,FechaSolicitud,Origen,Destino,Urgente,Nacional,RangoPeso,CantidadBultos,Id_Factura,Id_Direccion,Precio
            // save the data in the file Cotizacion.txt
            //search last id and add 1 in cotizacion.txt
            /* int idCotizacion = 0;
            string[] linesCotizacion = System.IO.File.ReadAllLines(@"./Cotizacion.txt");
            foreach (string lineCotizacion in linesCotizacion)
            {
                string[] words = lineCotizacion.Split(',');
                idCotizacion = Convert.ToInt32(words[0]);
            }

            string[] fields = new string[] { Convert.ToString(idCotizacion), "1", "30-" + Validador.DNI + "-9", DateTime.Now.ToString(), origen, destino, urgente, rboNacional.Checked.ToString(), cmbRangoPeso.Text, cmbCantidadBultosN.Text, "1", "1", lblCotizacion.Text };
            string line = string.Join(",", fields);
            File.AppendAllText("./Cotizacion.txt", line + Environment.NewLine);

            //Id_Cotizacion,CUIT,Fecha,Pagado
            string[] fieldsFactura = new string[] { Convert.ToString(idCotizacion) , "30-" + Validador.DNI + "-9", DateTime.Now.ToString(), "false" };
            string lineFactura = string.Join(",", fieldsFactura);
            File.AppendAllText("./Factura.txt", lineFactura + Environment.NewLine);
 */
        }

        static List<RegionesInternacionales> RegionesInternacionales = new List<RegionesInternacionales>();

        
        private double calculatePrecioInternacional(){

            string region = Utilidades.Buscar(0,1,cmbPaisI.Text, "./RegionesInternacionales.txt");

            double precio = 0;

            // -------------- Sobres Hasta 500g -----------------//
            if (cmbCantidadBultosN.SelectedIndex == 0)
            {
                // ----------------- Limitrofes -----------------//
                if (region == "Limitrofes")
                {
                    precio = 180;
                }

                // ----------------- America Latina -----------------//
                else if (region == "America Latina")
                {
                    precio = 190;
                }
                // ----------------- America del Norte -----------------//
                else if (region == "America del Norte")
                {
                    precio = 200;
                }
                
                // ----------------- Europa -----------------//
                else if (region == "Europa")
                {
                    precio = 210;
                }

                // ----------------- Asia -----------------//
                else if (region == "Asia")
                {
                    precio = 220;
                }
                
                else
                {
                    precio = 0;
                    MessageBox.Show("Contactar a la gerencia de la gerencia de Productos y Marketing");
                }
            }

            // ----------------- Bultos hasta 10Kg -----------------//
            else if (cmbCantidadBultosN.SelectedIndex == 1)
            {
                // ----------------- Limitrofes -----------------//
                if (region == "Limitrofes")
                {
                    precio = 230;
                }

                // ----------------- America Latina -----------------//
                else if (region == "America Latina")
                {
                    precio = 240;
                }
                // ----------------- America del Norte -----------------//
                else if (region == "America del Norte")
                {
                    precio = 250;
                }
                
                // ----------------- Europa -----------------//
                else if (region == "Europa")
                {
                    precio = 260;
                }

                // ----------------- Asia -----------------//
                else if (region == "Asia")
                {
                    precio = 270;
                }
                
                else
                {
                    precio = 0;
                    MessageBox.Show("Contactar a la gerencia de la gerencia de Productos y Marketing");
                }
            }

            // ------------- Bultos hasta 20Kg --------//
            else if (cmbCantidadBultosN.SelectedIndex == 2)
            {
                // ----------------- Limitrofes -----------------//
                if (region == "Limitrofes")
                {
                    precio = 280;
                }

                // ----------------- America Latina -----------------//
                else if (region == "America Latina")
                {
                    precio = 290;
                }
                // ----------------- America del Norte -----------------//
                else if (region == "America del Norte")
                {
                    precio = 300;
                }
                
                // ----------------- Europa -----------------//
                else if (region == "Europa")
                {
                    precio = 310;
                }

                // ----------------- Asia -----------------//
                else if (region == "Asia")
                {
                    precio = 320;
                }
                
                else
                {
                    precio = 0;
                    MessageBox.Show("Contactar a la gerencia de la gerencia de Productos y Marketing");
                }
            }

            // ------------- Bultos hasta 30Kg --------//
            else if (cmbCantidadBultosN.SelectedIndex == 3)
            {
                // ----------------- Limitrofes -----------------//
                if (region == "Limitrofes")
                {
                    precio = 330;
                }

                // ----------------- America Latina -----------------//
                else if (region == "America Latina")
                {
                    precio = 340;
                }
                // ----------------- America del Norte -----------------//
                else if (region == "America del Norte")
                {
                    precio = 350;
                }
                
                // ----------------- Europa -----------------//
                else if (region == "Europa")
                {
                    precio = 360;
                }

                // ----------------- Asia -----------------//
                else if (region == "Asia")
                {
                    precio = 370;
                }
                
                else
                {
                    precio = 0;
                    MessageBox.Show("Contactar a la gerencia de la gerencia de Productos y Marketing");
                }
            }

            return precio;
        }

        private double calculatePrecioNacional()
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
           
         private void btnCotizar_Click(object sender, EventArgs e)
        {

            //----------------- Logica Extra para Cotizar -----------------//            
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

            //----------------- Validaciones -----------------//


            // Validar que sea Nacional o Internacional
            if (!rboInternacional.Checked && !rboNacional.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de envio", "Errores");
                return;
            }

            // Condiciones generales para todos los envios
            if (cmbRangoPeso.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rango de peso", "Errores");
                return;
            }
            if (cmbCantidadBultosN.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la cantidad de Bultos", "Errores");
                return;
            }

            //valida que se haya seleccionado un tipo de envio con los radio buttons Sucursal y Domicilio
            if (!rboRecibeSucursal.Checked && !rboRetiroDomicilio.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de recepcion", "Errores");
                return;
            }

            // Condiciones para el Origen
            // Si es RETIRO a domicilio
            if (rboRetiroDomicilio.Checked && !rboRecibeSucursal.Checked)
            {
                // Validacion de Provincia en el Origen
                string mensaje = "";
                if (cmbProvinciaOrigen.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una provincia de ORIGEN" + "\n";
                }
                if (cmbCiudadOrigen.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una Ciudad de ORIGEN" + "\n";
                }
                if (string.IsNullOrEmpty(txtDirrecionOrigen.Text))
                {
                    mensaje += "El domicilio de Retiro a Domicilio" + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaOrigen.Text))
                {
                    mensaje += "La altura de Retiro" + "\n";
                }
                else
                {
                    mensaje += Validador.PedirEntero("Altura de Retiro", 0, 99999, txtAlturaOrigen.Text);
                }

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, "Errores");
                    return;
                }
            }

            // Si es sucursal
            if (rboRecibeSucursal.Checked && !rboRetiroDomicilio.Checked)
            {
                if (cmbSucursalOrigen.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una Sucursal de ORIGEN", "Errores");
                    return;
                }
            }

            // Validaciones para Envios Nacionales
            if (rboNacional.Checked && !rboInternacional.Checked)
            {

                if (!rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    MessageBox.Show("Debe seleccionar el tipo de entrega", "Errores");
                    return;
                }

                // Condiciones para el Origen de Retirmo a Domicilio
                if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    //Checkear que se haya seleccionado una Provincia de origen
                    if (cmbProvinciaDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una provincia de DESTINO", "Errores");
                        return;
                    }
                    //Checkear que se haya seleccionado una Ciudad de origen
                    else if (cmbCiudadDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una ciudad de DESTINO", "Errores");
                        return;
                    }

                    string mensaje = "";
                    if (string.IsNullOrEmpty(txtDirrecionNacional.Text))
                    {
                        mensaje += "El domicilio de Entrega a Domicilio" + "\n";
                    }
                    if (string.IsNullOrEmpty(txtAlturaNacional.Text))
                    {
                        mensaje += "La altura de Entrega" + "\n";
                    }
                    else
                    {
                        mensaje += Validador.PedirEntero("Altura de Entrega", 0, 99999, txtAlturaNacional.Text);
                    }

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje, "Errores");
                        return;
                    }
                }

                // Condiciones para el Destino, si es envio a sucursal 
                if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
                {
                    //Checkear que se haya seleccionado una sucursal de destino
                    if (cmbSucursalesDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una sucursal de destino", "Errores");
                        return;
                    }
                }

                string destino = "";

                // Mostrar informacion de cotizacion de Destino
                if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
                {
                    destino = cmbSucursalesDestino.Text;
                }
                else if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    destino = cmbCiudadDestino.Text + " - " + cmbProvinciaDestino.Text;
                }

                cotizar(origen, destino);
            }


            // Validaciones para Envios Internacionales
            if (rboInternacional.Checked && !rboNacional.Checked)
            {
                

                if (cmbPaisI.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una País y Ciudad de DESTINO", "Errores");
                    return;
                }

                string mensaje = "";
                if (string.IsNullOrEmpty(txtDireccionI.Text))
                {
                    mensaje += "El domicilio de Entrega a Domicilio Internacional" + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaI.Text))
                {
                    mensaje += "La altura de Entrega Internacional" + "\n";
                }
                else
                {
                    mensaje += Validador.PedirEntero("Altura de Entrega Internacional ", 0, 99999, txtAlturaI.Text);
                }

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, "Errores");
                    return;
                }
                cotizar(origen, txtCiudadI.Text);
            }
        }

            //Boton CONFIRMACION
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var usuario = new Usuario();
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
              //  destino = cmbPaisCiudadDestino.Text + " - " + cmbRegionI.Text;
            }

            string tipoEnvio = rboNacional.Checked ? "Nacional" : "Internacional";
            //string CUIT = Usuario.CUIT(usuario);
            //Id_Cotizacion,Aprobado,Estado,Id_Trackeo,CUIT,FechaSolicitud,Origen,Destino,Urgente,TipoDeEnvio,RangoPeso,CantidadBultos
            /* string[] fields = new string[] { tracking.ToString(), "true", "Recibida", tracking.ToString(), "CUIT", DateTime.Now.ToString(), origen, destino, chkUrgente.Checked.ToString(), tipoEnvio, cmbRangoPeso.Text, cmbCantidadBultosN.Text };
            string line = string.Join(",", fields);
            File.AppendAllText("./OrdenDeServicio.txt", line + Environment.NewLine);
 */ 
            string nuevaFila = "N°Trackeo|Feha|CUIT Cliente|Tipo DE ENVIO NACIONAL O INTERNACIONAL|PAIS DE ORIGEN|PROVINCIA ORIGEN|CIUDAD ORIGEN|CALLE|ALTURA|PISO DEPTO|PAIS DE DESTINO|PROVINCIA/REGION|CIUDAD DESTINO|CALLE|ALTURA|PISO DEPTO|RANGO DE PESO|CANTIDAD DE BULTOS|URGENTE|ESTADO|FACTURADO";
            Utilidades.GrabarNuevaFila("./OrdenDeServicio.txt", nuevaFila);
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
            string provincia = cmbProvinciaDestino.Text;

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
            /*
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
            */
        }
    }
}
