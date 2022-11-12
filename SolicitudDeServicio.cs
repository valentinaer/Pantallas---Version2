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
        //----------------------CARGAR ELEMENTOS ------------------------------------------------------------------
        public void CargarSucursales()
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
        public void CargarPaisesComboBox()
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

        //----------------------BOTON MODIFICAR--------------------------------------------------------
        private void btnModificar_Click(object sender, EventArgs e)
        {
            MostramosElementos();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int tracking = Autonumerar();
            MessageBox.Show($"La solicitud de servicio se registro de forma exitosa." +
                $" {"\n"} Su numero de trackeo es: {tracking}");
            

            // destino si es nacional
            string destino = "";
            string origen = "";

            // if sucursal show in a string the sucursal selected from dropdown, if envio a domicilio show in a string the provincia and ciudad selected from dropdown
            if (rboSucursalOrigen.Checked && !rboRetiroDomicilio.Checked)
            {
                origen = cmbSucursalOrigen.Text;
            }

            if (rboRetiroDomicilio.Checked && !rboSucursalOrigen.Checked)
            {
                origen = cmbProvinciaOrigen.Text + " - " + cmbCiudadOrigen.Text;
            }


            if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
            {
                destino = cmbSucursalDestino.Text;
            }
            else if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
            {
                destino = cmbCiudadDestino.Text + " - " + cmbProvinciaDestino.Text;
            }
            else
            {
                //  destino = cmbPaisCiudadDestino.Text + " - " + cmbRegionI.Text;
            }

            /* 
            0001|13/09/2022|30-12345678-9|NACIONAL|ARGENTINA|Mendoza|Malargüe|Monroe|1230|PB|ARGENTINA|Mendoza|Malargüe|Belgrano|850|1°C|Correspondencia  de Hasta 500 gr|1|SI|INICIADO|SI
            */
            


            OrdenDeServicio solicitud = new OrdenDeServicio();
            solicitud.numeroTrackeo = tracking; // buscar ultimo numero de trackeo y sumarle 1
            solicitud.fecha = DateTime.Now;
            solicitud.Cuit = CUIT;
            solicitud.tipoDeEnvio = rboNacional.Text = true ? "NACIONAL" : "INTERNACIONAL";
            solicitud.paisOrigen = "ARGENTINA";
            solicitud.provinciaOrigen = cmbProvinciaOrigen.Text;
            solicitud.ciudadOrigen = cmbCiudadOrigen.Text;
            solicitud.calleOrigen = txtDirrecionOrigen.Text;
            solicitud.alturaOrigen = Convert.ToInt32(txtAlturaOrigen.Text);
            solicitud.pisodeptoOrigen = txtPisoDeptoOrigen.Text;
            solicitud.paisDestino = rboNacional.Text = true ? "ARGENTINA" : cmbPaisI.Text;
            solicitud.provinciaDestino = rboNacional.Text = true ? cmbProvinciaDestino.Text : "";
            solicitud.ciudadDestino = rboNacional.Text = true ? cmbCiudadDestino.Text : cmbCiudadesI.Text;
            solicitud.calleDestino = rboNacional.Text = true ? txtDirecionNacional.Text : txtDireccionI.Text;
            solicitud.alturaDestino = Convert.ToInt32(rboNacional.Text = true ? txtAlturaNacional.Text : txtAlturaI.Text); 
            solicitud.pisodeptoDestino = rboNacional.Text = true ? txtPisoDeptoNacional.Text : txtPisoDeptoI.Text;
            solicitud.rangoDePeso = cmbRangoPeso.Text;
            solicitud.cantidadDeBultos = Convert.ToInt32(cmbCantidadBultosN.Text);
            solicitud.urgente = chkUrgente.Text = true ? "SI" : "NO";
            solicitud.estado = "INICIADO";
            solicitud.facturado = "NO";
            
            

            string tipoEnvio = rboNacional.Checked ? "Nacional" : "Internacional";
            // Append Solicitud object to the botton of "./OrdenDeServicio.txt" as a string Sepparated by "|"
            
            
            
            //string CUIT = Usuario.CUIT(usuario);
            //Id_Cotizacion,Aprobado,Estado,Id_Trackeo,CUIT,FechaSolicitud,Origen,Destino,Urgente,TipoDeEnvio,RangoPeso,CantidadBultos
            string nuevaFila = "N°Trackeo|Feha|CUIT Cliente|Tipo DE ENVIO NACIONAL O INTERNACIONAL|PAIS DE ORIGEN|PROVINCIA ORIGEN|CIUDAD ORIGEN|CALLE|ALTURA|PISO DEPTO|PAIS DE DESTINO|PROVINCIA/REGION|CIUDAD DESTINO|CALLE|ALTURA|PISO DEPTO|RANGO DE PESO|CANTIDAD DE BULTOS|URGENTE|ESTADO|FACTURADO";
            Utilidades.GrabarNuevaFila("./OrdenDeServicio.txt", nuevaFila);
        }
        //Boton COTIZAR
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
        public void cotizar(string origen, string destino)
        {
            EscondemosElementos();
            CentrarElementosCotizacion();

            decimal precio = CalcularPrecio();

            // Seteamos el texto de la cotizacion
            lblCotizacion.Text = "$" + precio;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;
            lblUrgente.Text = chkUrgente.Checked ? "Si" : "No";
            lblCuit.Text = "CUIT"; //Cambiar.

        }

        public string ObtenerRegionNacional(string origenCiudad,
            string destinoCiudad, string origenProvincia, string destinoProvincia)
        {
            string origenRegion = ArchivoCiudadesNacionales.BuscarRegionNacional(origenCiudad);
            string destinoRegion = ArchivoCiudadesNacionales.BuscarRegionNacional(destinoCiudad);

            if (origenCiudad == destinoCiudad)
            {
                return "Local";
            }
            if (origenProvincia == destinoProvincia)
            {
                return "Provincial";
            }
            if (origenRegion == destinoRegion)
            {
                return "Regional";
            }
            else
            {
                return "Nacional";
            }
        }

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
                    int idSucursalDestino = (cmbSucursalDestino.SelectedIndex)+1;
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
            MessageBox.Show(regionParaCotizar);
            MessageBox.Show(tarifaTabla.ToString()," tarifa Tabla");

            decimal tarifaAdicionalHastaCABA = 0M;

            if (rboInternacional.Checked)
            {
                string ciudadDestinoFijada = "Belgrano";
                string provinciaDestinoFijada = "C.A.B.A";

                string regionHastaCABA = ObtenerRegionNacional(ciudadOrigen, ciudadDestinoFijada, provinciaOrigen, provinciaDestinoFijada);
                tarifaAdicionalHastaCABA = Convert.ToDecimal(ArchivoTarifas.BuscarTarifa(DescRangoDePeso, regionHastaCABA));
                MessageBox.Show(tarifaAdicionalHastaCABA.ToString(), "Tari Adicional hasta CABA");
            }
            decimal preciotarifaSinRecargo = tarifaTabla + tarifaAdicionalHastaCABA;
            MessageBox.Show(preciotarifaSinRecargo.ToString(), " Tarifas sin Recargo");

            var recargos = Recargos(preciotarifaSinRecargo);

            return (preciotarifaSinRecargo + recargos)*CantBultos;
        }
        public decimal Recargos (decimal preciosinRecargo)
        {
            var totalRecargos = 0M;

            if (chkUrgente.Checked)
            {                
                var coeficienteRecargo = ArchivoRecargos.BuscarRecargos(0);
                MessageBox.Show(coeficienteRecargo.ToString(), "Coef recargo");
                var precioUrgente = preciosinRecargo * coeficienteRecargo;
                MessageBox.Show(precioUrgente.ToString(),"precio Urgente");
                var TopeUrgente = ArchivoRecargos.BuscarRecargos(1);
                if(precioUrgente >= TopeUrgente)
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
        private int Autonumerar()
        {
            Random r = new Random();
            return r.Next(0001, 9999);
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
            foreach (var c in ciudadesAMostrar)
            {
                cmbCiudadOrigen.Items.Add(c.Ciudad);
            }
        }
        
        //Mostrar Provincia Destino
        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudadesAMostrar.Clear();
            cmbCiudadDestino.Items.Clear();
            string provincia = cmbProvinciaDestino.Text;

            ciudadesAMostrar = ArchivoCiudadesNacionales.BuscarCiudades(provincia);
            foreach(var c in ciudadesAMostrar)
            {
                cmbCiudadDestino.Items.Add(c.Ciudad);
            }
        }
      
        //Mostrar Ciudades Internacional Destino
        private void cmbPaisI_SelectedIndexChanged(object sender, EventArgs e)
        {
            ciudadesInternacionalesAMostrar.Clear();
            cmbCiudadesI.Items.Clear();
            string pais = cmbPaisI.Text;

            ciudadesInternacionalesAMostrar = ArchivoCiudadesInternacionales.BuscarCiudades(pais);

            foreach (var c in ciudadesInternacionalesAMostrar)
            {
                cmbCiudadesI.Items.Add(c.Ciudad);
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
