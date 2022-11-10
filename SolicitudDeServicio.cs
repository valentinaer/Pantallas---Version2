﻿using System;
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

        public void CargarPaisesComboBox()
        {
            cmbPaisI.Items.Clear();
            RegionesInternacionales r = new RegionesInternacionales();

            Paises = r.SoloPaises();

            foreach (string p in Paises)
            {
                cmbPaisI.Items.Add(p);

            }
            

        }

        List<string> Paises = new List<string>();
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

                //Carga de paises al combobox.//
                CargarPaisesComboBox();
               

            }


        }

        public void cotizar(string origen, string destino)
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


            decimal precio = calculatePrecio();


            // Seteamos el texto de la cotizacion
            lblCotizacion.Text = "$" + precio;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;
            lblUrgente.Text = chkUrgente.Checked ? "Si" : "No";
            lblCuitI.Text = "CUIT";

        }

        public string calculateRegion(string pais, string origenCiudad, string destinoCiudad, string origenProvincia, string destinoProvincia)
        {
            CiudadadesNacionales region = new CiudadadesNacionales();
            
            string origenRegion = region.BuscarRegion(origenCiudad).Region;
            string destinoRegion = region.BuscarRegion(destinoCiudad).Region;
            

            if (pais == "Nacional")
            {
                if (origenCiudad == destinoCiudad)
                {
                    return "Local";
                }
                if (origenProvincia == destinoProvincia)
                {
                    return "Interior";
                }
                if (origenRegion == destinoRegion)
                {
                    return "Regional";
                }
                return "Nacional";
            }
            else
            {
                RegionesInternacionales regionesInternacionales = new RegionesInternacionales();
                string origenRegionInternacional = regionesInternacionales.BuscarRegion(pais);
                return origenRegionInternacional;
            }
        }

        private decimal calculatePrecio()
        {
            string pais = cmbPaisI.Text == "" ? "Nacional" : cmbPaisI.Text;
            string Region = calculateRegion(pais, cmbCiudadOrigen.Text, cmbCiudadDestino.Text, cmbProvinciaOrigen.Text, cmbProvinciaDestino.Text);
            
            Tarifas tarifas = new Tarifas();
            decimal tarifa = Convert.ToDecimal(tarifas.BuscarTarifa(cmbRangoPeso.Text, Region));
            
            decimal Precio = tarifa;

            using var recargos = new StreamReader("Recargos.txt");
            var recargosLine = recargos.ReadLine();
            var recargosValues = recargosLine.Split('|');

            if (Region == "Paises Limitrofes" || Region == "America Latina" || Region == "America del Norte" || Region == "Europa" || Region == "Asia")
            {
                string RegionCABA = "C.A.B.A";
                decimal hastaBsAs = Convert.ToDecimal(tarifas.BuscarTarifa(cmbRangoPeso.Text, RegionCABA));
                // si es urgente sumamos 20% al precio
                decimal precioUrgente = 0;
                if (chkUrgente.Checked)
                {
                    precioUrgente = Precio * Convert.ToDecimal(recargosValues[0]);
                }

                // tope maximo de urgencia es 50, por eso si es mas alto sobre escribimos 50
                if (precioUrgente > (Precio * Convert.ToDecimal(recargosValues[0])))
                {
                    precioUrgente = Convert.ToDecimal(recargosValues[1]);
                }

                // retiro fijo es 30 y destino fijo 40
                Precio = Precio + precioUrgente + Convert.ToDecimal(recargosValues[2]) + Convert.ToDecimal(recargosValues[3]) + hastaBsAs;
            }

            return Precio * Convert.ToDecimal(cmbCantidadBultosN.Text);
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {

            //----------------- Logica Extra para Cotizar -----------------//            
            string origen = "";

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
                cotizar(origen, cmbCiudadesI.Text);
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
            else
            {
                //  destino = cmbPaisCiudadDestino.Text + " - " + cmbRegionI.Text;
            }

            string tipoEnvio = rboNacional.Checked ? "Nacional" : "Internacional";
            //string CUIT = Usuario.CUIT(usuario);
            //Id_Cotizacion,Aprobado,Estado,Id_Trackeo,CUIT,FechaSolicitud,Origen,Destino,Urgente,TipoDeEnvio,RangoPeso,CantidadBultos
            string nuevaFila = "N°Trackeo|Feha|CUIT Cliente|Tipo DE ENVIO NACIONAL O INTERNACIONAL|PAIS DE ORIGEN|PROVINCIA ORIGEN|CIUDAD ORIGEN|CALLE|ALTURA|PISO DEPTO|PAIS DE DESTINO|PROVINCIA/REGION|CIUDAD DESTINO|CALLE|ALTURA|PISO DEPTO|RANGO DE PESO|CANTIDAD DE BULTOS|URGENTE|ESTADO|FACTURADO";
            Utilidades.GrabarNuevaFila("./OrdenDeServicio.txt", nuevaFila);
        }
        private int Autonumerar()
        {
            Random r = new Random();
            return r.Next(0001, 9999);
        }
        List<CiudadadesNacionales> ciudadesAMostrar = new List<CiudadadesNacionales>();
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
            cmbCiudadOrigen.Items.Clear();
            string provincia = cmbProvinciaOrigen.Text;

            var CiudadesDeProvincia = new CiudadadesNacionales();
            ciudadesAMostrar = CiudadesDeProvincia.BuscarCiudades(provincia);
            foreach (var c in ciudadesAMostrar)
            {
                cmbCiudadOrigen.Items.Add(c.Ciudad);
            }
        }
        
        //Mostrar Provincia Destino
        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCiudadDestino.Items.Clear();
            string provincia = cmbProvinciaDestino.Text;

            var CiudadesDeProvincia = new CiudadadesNacionales();
            ciudadesAMostrar = CiudadesDeProvincia.BuscarCiudades(provincia);
            foreach(var c in ciudadesAMostrar)
            {
                cmbCiudadDestino.Items.Add(c.Ciudad);
            }
        }

        List<CiudadesInternacionales> ciudadesInternacionalesAMostrar = new List<CiudadesInternacionales>();
      
        //Mostrar Internacional Destino
        private void cmbPaisI_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbCiudadesI.Items.Clear();
            string pais = cmbPaisI.Text;

            var CiudadesDePaises = new CiudadesInternacionales();
            ciudadesInternacionalesAMostrar = CiudadesDePaises.BuscarCiudades(pais);

            foreach (var c in ciudadesInternacionalesAMostrar)
            {
                cmbCiudadesI.Items.Add(c.Ciudad);
            }
            
          

        }

        private void cmbCiudadesI_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SolicitudDeServicio_Load(object sender, EventArgs e)
        {

        }

        private void cmbSucursalOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
           grupoB_TP.Sucursales sucursales = new grupoB_TP.Sucursales();
           List<Sucursales> listS = sucursales.PedirLista();
           
           MessageBox.Show(listS.First());
            
            
        }

        private void cmbSucursalesDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
