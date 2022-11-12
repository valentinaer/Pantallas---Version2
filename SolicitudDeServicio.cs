﻿using Clases_TP4;
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
        string CUIT = "";
        // Se Buscan los datos del cliente y se cargan los valores dynamicos de los labels
        public void SolicitudDeServicio_Load(object sender, EventArgs e)
        {
            CargarPaisesComboBox();
            CargarSucursales();
            CUIT = Cliente.CuitUsuarioActual!;
        }
        public SolicitudDeServicio()
        {
            InitializeComponent();
        }
        
        // Se cargan las sucursales en el comboBox sucursal Origen y Destino 
        private void CargarSucursales()
        {
            List<Sucursales> listaSucursales = ArchivoSucursales.PedirLista();

            foreach (Sucursales s in listaSucursales)
            {
                string texto = s.NroSucursal.ToString() + " - " + s.Ciudad +
                    ", " + s.Provincia + ", " + s.Direccion;
                cmbSucursalOrigen.Items.Add(texto);
                cmbSucursalDestino.Items.Add(texto);
            }
        }

        // Se cargan los paises en el comboBox Pais
        private void CargarPaisesComboBox()
        {
            List<string> PaisesInternacionales = new List<string>();
            cmbPaisI.Items.Clear();
            PaisesInternacionales.Clear();
            PaisesInternacionales = ArchivoPaisesInternacionales.SoloPaises();

            foreach (string pais in PaisesInternacionales)
            {
                cmbPaisI.Items.Add(pais);
            }
        }


        // En la pantalla de confirmacion se puede retroceder para cambiar los datos de la cotizacion
        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostramosElementos();
        }

        // Button para confirmar la cotizacion actual del servicio
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int tracking = ArchivoOrdenDeServicios.BuscarUltimoNumeroTrackeo() + 1;

            MessageBox.Show($"La solicitud de servicio se registro de forma exitosa." +
                $" {"\n"} Su numero de trackeo es: {tracking}");

            // destino si es nacional
            string destino = "";
            string origen = "";

            // Se obtiene el texto de la sucursal de origen en caso de marcar el Radion Button Sucursal Origen
            if (rboSucursalOrigen.Checked && !rboRetiroDomicilio.Checked)
            {
                origen = cmbSucursalOrigen.Text;
            }

            // Se obtiene el texto de la Provincia y Ciudad en caso de que el Radio Button Retiro Domicilio este marcado
            if (rboRetiroDomicilio.Checked && !rboSucursalOrigen.Checked)
            {
                origen = cmbProvinciaOrigen.Text + " - " + cmbCiudadOrigen.Text;
            }

            // Se obtiene el texto de la sucursal de destino en caso de marcar el Radion Button Sucursal Destino
            if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
            {
                destino = cmbSucursalDestino.Text;
            }

            // Se obtiene el texto de la Provincia y Ciudad en caso de que el Radio Button Entrega Domicilio este marcado
            else if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
            {
                destino = cmbCiudadDestino.Text + " - " + cmbProvinciaDestino.Text;
            }

            OrdenDeServicio solicitud = new OrdenDeServicio();
            solicitud.numeroTrackeo = tracking;
            solicitud.fecha = DateTime.Now;
            if (CUIT != null)
            {
                solicitud.Cuit = CUIT;
            }
            else
            {
                solicitud.Cuit = "";
            }

            
            solicitud.tipoDeEnvio = rboNacional.Text = true ? "NACIONAL" : "INTERNACIONAL"; // Si el radio button Nacional esta marcado se carga el valor de NACIONAL en el atributo tipo de envio Sino INTERNACIONAL
            solicitud.paisOrigen = "ARGENTINA"; // Solo los envios salen de Argentina
            solicitud.provinciaOrigen = cmbProvinciaOrigen.Text;
            solicitud.ciudadOrigen = cmbCiudadOrigen.Text;
            solicitud.calleOrigen = txtDirrecionOrigen.Text;

            if (!string.IsNullOrWhiteSpace(txtAlturaOrigen.Text))
            {
                solicitud.alturaOrigen = Convert.ToInt32(txtAlturaOrigen.Text);
            }

            solicitud.pisodeptoOrigen = txtPisoDeptoOrigen.Text;
            if (rboNacional.Checked)
            {
                solicitud.paisDestino = "ARGENTINA";
            }
            if (rboInternacional.Checked && cmbPaisI.Text != null)
            {
                solicitud.paisDestino = cmbPaisI.Text;
            }
            else
            {
                solicitud.paisDestino = "";
            }

            solicitud.provinciaDestino = rboNacional.Text = true ? cmbProvinciaDestino.Text : ""; // Si el radio button Nacional esta marcado se carga el valor de la provincia en el atributo provincia destino Sino vacio
            solicitud.ciudadDestino = rboNacional.Text = true ? cmbCiudadDestino.Text : cmbCiudadesI.Text; // Si el radio button Nacional esta marcado se carga el valor de la ciudad en el atributo ciudad destino Sino el valor de la ciudad internacional
            solicitud.calleDestino = rboNacional.Text = true ? txtDirecionNacional.Text : txtDireccionI.Text; // Si el radio button Nacional esta marcado se carga el valor de la direccion nacional en el atributo calle destino Sino el valor de la direccion internacional

            if (rboNacional.Checked && !string.IsNullOrWhiteSpace(txtAlturaNacional.Text))
            {
                solicitud.alturaDestino = Convert.ToInt32(txtAlturaNacional.Text);
            }
            if (rboInternacional.Checked && txtAlturaI.Text != null)
            {
                solicitud.alturaDestino = Convert.ToInt32(txtAlturaI.Text);
            }
            else
            {
                solicitud.alturaDestino = 0;
            }
            solicitud.pisodeptoDestino = rboNacional.Text = true ? txtPisoDeptoNacional.Text : txtPisoDeptoI.Text; // Si el radio button Nacional esta marcado se carga el valor Nacional sino Internacional
            solicitud.rangoDePeso = cmbRangoPeso.Text;
            solicitud.cantidadDeBultos = Convert.ToInt32(cmbCantidadBultosN.Text);
            solicitud.urgente = chkUrgente.Text = true ? "SI" : "NO"; // Si el check box Urgente esta marcado se carga el valor SI sino NO
            solicitud.estado = "INICIADO"; // Comienza el tramite con el estado INICIADO
            solicitud.facturado = "NO"; // No se factura previo a la solicitud

            guardarOrdenDeServicio(solicitud);
        }

        // Metodo para Formatear la informacion que luego se va a guardar en el archivo de texto
        private void guardarOrdenDeServicio(OrdenDeServicio solicitud)
        {
            string datos = $"{solicitud.numeroTrackeo}|{solicitud.fecha}|{solicitud.Cuit}|{solicitud.tipoDeEnvio}|{solicitud.paisOrigen}|{solicitud.provinciaOrigen}|{solicitud.ciudadOrigen}|{solicitud.calleOrigen}|{solicitud.alturaOrigen}|{solicitud.pisodeptoOrigen}|{solicitud.paisDestino}|{solicitud.provinciaDestino}|{solicitud.ciudadDestino}|{solicitud.calleDestino}|{solicitud.alturaDestino}|{solicitud.pisodeptoDestino}|{solicitud.rangoDePeso}|{solicitud.cantidadDeBultos}|{solicitud.urgente}|{solicitud.estado}|{solicitud.facturado}";
            ArchivoOrdenDeServicios.GuardarAlFinal(datos);
            Application.Exit();

        }
        
        // Boton en la pantalla del formulario para cotizar el envio
        private void btnCotizar_Click(object sender, EventArgs e)
        {

            //----------------- Logica Extra para Cotizar -----------------//            
            string origen = "";

            if (rboSucursalOrigen.Checked && !rboRetiroDomicilio.Checked)
            {
                origen = cmbSucursalOrigen.Text;
            }

            if (rboRetiroDomicilio.Checked && !rboSucursalOrigen.Checked)
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

            if (!string.IsNullOrWhiteSpace(cmbSucursalOrigen.Text) && !string.IsNullOrWhiteSpace(cmbSucursalDestino.Text) && cmbSucursalDestino.Text == cmbSucursalOrigen.Text)
            {
                MessageBox.Show("La sucursal de destino no puede ser la misma que la de origen", "Errores");
                return;
            }

            if (rboNacional.Checked && !rboSucursalOrigen.Checked && !rboSucursalDestino.Checked && cmbProvinciaOrigen.Text == cmbProvinciaDestino.Text && cmbCiudadOrigen.Text == cmbCiudadDestino.Text && txtDirecionNacional.Text == txtDirrecionOrigen.Text && txtAlturaNacional.Text == txtAlturaOrigen.Text)
            {
                MessageBox.Show("El destino de origen no puede ser el mismo que el de origen", "Errores");
                return;
            }

            //valida que se haya seleccionado un tipo de envio con los radio buttons Sucursal y Domicilio
            if (!rboSucursalOrigen.Checked && !rboRetiroDomicilio.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de recepcion", "Errores");
                return;
            }

            // Condiciones para el Origen
            // Si es RETIRO a domicilio
            if (rboRetiroDomicilio.Checked && !rboSucursalOrigen.Checked)
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
            if (rboSucursalOrigen.Checked && !rboRetiroDomicilio.Checked)
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
                    if (string.IsNullOrEmpty(txtDirecionNacional.Text))
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
                    if (cmbSucursalDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una sucursal de destino", "Errores");
                        return;
                    }
                }

                string destino = "";

                // Mostrar informacion de cotizacion de Destino
                if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
                {
                    destino = cmbSucursalDestino.Text;
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
        
        // Calcular el costo del envio apartir de los datos actuales ingresados
        public void cotizar(string origen, string destino)
        {
            EscondemosElementos();
            CentrarElementosCotizacion();

            decimal precio = CalcularPrecio();

            // Remplazamos con el texto actual de la cotizacion
            lblCotizacion.Text = "$" + precio;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;
            lblUrgente.Text = chkUrgente.Checked ? "Si" : "No"; // Si esta chequeado, es urgente (SI)
            lblPeso.Text = cmbRangoPeso.Text;
            lblCantidadDeBultos.Text = cmbCantidadBultosN.Text;
            lblCuit.Text = CUIT;
        }

        // Obtiene las Regiones apartir de la comparacion entre ciudades y provincias
        public string ObtenerRegionNacional(string origenCiudad, string destinoCiudad, string origenProvincia, string destinoProvincia)
        {
            string origenRegion = ArchivoCiudadesNacionales.BuscarRegionNacional(origenCiudad);
            string destinoRegion = ArchivoCiudadesNacionales.BuscarRegionNacional(destinoCiudad);

            // Misma ciudad indica Local
            if (origenCiudad == destinoCiudad)
            {
                return "Local";
            }

            // Misma provincia indica Provincial
            if (origenProvincia == destinoProvincia)
            {
                return "Provincial";
            }

            // Misma Region, indica Regional
            if (origenRegion == destinoRegion)
            {
                return "Regional";
            }

            // Sino sera Nacional, ya que detectamos si es Internacional previamente
            else
            {
                return "Nacional";
            }
        }

        // Calcula el precio buscando en el archivo de tarifas y agregando los recargos
        private decimal CalcularPrecio()
        {
            int CantBultos = int.Parse(cmbCantidadBultosN.Text);
            string regionParaCotizar = null;
            string DescRangoDePeso = cmbRangoPeso.Text;

            string ciudadOrigen = "";
            string provinciaOrigen = "";
            string ciudadDestino = "";
            string provinciaDestino = "";

            //LOGICA ORIGEN SUCURSAL O RETIRO A DOMICILIO
            if (rboSucursalOrigen.Checked)
            {
                int idSucursalOrigen = (cmbSucursalOrigen.SelectedIndex) + 1;
                var sucursalSeleccionada = ArchivoSucursales.BuscarSucursales(idSucursalOrigen);
                ciudadOrigen = sucursalSeleccionada.Ciudad;
                provinciaOrigen = sucursalSeleccionada.Provincia;
            }
            if (rboRetiroDomicilio.Checked)
            {
                ciudadOrigen = cmbCiudadOrigen.Text;
                provinciaOrigen = cmbProvinciaOrigen.Text;
            }

            //LOGICA DESTINO NACIONAL O INTERNACIONAL

            if (rboNacional.Checked)
            {
                //LOGICA NACIONAL SUCURSAL o ENTREGA A DOMICILIO
                if (rboSucursalDestino.Checked)
                {
                    int idSucursalDestino = (cmbSucursalDestino.SelectedIndex) + 1;
                    var sucursalSeleccionada = ArchivoSucursales.BuscarSucursales(idSucursalDestino);
                    ciudadDestino = sucursalSeleccionada.Ciudad;
                    provinciaDestino = sucursalSeleccionada.Provincia;
                }
                if (rboEntregaDomicilio.Checked)
                {
                    ciudadDestino = cmbCiudadDestino.Text;
                    provinciaDestino = cmbProvinciaDestino.Text;
                }
                MessageBox.Show(ciudadDestino + " - " + provinciaDestino);
                regionParaCotizar = ObtenerRegionNacional(ciudadOrigen, ciudadDestino, provinciaOrigen, provinciaDestino);
            }

            //DESTINO INTERNACIONAL
            if (rboInternacional.Checked)
            {
                string ciudadInternacional = cmbCiudadesI.Text;
                regionParaCotizar = ArchivoCiudadesInternacionales.BuscarRegionInternacional(ciudadInternacional);
            }


            decimal tarifaTabla = Convert.ToDecimal(ArchivoTarifas.BuscarTarifa(DescRangoDePeso, regionParaCotizar));

            decimal tarifaAdicionalHastaCABA = 0M;

            if (rboInternacional.Checked)
            {
                string ciudadDestinoFijada = "Belgrano";
                string provinciaDestinoFijada = "C.A.B.A";

                string regionHastaCABA = ObtenerRegionNacional(ciudadOrigen, ciudadDestinoFijada, provinciaOrigen, provinciaDestinoFijada);
                tarifaAdicionalHastaCABA = Convert.ToDecimal(ArchivoTarifas.BuscarTarifa(DescRangoDePeso, regionHastaCABA));
            }
            decimal preciotarifaSinRecargo = tarifaTabla + tarifaAdicionalHastaCABA;

            var recargos = Recargos(preciotarifaSinRecargo);

            return (preciotarifaSinRecargo + recargos) * CantBultos;
        }
        public decimal Recargos(decimal preciosinRecargo)
        {
            var totalRecargos = 0M;

            if (chkUrgente.Checked)
            {
                var coeficienteRecargo = ArchivoRecargos.BuscarRecargos(0);
                MessageBox.Show(coeficienteRecargo.ToString(), "Coef recargo");
                var precioUrgente = preciosinRecargo * coeficienteRecargo;
                MessageBox.Show(precioUrgente.ToString(), "precio Urgente");
                var TopeUrgente = ArchivoRecargos.BuscarRecargos(1);
                if (precioUrgente >= TopeUrgente)
                {
                    totalRecargos = TopeUrgente;
                }
                else
                {
                    totalRecargos = precioUrgente;
                }
            }
            if (rboRetiroDomicilio.Checked)
            {
                totalRecargos += ArchivoRecargos.BuscarRecargos(2);
            }
            if (rboEntregaDomicilio.Checked)
            {
                totalRecargos += ArchivoRecargos.BuscarRecargos(3);
            }
            return totalRecargos;
        }

        List<CiudadadesNacionales> ciudadesAMostrar = new List<CiudadadesNacionales>();
        List<CiudadesInternacionales> ciudadesInternacionalesAMostrar = new List<CiudadesInternacionales>();
        
        //Mostrar Provincia Origen
        private void cmbProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudadesAMostrar.Clear();
            cmbCiudadOrigen.Items.Clear();
            string provincia = cmbProvinciaOrigen.Text;

            ciudadesAMostrar = ArchivoCiudadesNacionales.BuscarCiudades(provincia);
            foreach (var ciudad in ciudadesAMostrar)
            {
                cmbCiudadOrigen.Items.Add(ciudad.Ciudad);
            }
        }

        //Mostrar Provincia Destino
        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudadesAMostrar.Clear();
            cmbCiudadDestino.Items.Clear();
            string provincia = cmbProvinciaDestino.Text;

            ciudadesAMostrar = ArchivoCiudadesNacionales.BuscarCiudades(provincia);
            foreach (var ciudad in ciudadesAMostrar)
            {
                cmbCiudadDestino.Items.Add(ciudad.Ciudad);
            }
        }

        //Mostrar Ciudades Internacional Destino
        private void cmbPaisI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudadesInternacionalesAMostrar.Clear();
            cmbCiudadesI.Items.Clear();
            string pais = cmbPaisI.Text;

            ciudadesInternacionalesAMostrar = ArchivoCiudadesInternacionales.BuscarCiudades(pais);

            foreach (var ciudad in ciudadesInternacionalesAMostrar)
            {
                cmbCiudadesI.Items.Add(ciudad.Ciudad);
            }
        }
        
        //-----------FUNCIONALIDADES VISUALES ---------------------------------------------------------------
        public void MostrarOcultar(object sender, EventArgs e)
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
        public void MostramosElementos()
        {
            grpCotizacion.Visible = false;
            lblTitulo.Visible = false;
            grpCaracteristicaServicio.Visible = true;
            grpTipoEnvio.Visible = true;
            grpTipoRecepcion.Visible = true;
            grpNacional.Visible = true;
            grpInternacional.Visible = false;
            btnCotizar.Visible = true;
        }

        public void EscondemosElementos()
        {
            grpCotizacion.Visible = true;
            lblTitulo.Visible = true;
            btnCotizar.Visible = false;

            grpCaracteristicaServicio.Visible = false;
            grpTipoEnvio.Visible = false;
            grpTipoRecepcion.Visible = false;
            grpNacional.Visible = false;
            grpInternacional.Visible = false;
            grpCotizacion.Visible = true;
        }

        public void CentrarElementosCotizacion()
        {
            // -------------- Centramos el elemento de cotizacion -----------------//
            //centra el elemento de cotizacion hoirzontalmente y verticalmente
            grpCotizacion.Location = new Point(
                this.ClientSize.Width / 2 - grpCotizacion.Size.Width / 2,
                this.ClientSize.Height / 2 - grpCotizacion.Size.Height / 2);

            // centra el titulo horizontalmente
            lblTitulo.Location = new Point(
                this.ClientSize.Width / 2 - lblTitulo.Size.Width / 2,
                lblTitulo.Location.Y);

            // centra el boton cotizar horizontalmente
            btnCotizar.Location = new Point(
                this.ClientSize.Width / 2 - btnCotizar.Size.Width / 2,
                btnCotizar.Location.Y);
        }
    }
}
