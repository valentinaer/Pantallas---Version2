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
            if(Cliente.CuitUsuarioActual != null){
                CUIT = Cliente.CuitUsuarioActual;
                
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un cliente");
                this.Close();
            } 

            //Cliente c = new Cliente();
            Cliente ClienteActual = new Cliente();

            ClienteActual = ArchivoClientes.BuscarCliente(CUIT); //Utilizo el método de la clase ArchivoClientes para traer los datos del cliente en cuestión

            lblNombreCliente.Text = ClienteActual.RazonSocial;
            lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCuit.Text = CUIT;

            Factura factura = new Factura();
            facturasCliente = ArchivoFacturas.BuscarFacturaCliente(CUIT); //Trae todas las facturas que coinciden con el cuit

            //Muestro el saldo --> Sale de sumar las facturas NO PAGADAS de la lista anterior
            foreach (Factura f in facturasCliente)
            {
                if(f.CUIT == CUIT && f.Pagado == "NO PAGADO")
                {
                    saldo += f.MontoFactura;
                }
            }

            lblSaldoTotal.Text = "$" + Convert.ToString(saldo); //Muestro en pantalla el Saldo para dicho cliente
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
            if(Cliente.CuitUsuarioActual != null){
                CUIT = Cliente.CuitUsuarioActual;
            }
            

            string msj = "";
            string fechaDesde = txtFechaInicio.Text;
            string fechaHasta = txtFechaFinal.Text;
            string acumulador = "";
            DateTime fechaD;
            DateTime fechaH;

            //Valido la fecha

            msj += Validador.ValidarFecha(fechaDesde, "Fecha inicio");
            msj += Validador.ValidarFecha(fechaHasta, "Fecha final");

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
                    foreach(Factura factura in facturasCliente) //facturasCliente devuelve un conjunto de facturas que pertenecen al CUIT
                    
                    {
                        if (factura.CUIT == CUIT && (factura.FechaFactura >= fechaD && factura.FechaFactura <= fechaH))
                        {
                            acumulador += factura.FechaFactura.ToString("dd/MM/yyyy") + "\t" + factura.NroFactura + "\t\t" + factura.Pagado + "\t\t"  + "$" +factura.MontoFactura + System.Environment.NewLine;
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
                    foreach (Factura factura in facturasCliente)

                    {
                        if (factura.CUIT == CUIT && (factura.FechaFactura >= fechaD && factura.FechaFactura <= fechaH) && factura.Pagado == "NO PAGADO")
                        {
                            acumulador += factura.FechaFactura.ToString("dd/MM/yyyy") + "\t" + factura.NroFactura + "\t\t" + factura.Pagado + "\t\t" + "$"+ factura.MontoFactura + System.Environment.NewLine;
                        }

                    }

                    richTextBox1.Text = acumulador;

                }

            }
            else
            {
                    
                MessageBox.Show("Debe seleccionar si quiere ver todas las facturas o solo las impagas", "Errores");
            }



        }

        private void txtFechaFinal_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
