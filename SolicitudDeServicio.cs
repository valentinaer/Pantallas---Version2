using Clases_TP4;
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
            CUIT = PadronClientes.CuitUsuarioActual!;
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
                    ", " + s.Provincia + ", " + s.NombreCalle + " , " + s.AlturaCalle;
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

            MessageBox.Show($"La ORDEN de servicio se registro de forma exitosa." +
                $"{"\n"}Su numero de trackeo es: {tracking}");

            // destino si es nacional

            Sucursales sucursalOrigen = new Sucursales();
            Sucursales sucursalDestino = new Sucursales();

            if (rboSucursalOrigen.Checked) {
                int sucursalOrigenID = cmbSucursalOrigen.SelectedIndex + 1;
                sucursalOrigen = ArchivoSucursales.BuscarSucursales(sucursalOrigenID);
            }

            if (rboSucursalDestino.Checked)
            {
                int sucursalDestinoID = cmbSucursalDestino.SelectedIndex + 1;
                sucursalDestino = ArchivoSucursales.BuscarSucursales(sucursalDestinoID);
            }
            //Creo la SOLICITUD DE SISTEMA
            OrdenDeServicio orden = new OrdenDeServicio();
            orden.NumeroTrackeo = tracking;
            orden.Fecha = DateTime.Now;
            if (CUIT != null)
            {
                orden.Cuit = CUIT;
            }
            else
            {
                orden.Cuit = "";
            }


            solicitud.TipoDeEnvio = rboNacional.Checked ? "NACIONAL" : "INTERNACIONAL"; // Si el radio button Nacional esta marcado se carga el valor de NACIONAL en el atributo tipo de envio Sino INTERNACIONAL
            solicitud.PaisOrigen = "ARGENTINA"; // Solo los envios salen de Argentina
            solicitud.ProvinciaOrigen = !rboSucursalOrigen.Checked ? cmbProvinciaOrigen.Text : sucursalOrigen.Provincia;
            solicitud.CiudadOrigen = !rboSucursalOrigen.Checked ? cmbCiudadOrigen.Text : sucursalOrigen.Ciudad;
            solicitud.CalleOrigen = !rboSucursalOrigen.Checked ? txtDirrecionOrigen.Text : sucursalOrigen.NombreCalle;
            solicitud.AlturaOrigen = !rboSucursalOrigen.Checked ? 0 : sucursalOrigen.AlturaCalle;
            solicitud.PisodeptoOrigen = txtPisoDeptoOrigen.Text;

            if (!string.IsNullOrWhiteSpace(txtAlturaOrigen.Text))
            {
                orden.AlturaOrigen = Convert.ToInt32(txtAlturaOrigen.Text);
            }

            solicitud.PisodeptoOrigen = txtPisoDeptoOrigen.Text;

            //Determino el PAIS de la solicitud
            if (rboNacional.Checked)
            {
                orden.PaisDestino = "ARGENTINA";
            }
            if (rboInternacional.Checked && cmbPaisI.Text != null)
            {
                orden.PaisDestino = cmbPaisI.Text;
            }
            else
            {
                solicitud.PaisDestino = "";
            }
            //Determino los datos de la provincia ciudad- calle y altura
            if (rboSucursalDestino.Checked)
            {
                orden.ProvinciaDestino = sucursalDestino.Provincia;
                orden.CiudadDestino = sucursalDestino.Ciudad;
                orden.CalleDestino = sucursalDestino.NombreCalle;
                orden.AlturaDestino = sucursalDestino.AlturaCalle;
            }
            else
            {
                solicitud.ProvinciaDestino = rboNacional.Text = true ? cmbProvinciaDestino.Text : ""; // Si el radio button Nacional esta marcado se carga el valor de la provincia en el atributo provincia destino Sino vacio
                solicitud.CiudadDestino = rboNacional.Text = true ? cmbCiudadDestino.Text : cmbCiudadesI.Text; // Si el radio button Nacional esta marcado se carga el valor de la ciudad en el atributo ciudad destino Sino el valor de la ciudad internacional
                solicitud.CalleDestino = rboNacional.Text = true ? txtDirecionNacional.Text : txtDireccionI.Text; // Si el radio button Nacional esta marcado se carga el valor de la direccion nacional en el atributo calle destino Sino el valor de la direccion internacional

            }

            if (rboNacional.Checked && !string.IsNullOrWhiteSpace(txtAlturaNacional.Text))
            {
                orden.AlturaDestino = Convert.ToInt32(txtAlturaNacional.Text);
            }
            if (rboInternacional.Checked && txtAlturaI.Text != null)
            {
                orden.AlturaDestino = Convert.ToInt32(txtAlturaI.Text);
            }
            else
            {
                solicitud.AlturaDestino = 0;
            }
            solicitud.PisodeptoDestino = rboNacional.Text = true ? txtPisoDeptoNacional.Text : txtPisoDeptoI.Text; // Si el radio button Nacional esta marcado se carga el valor Nacional sino Internacional
            solicitud.RangoDePeso = cmbRangoPeso.Text;
            solicitud.CantidadDeBultos = Convert.ToInt32(cmbCantidadBultosN.Text);
            if (chkUrgente.Checked)
            {
                orden.Urgente = "SI";
            }
            else
            {
                orden.Urgente = "NO";
            }

            orden.Estado = "INICIADO"; // Comienza el tramite con el estado INICIADO
            orden.Facturado = "NO"; // No se factura previo a la solicitud

            
            ArchivoOrdenDeServicios.GuardarEnLista(orden);
            this.Hide();
            
            
        }
        
        // Boton en la pantalla del formulario para cotizar el envio
        private void btnCotizar_Click(object sender, EventArgs e)
        {
            //----------------- Validaciones -----------------//

            // Validar que sea Nacional o Internacional
            if (!rboInternacional.Checked && !rboNacional.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de DESTINO: " +
                    "\n"+ "NACIONAL o INTERNACIONAL", "Errores");
                return;
            }

//----------------- Condiciones generales para todos los envios
            //VALIDO RANGO DE PESO
            if (cmbRangoPeso.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un Rango de Peso", "Errores");
                return;
            }
            //VALIDO CANTIDAD DE BULTOS
            if (cmbCantidadBultosN.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la Cantidad de Elementos", "Errores");
                return;
            }
//-------------------VALIDACIONES DE ORIGEN------------------------
            //valida que se haya seleccionado un tipo de envio con los radio buttons Sucursal y Domicilio
            if (!rboSucursalOrigen.Checked && !rboRetiroDomicilio.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de recepcion", "Errores");
                return;
            }
            // Si es RETIRO a domicilio
            if (rboRetiroDomicilio.Checked)
            {
                // Validacion de Provincia en el Origen
                string mensaje = "";
                if (cmbProvinciaOrigen.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una Provincia de ORIGEN" + "\n";
                }
                if (cmbCiudadOrigen.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una Ciudad de ORIGEN" + "\n";
                }
                if (string.IsNullOrEmpty(txtDirrecionOrigen.Text))
                {
                    mensaje += "El domicilio de Retiro a Domicilio de ORIGEN" + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaOrigen.Text))
                {
                    mensaje += "La altura de Retiro de DESTINO" + "\n";
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
            if (rboSucursalOrigen.Checked)
            {
                if (cmbSucursalOrigen.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una Sucursal de ORIGEN", "Errores");
                    return;
                }
            }
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
            //-------------------VALIDACIONES DE DESTINO------------------------

            //------------------ ENVIOS NACIONALES
            if (rboNacional.Checked)
            {

                if (!rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Entrega", "Errores");
                    return;
                }

                //-------------- Condiciones para el ENTREGA A DOMICILIO
                if (rboEntregaDomicilio.Checked)
                {
                    string mensaje = "";
                    //Checkear que se haya seleccionado una Provincia de origen
                    if (cmbProvinciaDestino.SelectedIndex == -1)
                    {
                        mensaje += "Debe seleccionar una Provincia de DESTINO" + "\n";
                    }
                    //Checkear que se haya seleccionado una Ciudad de origen
                    else if (cmbCiudadDestino.SelectedIndex == -1)
                    {
                        mensaje += "Debe seleccionar una Ciudad de DESTINO" + "\n";
                    }
                    if (string.IsNullOrEmpty(txtDirecionNacional.Text))
                    {
                        mensaje += "El domicilio de Entrega a Domicilio de DESTINO" + "\n";
                    }
                    if (string.IsNullOrEmpty(txtAlturaNacional.Text))
                    {
                        mensaje += "La altura de Entrega de DESTINO" + "\n";
                    }
                    else
                    {
                        mensaje += Validador.PedirEntero("Altura de Entrega de DESTINO", 0, 99999, txtAlturaNacional.Text);
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
                        MessageBox.Show("Debe seleccionar una Sucursal de Destino", "Errores");
                        return;
                    }
                }
            }
            //------------------ ENVIOS INTERNACIONALES
            // Validaciones para Envios Internacionales
            if (rboInternacional.Checked && !rboNacional.Checked)
            {
                string mensaje = "";
                if (cmbPaisI.SelectedIndex == -1)
                {
                    mensaje = "Debe seleccionar una País de DESTINO Internacional" + "\n";
                }
                if (cmbCiudadesI.SelectedIndex == -1)
                {
                    mensaje = "Debe seleccionar una Ciudad de DESTINO Internacional" + "\n";
                }
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

            }

//----------------Valido ENTREGA NO CONCIDAN CON DESTINO
                if (!string.IsNullOrWhiteSpace(cmbSucursalOrigen.Text) && !string.IsNullOrWhiteSpace(cmbSucursalDestino.Text) && cmbSucursalDestino.Text == cmbSucursalOrigen.Text)
                {
                    MessageBox.Show("La Sucursal de DESTINO no puede ser la misma que la de ORIGEN", "Errores");
                    return;
                }

                if (rboNacional.Checked && !rboSucursalOrigen.Checked && !rboSucursalDestino.Checked
                    && cmbProvinciaOrigen.Text == cmbProvinciaDestino.Text &&
                    cmbCiudadOrigen.Text == cmbCiudadDestino.Text && txtDirecionNacional.Text
                    == txtDirrecionOrigen.Text && txtAlturaNacional.Text == txtAlturaOrigen.Text)
                {
                    MessageBox.Show("El DESTINO de origen no puede ser el mismo que el de ORIGEN", "Errores");
                    return;
                }
            //LOGICA PARA COTIZAR 
            string destino = "";
                if (rboNacional.Checked)
                {
                    if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
                    {
                        destino = cmbSucursalDestino.Text;
                    }
                    else if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                    {
                        destino = cmbCiudadDestino.Text + " - " + cmbProvinciaDestino.Text;
                    }
                }
                if (rboInternacional.Checked)
                {
                    destino = cmbPaisI.Text + " - " + cmbCiudadesI.Text;
                }
                // Mostrar informacion de cotizacion de Destino
                    cotizar(origen, destino);
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
                var precioUrgente = preciosinRecargo * coeficienteRecargo;
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
            lblTitulo.Visible = true;
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
            lblTitulo.Visible = false;
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

        private void lblCantidadDeBultos_Click(object sender, EventArgs e)
        {

        }
    }
}
