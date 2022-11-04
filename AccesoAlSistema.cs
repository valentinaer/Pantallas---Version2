using System.IO;
using System.Net;
using System.Numerics;
using Version_2___Pantallas;

namespace grupoB_TP
{
    public partial class AccesoAlSistema : Form
    {
        List<Usuario> usuarios = new List<Usuario>();
        public AccesoAlSistema()
        {
            InitializeComponent();
        }
        private void CargarUsuarios()
        {
            using var archivo = new StreamReader("Usuarios.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                Usuario usuario = new Usuario();
                usuario.CUIT = datosSeparados[0];
                usuario.DNIAutorizados = int.Parse(datosSeparados[1]);
                usuario.Contraseña = datosSeparados[2];
                usuario.ApellidoNombre = datosSeparados[3];

                usuarios.Add(usuario);
            }
            
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            CargarUsuarios();
            string mensaje = "";
            string CUIT = "";
            string DNI = txtIngresarDNI.Text;
            string contraseña = txtContraseña.Text;

            //Validamos que NO esten Vacios (Flujo 1)

            mensaje = Validador.PedirVacio("El DNI", DNI);
            mensaje += Validador.PedirVacio(" La Contraseña", contraseña);

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
            //CUIT | DNI AUTORIZADO | Contraseña | Nombre y apellido
            // 0   | 1              | 2          | 3

            //Usuario usuario= BuscarCUIT(int.Parse(DNI));
            Usuario usuario = BuscarCUIT(int.Parse(DNI));
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

            if (contraseña != usuario.Contraseña)
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
        

        private Usuario BuscarCUIT(int dni)
        {
            return usuarios.Find(usuario => usuario.DNIAutorizados == dni);
        }

        private void AccesoAlSistema_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}

/*
if (File.Exists("./usuarios.txt"))
{
//Validamos que esten Vacios (Flujo 1)

mensaje = Validador.PedirVacio("El DNI", DNI);
mensaje += Validador.PedirVacio(" La Contraseña", Contraseña);
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
/* else if (DNI != "12345678" && DNI != "87654321")
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

/* else if (DNI == "87654321" && Contraseña == "1234")
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


// Flujo 3 y 5 Se encuentran en la busquedad al atchivo usuario.txt
// El usuario se encuentra en la la lista dentro de usuarios.txt
string[] lines = File.ReadAllLines("./usuarios.txt");
int i;
for (i = 0; i < lines.Length; i++)
{
    string[] data = lines[i].Split(',');
    if (DNI == data[0])
    {
        if (Contraseña == data[1])
        {
            MessageBox.Show("Bienvenido al Sistema");
            this.Hide();
            MessageBox.Show($"Ingreso Exitoso usuario con DNI: {DNI}", "Bienvenido/a");
            new MenuPrincipal().ShowDialog();
            break;
        }
        else
        {
            MessageBox.Show("Contraseña Incorrecta");
            break;
        }

    }

}
}


catch (FormatException)
{
MessageBox.Show("FALLA DEL SISTEMA");
}
}
*/
