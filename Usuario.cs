using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Version_2___Pantallas
{
    internal class Usuario
    {
        public string CUIT { get; set; }
        public int DNIAutorizados { get; set; }

        public string ApellidoNombre { get; set; }

        public string Contraseña { get; set; }

        // C O N S T R U C T O R E S //
        public Usuario (int dniautorizados, string cuit,string apellidonombre, string contraseña)
        {
            CUIT = cuit;
            DNIAutorizados = dniautorizados;
            ApellidoNombre = apellidonombre;
            Contraseña = contraseña;
        }
   
        public Usuario()
        {

        }

        // MÉTODO CARGAR USUARIOS DE LA LISTA //

        List<Usuario> usuarios = new List<Usuario>();
        
        public void CargarUsuarios()
        {
            using var archivo = new StreamReader("Usuarios.txt");
            while (!archivo.EndOfStream)
            {
                var proximaLinea = archivo.ReadLine();
                string[] datosSeparados = proximaLinea.Split("|");

                Usuario usuario = new Usuario();
                usuario.DNIAutorizados = int.Parse(datosSeparados[0]);
                usuario.CUIT = datosSeparados[1];
                usuario.Contraseña = datosSeparados[2];
                usuario.ApellidoNombre = datosSeparados[3];

                usuarios.Add(usuario);
                Console.WriteLine(usuarios);
            }

        }

        //METODO BUSCAR CUIT (Devuelve una lista) 
        public Usuario BuscarDNI(int dni)
        {
            Usuario U = new Usuario();
            foreach(var personaEnLaLista in usuarios)
            {
                MessageBox.Show(Convert.ToString(personaEnLaLista.DNIAutorizados));
                if (personaEnLaLista.DNIAutorizados== dni)
                {
                    return  U;

                }
            }
            return null;
        }



        public static string RetornoCuit()
        {

            Usuario U = new Usuario();

            


            return U.CUIT;
           
        }

        //Archivo
        //DNI |CUIT| Apellido y Nombre | Contraseña
        
    }
}
