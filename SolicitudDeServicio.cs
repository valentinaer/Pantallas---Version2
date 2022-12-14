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
                string texto = s.NroSucursal.ToString() + "- " + s.Ciudad +
                    ", " + s.Provincia + ", " + s.NombreCalle + " " + s.AlturaCalle;
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

// BOTON para MODIFICAR en la pantalla del formulario
        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostramosElementos();
        }

// BOTON para CONFIRMAR en la pantalla del formulario
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int tracking = ArchivoOrdenDeServicios.BuscarUltimoNumeroTrackeo() + 1;

            MessageBox.Show($"La Orden de Servicio se registro de forma exitosa." +
                $"{"\n"}Su numero de trackeo es: {tracking}", "Orden Generada Correctamente");

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

            orden.TipoDeEnvio = rboNacional.Checked ? "NACIONAL" : "INTERNACIONAL"; // Si el radio button Nacional esta marcado se carga el valor de NACIONAL en el atributo tipo de envio Sino INTERNACIONAL
            
            //DATOS DE ORIGEN
            orden.PaisOrigen = "ARGENTINA"; // Solo los envios por ahora salen de Argentina
            
            if (rboSucursalOrigen.Checked)
            {
                orden.ProvinciaOrigen = sucursalOrigen.Provincia;
                orden.CiudadOrigen = sucursalOrigen.Ciudad;
                orden.CalleOrigen = sucursalOrigen.NombreCalle;
                orden.AlturaOrigen = sucursalOrigen.AlturaCalle;
                orden.PisodeptoOrigen = "NC";
            }
            if (rboRetiroDomicilio.Checked)
            {
                orden.ProvinciaOrigen = cmbProvinciaOrigen.Text;
                orden.CiudadOrigen = cmbCiudadOrigen.Text;
                orden.CalleOrigen = txtDireccionOrigen.Text;
                orden.AlturaOrigen = int.Parse(txtAlturaOrigen.Text);
                orden.PisodeptoOrigen = txtPisoDeptoOrigen.Text;
            }

            string ciudadDestino = "";
            string provinciaDestino = "";
            string calleDestino = "";
            int alturaDestino = 0;
            string pisoDeptoDestino = "";

            if (rboNacional.Checked)
            {
                orden.PaisDestino = "ARGENTINA";
                //LOGICA NACIONAL SUCURSAL o ENTREGA A DOMICILIO
                if (rboSucursalDestino.Checked)
                {
                    ciudadDestino = sucursalDestino.Ciudad;
                    provinciaDestino = sucursalDestino.Provincia;
                    calleDestino = sucursalDestino.NombreCalle;
                    alturaDestino = sucursalDestino.AlturaCalle;
                    pisoDeptoDestino = "NC";
                }
                if (rboEntregaDomicilio.Checked)
                {
                    ciudadDestino = cmbCiudadDestino.Text;
                    provinciaDestino = cmbProvinciaDestino.Text;
                    calleDestino = txtDireccionNacional.Text;
                    alturaDestino = int.Parse(txtAlturaNacional.Text);
                    pisoDeptoDestino = txtPisoDeptoNacional.Text;

                }              
            }
            if (rboInternacional.Checked)
            {
                orden.PaisDestino = cmbPaisI.Text;
                ciudadDestino = cmbCiudadesI.Text;
                provinciaDestino = "";
                calleDestino = txtDireccionI.Text;
                alturaDestino = int.Parse(txtAlturaI.Text);
                pisoDeptoDestino= txtPisoDeptoI.Text;
            }

            orden.CiudadDestino = ciudadDestino;
            orden.ProvinciaDestino = provinciaDestino;
            orden.CalleDestino = calleDestino;
            orden.AlturaDestino = alturaDestino;
            orden.PisodeptoDestino = pisoDeptoDestino;
            orden.RangoDePeso = cmbRangoPeso.Text;
            orden.CantidadDeBultos = int.Parse(cmbCantidadBultosN.Text);
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
        
// Boton para COTIZAR en la pantalla del formulario
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
                MessageBox.Show("Debe seleccionar un tipo de origen: " + "\n" + "Sucursal o Retiro a Domicilio.", "Errores");
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
                if (string.IsNullOrEmpty(txtDireccionOrigen.Text))
                {
                    mensaje += "El domicilio de Retiro no puede estar vacío." + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaOrigen.Text))
                {
                    mensaje += "La altura de Retiro a domicilio no puede estar vacia." + "\n";
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

            if (rboSucursalOrigen.Checked)
            {
                origen = cmbSucursalOrigen.Text;
            }

            if (rboRetiroDomicilio.Checked)
            {
                origen = txtDireccionOrigen.Text +" " + txtAlturaOrigen.Text +", "+
                    cmbCiudadOrigen.Text + ", " + cmbProvinciaOrigen.Text;
            }
            //-------------------VALIDACIONES DE DESTINO------------------------

            //------------------ ENVIOS NACIONALES
            if (rboNacional.Checked)
            {

                if (!rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    MessageBox.Show("Debe seleccionar el Tipo de Entrega: " + "\n" + "En sucursal o Entrega a Domicilio.", "Errores");
                    return;
                }

                //-------------- Condiciones para el ENTREGA A DOMICILIO
                if (rboEntregaDomicilio.Checked)
                {
                    string mensaje = "";
                    //Checkear que se haya seleccionado una Provincia de origen
                    if (cmbProvinciaDestino.SelectedIndex == -1)
                    {
                        mensaje += "Debe seleccionar una Provincia de DESTINO.." + "\n";
                    }
                    //Checkear que se haya seleccionado una Ciudad de origen
                    if (cmbCiudadDestino.SelectedIndex == -1)
                    {
                        mensaje += "Debe seleccionar una Ciudad de DESTINO" + "\n";
                    }
                    if (string.IsNullOrEmpty(txtDireccionNacional.Text))
                    {
                        mensaje += "El domicilio de entrega no puede estar vacío." + "\n";
                    }
                    if (string.IsNullOrEmpty(txtAlturaNacional.Text))
                    {
                        mensaje += "La altura de Entrega a domicilio no puede estar vacía." + "\n";
                    }
                    else
                    {
                        mensaje += Validador.PedirEntero("Altura de Entrega de DESTINO", 0, 999999, txtAlturaNacional.Text);
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
                    mensaje += "Debe seleccionar un País de DESTINO Internacional." + "\n";
                }
                if (cmbCiudadesI.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una Ciudad de DESTINO Internacional." + "\n";
                }
                if (string.IsNullOrEmpty(txtDireccionI.Text))
                {
                    mensaje += "El domicilio de Entrega internacional no puede estar vacío." + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaI.Text))
                {
                    mensaje += "La altura de Entrega Internacional no puede estar vacía." + "\n";
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
                    cmbCiudadOrigen.Text == cmbCiudadDestino.Text && txtDireccionNacional.Text
                    == txtDireccionOrigen.Text && txtAlturaNacional.Text == txtAlturaOrigen.Text)
                {
                    MessageBox.Show("La dirección de DESTINO no puede ser igual a la dirección de ORIGEN", "Errores");
                    return;
                }
            //LOGICA PARA COTIZAR 
                string destino = "";
                if (rboNacional.Checked)
                {
                    if (rboSucursalDestino.Checked)
                    {
                        destino = cmbSucursalDestino.Text;
                    }
                    if (rboEntregaDomicilio.Checked)
                    {
                        destino = txtDireccionNacional.Text + " " + txtAlturaNacional.Text + ", " +
                        cmbCiudadDestino.Text + ", " + cmbProvinciaDestino.Text;
                    }
                }
                if (rboInternacional.Checked)
                {
                    destino = txtDireccionI.Text + " " + txtAlturaI.Text + ", " +
                        cmbCiudadesI.Text + ", " + cmbPaisI.Text;
                }
                // Mostrar informacion de cotizacion de Destino
                    Cotizar(origen, destino);
        }
        
        // Calcular el costo del envio apartir de los datos actuales ingresados
        public void Cotizar(string origen, string destino)
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

        // Calcula el precio buscando en el archivo de tarifas y agrega los recargos
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

        //Define los Recargos a Aplicar
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

//---------------------FILTRADO DE MUESTRAS-----------------------
        List<CiudadadesNacionales> ciudadesAMostrar = new List<CiudadadesNacionales>();
        List<CiudadesInternacionales> ciudadesInternacionalesAMostrar = new List<CiudadesInternacionales>();
        
        //Mostrar Provincia Origen
        private void cmbProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCiudadOrigen.Text = "Ciudad *";
            ciudadesAMostrar.Clear();
            cmbCiudadOrigen.Items.Clear();
            string provincia = cmbProvinciaOrigen.Text;

            ciudadesAMostrar = ArchivoCiudadesNacionales.BuscarCiudades(provincia);
            foreach (var ciudad in ciudadesAMostrar)
            {
                cmbCiudadOrigen.Items.Add(ciudad.Ciudad);
                if (ciudad.Provincia == "C.A.B.A")
                {
                    lblCiudadOrigen.Text = "Barrio *";
                }
            }
        }

        //Mostrar Provincia Destino
        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCiudadDestinoNacional.Text = "Ciudad *";
            ciudadesAMostrar.Clear();
            cmbCiudadDestino.Items.Clear();
            string provincia = cmbProvinciaDestino.Text;

            ciudadesAMostrar = ArchivoCiudadesNacionales.BuscarCiudades(provincia);
            foreach (var ciudad in ciudadesAMostrar)
            {
                cmbCiudadDestino.Items.Add(ciudad.Ciudad);

                if (ciudad.Provincia == "C.A.B.A")
                {
                    lblCiudadDestinoNacional.Text = "Barrio *";
                }
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

    }
}
