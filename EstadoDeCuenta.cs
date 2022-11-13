using Clases_TP4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Version_2___Pantallas;

namespace grupoB_TP
{
    public partial class EstadoDeCuenta : Form
    {
        public EstadoDeCuenta()
        {

            InitializeComponent();
        }

        List<Factura> facturasCliente = new List<Factura>();

        public void EstadoDeCuenta_Load(object sender, EventArgs e)
        {
            int saldo = 0;
            string CUIT = "";
            if (PadronClientes.CuitUsuarioActual != null)
            {
                CUIT = PadronClientes.CuitUsuarioActual;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un cliente");
                this.Close();
            }

            PadronClientes ClienteActual = new PadronClientes();

            ClienteActual = ArchivoPadronClientes.BuscarCliente(CUIT); 

            lblNombreCliente.Text = ClienteActual.RazonSocial;
            lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCuit.Text = CUIT;

            Factura factura = new Factura();
            facturasCliente = ArchivoFacturas.BuscarFacturaCliente(CUIT); 

          
            foreach (Factura facturaSeleccionada in facturasCliente)
            {
                if (facturaSeleccionada.CUIT == CUIT && facturaSeleccionada.Pagado == "NO PAGADO")
                {
                    saldo += facturaSeleccionada.MontoFactura;
                }
            }

            lblSaldoTotal.Text = "$" + Convert.ToString(saldo); 
        }

        private void EstadoDeCuenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void rboMostrarTodas_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void rboMostrarImpagas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnMostrarFacturas_Click(object sender, EventArgs e)
        {

        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            string CUIT = "";
            if (PadronClientes.CuitUsuarioActual != null)
            {
                CUIT = PadronClientes.CuitUsuarioActual;
            }

            string mensaje = "";
            string fechaDesde = txtFechaInicio.Text;
            string fechaHasta = txtFechaFinal.Text;
            string acumulador = "";
            DateTime fechaD;
            DateTime fechaH;

            //Valido la fecha
            mensaje += Validador.ValidarFecha(fechaDesde, "de fecha inicial.");
            mensaje += Validador.ValidarFecha(fechaHasta, "de fecha final.");

            if (mensaje != "")
            {
                MessageBox.Show(mensaje, "Errores");
            }
            else if (rboMostrarTodas.Checked)
            {
                fechaD = Convert.ToDateTime(fechaDesde);
                fechaH = Convert.ToDateTime(fechaHasta);

                if (fechaD > fechaH)
                {
                    MessageBox.Show("La fecha de rango inferior no puede ser posterior a la fecha de rango superior.", "Errores");
                }
                else if (fechaD > DateTime.Now || fechaH > DateTime.Now)
                {
                    MessageBox.Show("Las fechas ingresadas deben ser anteriores a la fecha actual.", "Errores");
                }
                else
                {
                    foreach (Factura factura in facturasCliente) //facturasCliente devuelve un conjunto de facturas que pertenecen al CUIT
                    {
                        if (factura.CUIT == CUIT && (factura.FechaFactura >= fechaD && factura.FechaFactura <= fechaH))
                        {
                            acumulador += factura.FechaFactura.ToString("dd/MM/yyyy") + "\t" + factura.NroFactura + "\t\t" + factura.Pagado + "\t\t" + "$" + factura.MontoFactura + System.Environment.NewLine;
                        }
                    }
                    richTextBox1.Text = acumulador;

                    if(string.IsNullOrEmpty(acumulador))
                    {
                        MessageBox.Show("No se encontraron facturas para el rango de fechas ingresado.", "Aviso");
                    }
                }
            }
            else if (rboMostrarImpagas.Checked)
            {
                fechaD = Convert.ToDateTime(fechaDesde);
                fechaH = Convert.ToDateTime(fechaHasta);

                if (fechaD > fechaH)
                {
                    MessageBox.Show("La fecha de rango inferior no puede ser posterior a la fecha de rango superior.", "Errores");
                }
                else if (fechaD > DateTime.Now || fechaH > DateTime.Now)
                {
                    MessageBox.Show("Las fechas ingresadas deben ser anteriores a la fecha actual.", "Errores");
                }
                else
                {
                    foreach (Factura factura in facturasCliente)

                    {
                        if (factura.CUIT == CUIT && (factura.FechaFactura >= fechaD && factura.FechaFactura <= fechaH) && factura.Pagado == "NO PAGADO")
                        {
                            acumulador += factura.FechaFactura.ToString("dd/MM/yyyy") + "\t" + factura.NroFactura + "\t\t" + factura.Pagado + "\t\t" + "$" + factura.MontoFactura + System.Environment.NewLine;
                        }
                    }

                    richTextBox1.Text = acumulador;

                    if (string.IsNullOrEmpty(acumulador))
                    {
                        MessageBox.Show("No se encontraron facturas impagas para el rango de fechas ingresado.", "Aviso");
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar si desea ver todas las facturas o solo las impagas", "Errores");
            }
        }

        private void txtFechaFinal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
