using Clases_TP4;
using System.IO;
using System.Net;
using System.Numerics;
using Version_2___Pantallas;

namespace grupoB_TP
{
    public partial class AccesoAlSistema : Form
    {
        public AccesoAlSistema()
        {
            InitializeComponent();
        }
        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string mensaje;
            string DNI = txtIngresarDNI.Text;
            string contraseña = txtContraseña.Text;
            //Validamos que NO esten Vacios (Flujo 1)
            mensaje = Validador.PedirEntero("El DNI",00000001,99999999, DNI);
            mensaje += Validador.PedirVacio(" La Contraseña", contraseña);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje, "Errores");
            }
            //Validamos DNI debe tener 8 caracteres (Flujo 2)
            if (DNI.Length != 8)
            {
                MessageBox.Show("El DNI debe tener 8 caracteres", "Errores");
            }
            //DNI no Autorizado (Flujo 3)
            Usuario usuario = ArchivoUsuario.BuscarDNI(int.Parse(DNI));

            if (usuario == null)
            {
                MessageBox.Show($"El {DNI} no se encuentra autorizado para" +
                    $" realizar el ingreso al sistema", "Errores");
            }
            //La contraseña excede los 30 caracteres (Flujo 4)
            else if (contraseña.Length > 30)
            {
                MessageBox.Show("La contraseña debe tener como máximo 30 caracteres", "Errores");
            }
            else if (contraseña != usuario.Contraseña)
            {
                MessageBox.Show("La contraseña Ingresada es Incorrecta", "Errores");
                MessageBox.Show(usuario.Contraseña); //trae el nombrey apellido
                MessageBox.Show(usuario.ApellidoNombre); //trae la contraseña
            }
            else
            {
                this.Hide();
                ArchivoClientes.CrearCUITUsuarioActual(usuario.CUIT);
                MessageBox.Show($"Ingreso Exitoso : {usuario.ApellidoNombre}  \n" +
                    $"Perteneciente a la empresa con CUIT: {usuario.CUIT}", "Bienvenido/a");
                new MenuPrincipal(usuario.CUIT).ShowDialog();
            }
        }

        private void AccesoAlSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}


