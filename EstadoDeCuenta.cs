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
        List<Factura> facturasImpagas = new List<Factura>();
        public void EstadoDeCuenta_Load(object sender, EventArgs e)
        {
            //lblFechaActual.Text = DateTime.Now;
            string CUIT = Cliente.CuitUsuarioActual; //Este es el numero de CUIT que viene desde el Acceso al Sistema

            Cliente c = new Cliente();
            Cliente ClienteActual = new Cliente();

            ClienteActual = c.BuscarCliente(CUIT);
            lblNombreCliente.Text = ClienteActual.RazonSocial;
            lblSaldoTotal.Text = Convert.ToString(ClienteActual.SaldoFactura);

            lblCuit.Text = CUIT;

            //Para probar si me traia los datos correctos
            MessageBox.Show(ClienteActual.DireccionFacturacion);
            MessageBox.Show(Convert.ToString(ClienteActual.SaldoFactura));
            MessageBox.Show(ClienteActual.RazonSocial);


            
            Factura factura = new Factura();
            facturasCliente = factura.BuscarFacturaCliente(CUIT);

            

         


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
            string CUIT = Cliente.CuitUsuarioActual;

            string msj = "";
            string fechaDesde = txtFechaInicio.Text;
            string fechaHasta = txtFechaFinal.Text;
            string acumulador = "";
            DateTime fechaD;
            DateTime fechaH;

            //Valido la fecha

            msj += Validador.ValidarFecha(fechaDesde, "Fecha inicio");
            msj += Validador.ValidarFecha(fechaHasta, "FechaFinal");

            if (msj != "")
            {
                MessageBox.Show(msj, "Errores");

            }
            else if (rboMostrarTodas.Checked)
            {

                fechaD = Convert.ToDateTime(fechaDesde);
                fechaH = Convert.ToDateTime(fechaHasta);

                if (fechaD > fechaH)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", "Errores");
                }
                else if (fechaD > DateTime.Now || fechaH > DateTime.Now)
                {
                    MessageBox.Show("Las fechas ingresadas deben ser menor a la fecha actual.", "Errores");
                }
                else
                {
                    foreach(Factura factura in facturasCliente) 
                    
                    {
                        if (factura.CUIT == CUIT && (factura.FechaFactura >= fechaD && factura.FechaFactura <= fechaH))
                        {
                            acumulador += factura.FechaFactura.ToString("dd/MM/yyyy") + "     " + factura.NroFactura + "     " + factura.Pagado + "      " + factura.MontoFactura + System.Environment.NewLine;
                        }

                    }

                    richTextBox1.Text = acumulador;

                }
            }
            else if (rboMostrarImpagas.Checked)
            {

                fechaD = Convert.ToDateTime(fechaDesde);
                fechaH = Convert.ToDateTime(fechaHasta);


                if (fechaD > fechaH)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha final.", "Errores");
                }
                else if (fechaD > DateTime.Now || fechaH > DateTime.Now)
                {
                    MessageBox.Show("Las fechas ingresadas deben ser menor a la fecha actual.", "Errores");
                }
                else
                {
                    

                    richTextBox1.Text = "Fecha de las facturas impagas: " + System.Environment.NewLine + fechaD + System.Environment.NewLine + fechaH;
                }

            }
            else
            {

                MessageBox.Show("Debe seleccionar si quiere ver todas las facturas o solo las impagas", "Errores");
            }



        }
       
    }
}
