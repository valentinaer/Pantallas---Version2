using System.Net;

namespace grupoB_TP
{
    public partial class AccesoAlSistema : Form
    {
        public AccesoAlSistema()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {

            string mensaje = "";

            string DNI = txtIngresarDNI.Text;
            string Contraseña = txtContraseña.Text;

            //Validamos que esten Vacios (Flujo 1)

            mensaje = Usuario.PedirVacio("El DNI", DNI);
            mensaje += Usuario.PedirVacio(" La Contraseña", Contraseña);
            try
            {
                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, "Errores");
                }
                //Validamos DNI debe tener 8 caracteres (Flujo 2)
                else if (DNI.Length != 8)
                {
                    MessageBox.Show("El DNI debe tener 8 caracteres", "Errores");
                }
                //DNI no Autorizado (Flujo 3)
                else if (DNI != "12345678" && DNI != "87654321")
                {
                    MessageBox.Show($"El {DNI} no se encuentra autorizado para realizar el ingreso al sistema", "Errores");
                }

                //La contraseña excede los 30 caracteres (Flujo 4)
                else if (Contraseña.Length > 30)
                {
                    MessageBox.Show("La contraseña debe tener como máximo 30 caracteres", "Errores");
                }

                //Contraseña erronea (Flujo 5) 
                else if (DNI == "12345678") //Con Saldo
                {
                    if (Contraseña != "1234")
                    {
                        MessageBox.Show("La contraseña Ingresada es Incorrecta", "Errores");
                    }
                    else
                    {
                        this.Hide();
                        MessageBox.Show($"Ingreso Exitoso usuario con DNI: {DNI}", "Bienvenido/a");
                        new MenuPrincipal().ShowDialog();
                    }
                }
                else if (DNI == "87654321" && Contraseña == "1234")
                {
                    if (Contraseña != "1234")
                    {
                        MessageBox.Show("La contraseña Ingresada es Incorrecta", "Errores");
                    }
                    else
                    {
                        this.Hide();
                        MessageBox.Show($"Ingreso Exitoso usuario con DNI: {DNI}", "Bienvenido/a");
                        new MenuPrincipal().ShowDialog();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("FALLA DEL SISTEMA");
            }
        }

        private void AccesoAlSistema_Load(object sender, EventArgs e)
        {

        }

        private void AccesoAlSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtIngresarDNI_TextChanged(object sender, EventArgs e)
        {

        }
    }
}