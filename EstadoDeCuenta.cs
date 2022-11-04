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
           string CUIT = Usuario.RetornoCuit(); //La idea es traerme el CUIT de acceso al sistema para seguir trabajando acá.
            

           








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
    }
}
