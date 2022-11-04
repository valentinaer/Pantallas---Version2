using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
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

        public void EstadoDeCuenta_Load(object sender, EventArgs e)
        {
            //string CUIT = Usuario.RetornoCuit(); //La idea es traerme el CUIT de acceso al sistema para seguir trabajando acá.

            //List<int> myValues = new List<int>(new int[] { 12345678, 12435678, 11111111,75631841 });

            /*
            //CUIT (RANDOM)
            int[] x = { 12345678, 87654321, 11122223, 45286101 };
            //string result = Convert.ToString(x[(new Random()).Next(4)]);
            string cuit = "30-" + Validador.DNI + "-9";
            string [] cliente = {};
            
            string[] lines = File.ReadAllLines("./Factura.txt");
            int i;
            for (i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(',');
                if (cuit == data[0])
                {
                    cliente = data;
                }
            }

            //SALDOS POSITIVOS O NEGATIVOS RANDOM
            string[] y = { "-$750", "$250", "$-102", "$123" };
            string saldo = y[(new Random()).Next(4)];

            //NOMBRES LISTA
            string[] z = { "Copito S.A.", "EcoLogic S.R.L." };
            string nombre = z[(new Random()).Next(2)];

            /*
            lblNombreCliente.Text = nombre;
            lblCuit.Text = cuit;
            lblFecha.Text = "14/10/2022";
            lblNroFactura.Text = "16-0461";
            lblEstado.Text = "Pago";
            lblTotalFactura.Text = "$875,99";
            lblSaldoTotal.Text = saldo;
            lblFechaActual.Text = Convert.ToString(DateTime.Now);
            */
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
            string msj = "";
            string fechaDesde = txtFechaInicio.Text;
            string fechaHasta = txtFechaFinal.Text;
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
                    //Buscar en la lista teniendo en cuenta el CUIT, TODAS LAS FACTURAS y mostrarlas en el richTextBox.


                    richTextBox1.Text = "Fecha de las facturas: " + System.Environment.NewLine + fechaD + System.Environment.NewLine + fechaH;
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
                    //Buscar en la lista con el CUIT, todas las facturas IMPAGAS y mostrarlas en el richtextbox


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
